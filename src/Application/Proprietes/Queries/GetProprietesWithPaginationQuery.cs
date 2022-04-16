using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Proprietes.Queries;

public class GetProprietesWithPaginationQuery : IRequest<PaginatedList<ProprieteBriefDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetProprietesWithPaginationQueryHandler : IRequestHandler<GetProprietesWithPaginationQuery, PaginatedList<ProprieteBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProprietesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProprieteBriefDto>> Handle(GetProprietesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Proprietes
            //.Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<ProprieteBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}