using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Images.Queries;

/// <summary>
/// it's dealing only with image property only
/// </summary>
public class GetImageQuery : IRequest<byte[]?>
{
    public Guid PhotoId { get; set; }

    public string Size { get; set; }
}

public class GetThumbnailQueryHandler : IRequestHandler<GetImageQuery, byte[]?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIMageService _imageService;

    public GetThumbnailQueryHandler(IApplicationDbContext context, IMapper mapper, IIMageService iMageService)
    {
        _context = context;
        _mapper = mapper;
        _imageService = iMageService;
    }

    public async Task<byte[]?> Handle(GetImageQuery request, CancellationToken cancellationToken)
    {
        switch (request.Size)
        {
            case "thumbnail":
                return await _context.PhotosProperty
               .Where(t => t.Id == request.PhotoId)
               .Select(i => i.ThumbnailContent)
               .FirstOrDefaultAsync(cancellationToken);

            case "list":
                return await _context.PhotosProperty
                .Where(t => t.Id == request.PhotoId)
                .Select(i => i.ImageInListContent)
                .FirstOrDefaultAsync(cancellationToken);

            case "full":
                return await _context.PhotosProperty
               .Where(t => t.Id == request.PhotoId)
               .Select(i => i.FullScreenContent)
               .FirstOrDefaultAsync(cancellationToken);

            default:
                return null;
        }
    }
}