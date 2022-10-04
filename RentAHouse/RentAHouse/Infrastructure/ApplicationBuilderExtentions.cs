using Microsoft.EntityFrameworkCore;
using RentAHouse.Data;
using RentAHouse.Data.Model;

namespace RentAHouse.Infrastructure;

public static class ApplicationBuilderExtentions
{
    private static readonly Dictionary<string, Dictionary<string, List<string>>> seedData =
        new Dictionary<string, Dictionary<string, List<string>>>()
{
    {
        "Пазарджик", new Dictionary<string, List<string>> {
            { "Панагюрище", new List<string> { "Попинци", "Левски"}},
            { "Стрелча", new List<string> { "Свобода", "Смилец"}}
        } },
    {
        "Велико Търново", new Dictionary<string, List<string>> {
            { "Стражица", new List<string> { "Лозен", "Камен"}},
            { "Горна Оряховица", new List<string> { "Драганово", "Долна Оряховица"}}
        } }
};

    public static IApplicationBuilder PrepareDatabase(
        this IApplicationBuilder app)
    {
        using var scopedServices = app.ApplicationServices.CreateScope();
        var data = scopedServices.ServiceProvider.GetService<RentAHouseDbContext>();
        data.Database.Migrate();
        SeedData(data);

        return app;
    }

    private static void SeedData(RentAHouseDbContext data)
    {
        if (data.Regions.Any())
        {
            return;
        }
        foreach (var region in seedData)
        {
            data.Regions.Add(new Region { Name = region.Key });
            data.SaveChanges();
            foreach (var municipality in region.Value)
            {
                var addedRegion = data.Regions.Where(x => x.Name == region.Key).First();
                data.Municipalities.Add(new Municipality { Name = municipality.Key, Region = addedRegion, RegionId = addedRegion.Id });
                data.SaveChanges();
                foreach (var sattlement in municipality.Value)
                {
                    var addedMunicipality = data.Municipalities.Where(x => x.Name == municipality.Key).First();
                    data.Settlements.Add(new Settlement { Name = sattlement, Municipality = addedMunicipality, MunicipalityId = addedMunicipality.Id });
                    data.SaveChanges();
                }
            }
        }
    }
}
