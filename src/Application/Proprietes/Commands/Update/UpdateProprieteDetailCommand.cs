using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;

namespace CleanArchitecture.Application.Proprietes.Commands.Update;

public class UpdateProprieteDetailCommand : IRequest
{
    public int Id { get; set; }
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

public class UpdateProprieteDetailCommandHandler : IRequestHandler<UpdateProprieteDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProprieteDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateProprieteDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Proprietes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        var municipalite = await _context.Municipalites.FindAsync(new object[] { request.MunicipaliteId }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Propriete), request.Id);
        }

        if (!string.IsNullOrEmpty(request.Title)) entity.Title = request.Title;

        if (!string.IsNullOrEmpty(request.Description)) entity.Description = request.Description;
        if (request.AskedPrice > 0) entity.AskedPrice = request.AskedPrice;
        if (request.Bathroom > 0) entity.Bathroom = request.Bathroom;
        if (request.Bedroom > 0) entity.Bedroom = request.Bedroom;
        if (request.Garage > 0) entity.Garage = request.Garage;
        if (request.LotArea > 0) entity.LotArea = request.LotArea;
        if (request.CoveredArea > 0) entity.CoveredArea = request.CoveredArea;
        if (!string.IsNullOrEmpty(request.Line1)
            || !string.IsNullOrEmpty(request.Line2)
            || !string.IsNullOrEmpty(request.City)) entity.Address = new Address(request.Line1, request.Line2, request.City);

        if (municipalite != null)
        {
            entity.Municipalite = municipalite;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}