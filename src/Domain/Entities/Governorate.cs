namespace CleanArchitecture.Domain.Entities;

public class Governorate
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IList<Municipalite> Municipalites { get; private set; } = new List<Municipalite>();
}