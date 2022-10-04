using RentAHouse.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentAHouse.Models.House;

public class AddHouseFormModel
{
    public int Id { get; set; }

    [Required]
    [DisplayName("Описание")]
    [StringLength(
        DataConstants.DescriptionMaxLength, 
        MinimumLength = DataConstants.DescriptionMinLength,
        ErrorMessage = "Дължината на текста не е коректна")]
    public string Description { get; set; }

    [Required]
    [DisplayName("Брой спални")]
    public int BedroomsCount { get; set; }

    [Required]
    [DisplayName("Наем, лв.")]
    [Range(1, int.MaxValue)]
    public decimal RentalPrice { get; set; }

    [Required]
    [DisplayName("Квадратура - къща, кв.м.")]
    [Range(1, int.MaxValue)]
    public double TotalArea { get; set; }

    [DisplayName("Квадратура - двор, кв.м.")]
    [Range(1, int.MaxValue)]
    public double YardArea { get; set; }

    [Required]
    [DisplayName("Регион")]
    public int RegionId { get; set; }

    public ICollection<RegionViewModel> Regions { get; set; } = new List<RegionViewModel>();    

    [Required]
    [DisplayName("Община")]
    public int MunicipalityId { get; set; }

    [Required]
    [DisplayName("Населено място")]
    public int SettlementId { get; set; }

    [Required]
    [DisplayName("Image URL")]
    [Url]
    public string ImageUrl { get; set; }
}
