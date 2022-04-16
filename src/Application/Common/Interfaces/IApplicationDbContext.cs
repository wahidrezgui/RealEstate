using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Propriete> Proprietes { get; }

    DbSet<Governorate> Governorates { get; }

    DbSet<Municipalite> Municipalites { get; }

    DbSet<PhotoNotaire> PhotosNotaire { get; }

    DbSet<PhotoProperty> PhotosProperty { get; }

    DbSet<Notaire> Notaires { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}