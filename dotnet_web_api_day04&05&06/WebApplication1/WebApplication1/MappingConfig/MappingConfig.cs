using AutoMapper;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.MappingConfig;

public class MappingConfig: Profile
{
    public MappingConfig()
    {
    
    CreateMap<Employee, BasicEmployeeDTO>().ReverseMap();
    // CreateMap<Category,
    // UpdateCategoryDiscountDto>().ReverseMap();
    // CreateMap<Category,
    // GetCategoryProductsDto>();
    // CreateMap<Product,
    // ProductDto>().ReverseMap();
    
    }
}