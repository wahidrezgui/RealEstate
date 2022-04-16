using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Proprietes.Queries;

public class GetHeroesProprietesQuery : IRequest<List<ProprieteBriefDto>>
{
}

public class GetHeroesProprietesQueryHandler : IRequestHandler<GetHeroesProprietesQuery, List<ProprieteBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetHeroesProprietesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProprieteBriefDto>> Handle(GetHeroesProprietesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Proprietes
                             .Where(p => p.Priority == PriorityLevel.High)
                             .OrderBy(x => x.Title)
                             .ProjectTo<ProprieteBriefDto>(_mapper.ConfigurationProvider)
                             .ToListAsync();
    }
}