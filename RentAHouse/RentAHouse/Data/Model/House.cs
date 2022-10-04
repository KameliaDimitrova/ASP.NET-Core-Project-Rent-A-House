using System.ComponentModel.DataAnnotations;

namespace RentAHouse.Data.Model;

public class House
{
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [Range(1, 10)]
    public int BedroomsCount { get; set; }

    [Required]
    [Range(20, 2000)]
    public double TotalArea { get; set; }

    [Required]
    public decimal RentalPrice { get; set; }

    [Required]
    public double YardArea { get; set; }

    public int RegionId { get; set; }

    public Region Region { get; set; }

    public int MunicipalityId { get; set; }

    public Municipality Municipality { get; set; }

    public int SettlementId { get; set; }

    public Settlement Settlement { get; set; }

    public string ImageUrl { get; set; }
}
