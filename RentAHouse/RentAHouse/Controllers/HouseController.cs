using Microsoft.AspNetCore.Mvc;
using RentAHouse.Data;
using RentAHouse.Data.Model;
using RentAHouse.Models.House;
using System.Diagnostics;

namespace RentAHouse.Controllers;
public class HouseController : Controller
{
    private readonly RentAHouseDbContext dbContext;

    public HouseController(RentAHouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View(new AddHouseFormModel
        {
            Regions = this.GetRegions()
        });
    }

    [HttpGet]
    public IActionResult All()
    {
        return View(new HouseListingViewModel
        {
            Regions = this.GetRegions()
        });
    }


    [HttpPost]
    public IActionResult Add(AddHouseFormModel house, IEnumerable<IFormFile> images)
    {
        if (!this.dbContext.Regions.Any(x => x.Id == house.RegionId))
        {
            this.ModelState.AddModelError(nameof(house.RegionId), "Липсва такъв регион!");
        }

        if (!this.dbContext.Municipalities.Any(x => x.Id == house.MunicipalityId))
        {
            this.ModelState.AddModelError(nameof(house.MunicipalityId), "Липсва такъва община!");
        }

        if (!this.dbContext.Settlements.Any(x => x.Id == house.SettlementId))
        {
            this.ModelState.AddModelError(nameof(house.SettlementId), "Липсва такъва населено място!");
        }

        if (!ModelState.IsValid)
        {
            house.Regions = this.GetRegions();
            return View(house);
        }

        var houseData = new House()
        {
            Description = house.Description,
            TotalArea = house.TotalArea,
            YardArea = house.YardArea,
            BedroomsCount = house.BedroomsCount,
            RentalPrice = house.RentalPrice,
            RegionId = house.RegionId,
            MunicipalityId = house.MunicipalityId,
            SettlementId = house.SettlementId,
            ImageUrl = house.ImageUrl
        };

        this.dbContext.Houses.Add(houseData);
        this.dbContext.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public ICollection<RegionViewModel> GetRegions()
    {
        return this.dbContext
            .Regions
            .Select(r => new RegionViewModel()
            {
                Id = r.Id,
                Name = r.Name
            })
            .ToList();
    }

    [HttpGet]
    public ICollection<MunicipalityViewModel> GetMunicipalities(int regionId)
    {
        return this.dbContext
            .Municipalities
            .Where(m => m.RegionId == regionId)
            .Select(r => new MunicipalityViewModel()
            {
                Id = r.Id,
                Name = r.Name
            })
            .ToList();
    }

    [HttpGet]
    public ICollection<SettlementViewModel> GetSettlements(int municipalityId)
    {
        return this.dbContext
            .Settlements
            .Where(m => m.MunicipalityId == municipalityId)
            .Select(r => new SettlementViewModel()
            {
                Id = r.Id,
                Name = r.Name
            })
            .ToList();
    }
}
