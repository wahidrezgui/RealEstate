using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Images.Queries;

public class GetAllPropertyImagesQuery : IRequest<List<string>>
{
    public int ProprieteId { get; set; }
}

public class GetAllImagesQueryHandler : IRequestHandler<GetAllPropertyImagesQuery, List<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllImagesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<string>> Handle(GetAllPropertyImagesQuery request, CancellationToken cancellationToken)
    {
        return await _context.PhotosProperty
            .Where(x => x.Propriete.Id == request.ProprieteId)
            .OrderBy(x => x.Id)
            .Select(x => x.Folder + "/Thumbnail_" + x.Id.ToString() + ".jpg")
            .ToListAsync();

        //return await _context.Photos
        //    .Where(x => x.Propriete.Id == request.ProprieteId)
        //    .OrderBy(x => x.Id)
        //    .Select(x => x.Id)
        //    .ToListAsync();
    }
}