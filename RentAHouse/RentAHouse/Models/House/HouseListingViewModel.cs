namespace RentAHouse.Models.House;

public class HouseListingViewModel
{
    public int Id { get; set; }

    public int BedroomsCount { get; set; }

    public decimal RentalPrice { get; set; }

    public double TotalArea { get; set; }

    public double YardArea { get; set; }

    public int RegionId { get; set; }

    public int MunicipalityId { get; set; }

    public int SettlementId { get; set; }

    public string ImageUrl { get; set; }
}
