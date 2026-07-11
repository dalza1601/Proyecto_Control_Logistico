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

            CreateMap<SaleDetail, SaleDetailDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
                .ReverseMap();

            CreateMap<Sale, SaleDTO>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client != null ? src.Client.FullName : string.Empty))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.SaleDetails))
                .ReverseMap();
            CreateMap<Warehouse, WareHouseDTO>().ReverseMap();
        }
    }
}
