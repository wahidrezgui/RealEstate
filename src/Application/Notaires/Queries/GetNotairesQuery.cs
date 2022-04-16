using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Notaires.Queries;

public class GetNotairesQuery : IRequest<List<NotaireDto>>
{
}

public class GetNotairesQueryHandler : IRequestHandler<GetNotairesQuery, List<NotaireDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNotairesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<NotaireDto>> Handle(GetNotairesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Notaires
                             .OrderBy(x => x.Name)
                             .ProjectTo<NotaireDto>(_mapper.ConfigurationProvider)
                             .ToListAsync();
    }
}