using AutoMapper;
using RentAHouse.Data.Model;
using RentAHouse.Models.House;

namespace RentAHouse.Infrastructure;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Region, AddHouseFormModel>()
            .ForMember(dest => dest.RegionId, opts => opts.MapFrom(src => src.Id));
    }
}
