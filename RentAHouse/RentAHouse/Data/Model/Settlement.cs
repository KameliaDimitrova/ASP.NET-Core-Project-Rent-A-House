namespace RentAHouse.Data.Model;

public class Settlement
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int MunicipalityId { get; set; }

    public Municipality Municipality { get; set; }

    public ICollection<House> Houses { get; set; }
}
