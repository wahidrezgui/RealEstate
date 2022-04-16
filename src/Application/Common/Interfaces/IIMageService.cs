using CleanArchitecture.Application.Images.Queries;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IIMageService
{
    /// <summary>
    /// Store images to Database
    /// </summary>
    /// <param name="images"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task ProcessDB(IEnumerable<ImageInputModel> images, CancellationToken cancellationToken);

    /// <summary>
    /// Process the images and store them in system files
    /// </summary>
    /// <param name="images"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task ProcessSF(IEnumerable<ImageInputModel> images, int IdPropriete, CancellationToken cancellationToken);

    //Task<List<string>> GetAllImages();
}