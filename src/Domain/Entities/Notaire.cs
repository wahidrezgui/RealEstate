namespace CleanArchitecture.Domain.Entities;

public class Notaire : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }

    public Address Address { get; set; }

    public Municipalite Municipalite { get; set; }

    public Guid PhotoId { get; set; }

    public PhotoNotaire Photo { get; set; }
}