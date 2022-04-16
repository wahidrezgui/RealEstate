using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Proprietes.Queries;

public class GetPropertyDetailsQuery : IRequest<ProprieteDetailDto>
{
    public int propertyid { get; set; }
}

public class GetPropertyDetailsQueryHandler : IRequestHandler<GetPropertyDetailsQuery, ProprieteDetailDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPropertyDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProprieteDetailDto> Handle(GetPropertyDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Proprietes
            .Where(x => x.Id == request.propertyid)
            .ProjectTo<ProprieteDetailDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}