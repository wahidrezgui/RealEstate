namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// eg: mosque, petrol station, school ,university, shopping center,...
/// </summary>
public class Commodity
{
    public int CommodityId { get; set; }

    public string Name { get; set; }
}