using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Notaires.Queries;

public class NotaireDto : IMapFrom<Notaire>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Mobile { get; set; }
}