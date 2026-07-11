using AutoMapper;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Application.Mapping
{
    public class MappingHelper : Profile
    {
        public MappingHelper() { 
        
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Client,ClientDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            //CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>()
               .ForMember(dest => dest.CategoryName,
               opt => opt.MapFrom(src => src.Category.Name))
               .ReverseMap();
        }
    }
}
