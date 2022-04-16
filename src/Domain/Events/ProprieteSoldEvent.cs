namespace CleanArchitecture.Domain.Events;

public class ProprieteSoldEvent : DomainEvent
{
    public ProprieteSoldEvent(Propriete item)
    {
        Item = item;
    }

    public Propriete Item { get; }
}