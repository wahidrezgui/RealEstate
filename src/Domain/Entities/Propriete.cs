namespace CleanArchitecture.Domain.Entities;

public class Propriete : AuditableEntity, IHasDomainEvent
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal AskedPrice { get; set; }

    public int Bedroom { get; set; }
    public int Bathroom { get; set; }
    public int Garage { get; set; }
    public decimal LotArea { get; set; }
    public decimal CoveredArea { get; set; }
    public IList<PhotoProperty> Photos { get; set; } = new List<PhotoProperty>();

    public IList<Commodity> Commodities { get; set; } = new List<Commodity>();

    public Address Address { get; set; }
    public Municipalite Municipalite { get; set; }

    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public string GetFormattedAskedPrice() => AskedPrice.ToString("0.000");

    public string GetFormattedCurrentPrice() => CurrentPrice.ToString("0.000");

    public bool IsPublished { get; set; }
    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    private bool _sold;

    public bool Sold
    {
        get => _sold;
        set
        {
            if (value == true && _sold == false)
            {
                DomainEvents.Add(new ProprieteSoldEvent(this));
            }

            _sold = value;
        }
    }

    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}