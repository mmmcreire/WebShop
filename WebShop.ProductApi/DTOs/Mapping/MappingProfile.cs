using AutoMapper;
using WebShop.ProductApi.Models;

namespace WebShop.ProductApi.DTOs.Mapping;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Category, CategoryDTO>().ReverseMap();
		CreateMap<Product, ProductDTO>().ReverseMap();
	}
}
