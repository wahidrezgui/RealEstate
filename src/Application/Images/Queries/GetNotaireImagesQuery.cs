using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Images.Queries;

public class GetNotaireImagesQuery : IRequest<string>
{
    public int NotaireId { get; set; }
}

public class GetNotaireImagesQueryHandler : IRequestHandler<GetNotaireImagesQuery, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNotaireImagesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<string> Handle(GetNotaireImagesQuery request, CancellationToken cancellationToken)
    {
        return await _context.PhotosNotaire
            .Where(x => x.Notaire.Id == request.NotaireId)
            .Select(x => x.Folder + "/Thumbnail_" + x.Id.ToString() + ".jpg")
            .FirstOrDefaultAsync(cancellationToken);
    }
}