using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;

namespace CleanArchitecture.Application.Proprietes.Commands.Create;

public class CreateProprieteCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }

    public decimal AskedPrice { get; set; }
    public int Bedroom { get; set; }
    public int Bathroom { get; set; }
    public int Garage { get; set; }
    public decimal LotArea { get; set; }
    public decimal CoveredArea { get; set; }

    public string Line1 { get; set; }

    public string Line2 { get; set; }

    public string City { get; set; }

    public int MunicipaliteId { get; set; }
}

public class CreateProprieteCommandHandler : IRequestHandler<CreateProprieteCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProprieteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProprieteCommand request, CancellationToken cancellationToken)
    {
        var municipalite = _context.Municipalites.Where(i => i.Id == request.MunicipaliteId).FirstOrDefault();
        var entity = new Propriete();

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.AskedPrice = request.AskedPrice;
        entity.Bathroom = request.Bathroom;
        entity.Bedroom = request.Bedroom;
        entity.Garage = request.Garage;
        entity.LotArea = request.LotArea;
        entity.CoveredArea = request.CoveredArea;
        entity.Address = new Address(request.Line1, request.Line2, request.City);
        entity.Municipalite = municipalite;
        _context.Proprietes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}