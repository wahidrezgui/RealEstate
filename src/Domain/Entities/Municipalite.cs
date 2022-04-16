namespace CleanArchitecture.Domain.Entities;

public class Municipalite
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PostalCode { get; set; }
    public Governorate Governorate { get; set; } = null!;
    public IList<Propriete> Proprietes { get; set; } = new List<Propriete>();
}