using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Proprietes.Queries;

public class ProprieteDetailDto : IMapFrom<Propriete>
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string CurrentPrice { get; set; }

    public string AskedPrice { get; set; }

    public int Bedroom { get; set; }
    public int Bathroom { get; set; }
    public int Garage { get; set; }
    public decimal LotArea { get; set; }
    public decimal CoveredArea { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Propriete, ProprieteDetailDto>()
            .ForMember(d => d.CurrentPrice, opt => opt.MapFrom(s => s.GetFormattedCurrentPrice()))
            .ForMember(d => d.AskedPrice, opt => opt.MapFrom(s => s.GetFormattedAskedPrice()));
    }
}