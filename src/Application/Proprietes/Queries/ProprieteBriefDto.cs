using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Proprietes.Queries;

public class ProprieteBriefDto : IMapFrom<Propriete>
{
    public int Id { get; set; }

    public string Title { get; set; }

    public decimal AskedPrice { get; set; }
}
