using AutoMapper;
using ProductShop.DTO.Export;
using ProductShop.DTO.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();

            this.CreateMap<ImportProductDto, Product>();

            this.CreateMap<ImportCategoryDto, Category>();

            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductPriceBuyerDto>()
                .ForMember(dto => dto.BuyerName,
                opt => opt.MapFrom(src => src.Buyer.FirstName + " " + src.Buyer.LastName))
                .ForMember(dto => dto.Price,
                opt => opt.MapFrom(src => src.Price.ToString().Trim('0')));

            this.CreateMap<User, ExportUserSoldProductsDto>()
                .ForMember(dto => dto.ProductsSold,
                opt => opt.MapFrom(src => src.ProductsSold
                .Select(x => StartUp.mapper.Map<ExportProductPriceDto>(x))));

            this.CreateMap<Product, ExportProductPriceDto>()
                .ForMember(dto => dto.Price,
                opt => opt.MapFrom(src => src.Price.ToString().Trim('0')));

            this.CreateMap<Category, ExportCategoryInfoDto>()
                .ForMember(dto => dto.Count,
                opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dto => dto.AveragePrice,
                opt => opt.MapFrom(src => src.CategoryProducts.Average(x => x.Product.Price)))
                .ForMember(dto => dto.TotalRevenue,
                opt => opt.MapFrom(src => src.CategoryProducts.Sum(x => x.Product.Price)));
        }
    }
}
