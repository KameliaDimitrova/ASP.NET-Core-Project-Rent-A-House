namespace RentAHouse.Data.Model;

public class Region
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Municipality> Municipalities { get; init; } = new List<Municipality>();
}
