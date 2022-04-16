using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Images.Queries;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace CleanArchitecture.Infrastructure.Files;

public class ImageService : IIMageService
{
    private const int ThumbnailSize = 300;
    private const int ImageInListSize = 600;
    private const int FullScreenSize = 1000;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ImageService(IServiceScopeFactory iserviceScopeFactory)
    {
        _serviceScopeFactory = iserviceScopeFactory;
    }

    public async Task ProcessDB(IEnumerable<ImageInputModel> images, CancellationToken cancellationToken)
    {
        var Tasks = new List<Task>();
        foreach (var image in images)
        {
            try
            {
                //Tasks.Add(Task.Run(async () =>
                //{
                //    using var imageResult = await Image.LoadAsync(image.Content);

                //    await SaveImageAsFile(imageResult, $"Originale_{image.Name}", imageResult.Width, image.IdPropriete);
                //    await SaveImageAsFile(imageResult, $"FullScreen_{image.Name}", FullScreen, image.IdPropriete);
                //    await SaveImageAsFile(imageResult, $"ImageInList_{image.Name}", ImageInList, image.IdPropriete);
                //    await SaveImageAsFile(imageResult, $"Thumbnail_{image.Name}", Thumbnail, image.IdPropriete);
                //}));
                Tasks.Add(Task.Run(async () =>
                {
                    using var imageResult = await Image.LoadAsync(image.Content);

                    var Originale = await SaveImageToDB(imageResult, imageResult.Width);
                    var FullScreen = await SaveImageToDB(imageResult, FullScreenSize);
                    var ImageInList = await SaveImageToDB(imageResult, ImageInListSize);
                    var Thumbnail = await SaveImageToDB(imageResult, ThumbnailSize);

                    ///
                    var data = _serviceScopeFactory.CreateScope()
                                                    .ServiceProvider
                                                    .GetRequiredService<IApplicationDbContext>();

                    var propriete = await data.Proprietes.FindAsync(new object[] { image.IdPropriete });

                    if (propriete != null)
                    {
                        data.PhotosProperty.Add(new PhotoProperty()
                        {
                            Propriete = propriete,
                            OriginalFileName = image.Name,
                            OriginalType = image.Type,
                            OriginalContent = Originale,
                            FullScreenContent = FullScreen,
                            ImageInListContent = ImageInList,
                            ThumbnailContent = Thumbnail,
                            Folder = ""
                        });

                        await data.SaveChangesAsync(cancellationToken);
                    }
                }));
            }
            catch (Exception)
            {
                //log exception
            }

            await Task.WhenAll(Tasks);
        }
    }

    private static async Task SaveImageAsFile(Image imageResult, string path, string name, int resizewidth)
    {
        var width = imageResult.Width;
        var height = imageResult.Height;

        if (width > resizewidth)
        {
            height = (int)((double)resizewidth / width * height);
            width = resizewidth;
        }

        imageResult.Mutate(i => i.Resize(new Size(width, height)));
        imageResult.Metadata.ExifProfile = null;

        await imageResult.SaveAsJpegAsync($"{path}/{name}", new JpegEncoder
        {
            Quality = 75,
        });
    }

    private static async Task<byte[]> SaveImageToDB(Image imageResult, int resizewidth)
    {
        var width = imageResult.Width;
        var height = imageResult.Height;

        if (width > resizewidth)
        {
            height = (int)((double)resizewidth / width * height);
            width = resizewidth;
        }

        imageResult.Mutate(i => i.Resize(new Size(width, height)));
        imageResult.Metadata.ExifProfile = null;

        var memorystream = new MemoryStream();

        await imageResult.SaveAsJpegAsync(memorystream, new JpegEncoder
        {
            Quality = 75,
        });

        return memorystream.ToArray();
    }

    /// <summary>
    /// save images in file system FS
    /// </summary>
    /// <param name="images"></param>
    /// <param name="IdPropriete"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task ProcessSF(IEnumerable<ImageInputModel> images, int IdPropriete, CancellationToken cancellationToken)
    {
        var data = _serviceScopeFactory.CreateScope()
                                                   .ServiceProvider
                                                   .GetRequiredService<IApplicationDbContext>();

        var totalImages = await data.PhotosProperty.CountAsync();
        var propriete = await data.Proprietes.FindAsync(new object[] { IdPropriete });

        if (propriete == null) throw new Exception("Propriete doesn't exist");

        var Tasks = new List<Task>();
        foreach (var image in images)
        {
            try
            {
                Tasks.Add(Task.Run(async () =>
                {
                    using var imageResult = await Image.LoadAsync(image.Content);

                    var id = Guid.NewGuid();
                    var path = $"/images/{totalImages % 1000}/";
                    var name = $"{id}.jpg";

                    var storagePath = Path.Combine(
                       Directory.GetCurrentDirectory(), $"wwwroot{path}".Replace("/", "\\"));

                    if (!Directory.Exists(storagePath))
                    {
                        Directory.CreateDirectory(storagePath);
                    }
                    await SaveImageAsFile(imageResult,
                            storagePath, $"Original_{name}", imageResult.Width);
                    await SaveImageAsFile(imageResult,
                            storagePath, $"FullScreen_{name}", FullScreenSize);
                    await SaveImageAsFile(imageResult,
                            storagePath, $"InlistSize_{name}", ImageInListSize);
                    await SaveImageAsFile(imageResult,
                            storagePath, $"Thumbnail_{name}", ThumbnailSize);

                    ///

                    data.PhotosProperty.Add(new PhotoProperty()
                    {
                        Id = id,
                        Propriete = propriete,
                        OriginalFileName = image.Name,
                        OriginalType = image.Type,
                        Folder = path
                    });

                    await data.SaveChangesAsync(cancellationToken);
                }));
            }
            catch (Exception)
            {
                //log exception
            }

            await Task.WhenAll(Tasks);
        }
    }

    //public Task<List<string>> GetAllImages()
    //{
    //    throw new NotImplementedException();
    //}
}