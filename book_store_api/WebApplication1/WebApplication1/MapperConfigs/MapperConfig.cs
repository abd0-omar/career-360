using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.DTOs.Customer;
using WebApplication1.Models;

namespace WebApplication1.MapperConfigs;

public class MapperConfig: Profile
{
    public MapperConfig()
    {
        CreateMap<AddCustomerDto, Customer>().ReverseMap();
    }
}