using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Proprietes.Commands.Delete;

public class DeleteProprieteCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteProprieteCommandHandler : IRequestHandler<DeleteProprieteCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProprieteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteProprieteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Proprietes
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Proprietes), request.Id);
        }

        _context.Proprietes.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}