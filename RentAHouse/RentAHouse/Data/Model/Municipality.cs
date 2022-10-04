namespace RentAHouse.Data.Model;

public class Municipality
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int RegionId { get; set; }

    public Region Region { get; set; }

    public ICollection<Settlement> Settlements { get; init; } = new List<Settlement>();
}
