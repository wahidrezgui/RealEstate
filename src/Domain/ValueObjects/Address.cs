namespace CleanArchitecture.Domain.ValueObjects;

public class Address : ValueObject
{
    static Address()
    {
    }

    private Address()
    {
    }

    public Address(string line1, string line2, string city)
    {
        Line1 = line1;
        Line2 = line2;
        City = city;
    }

    public string Line1 { get; set; }

    public string Line2 { get; set; }

    public string City { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Line1;
        yield return Line2;
        yield return City;
    }
}