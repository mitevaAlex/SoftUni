using AutoMapper;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCarDto, Car>()
                .ForMember(dto => dto.PartCars,
                opt => opt.MapFrom(src => src.Parts.Select(x => new PartCar() { PartId = x.Id })));

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSaleDto, Sale>();

            this.CreateMap<Car, ExportCarBasicInfoDto>();

            this.CreateMap<Car, ExportBMWDto>();

            this.CreateMap<Supplier, ExportLocalSupplierDto>();

            this.CreateMap<PartCar, ExportPartPriceDto>()
                .ForMember(dto => dto.Name,
                opt => opt.MapFrom(src => src.Part.Name))
                .ForMember(dto => dto.Price,
                opt => opt.MapFrom(src => src.Part.Price));

            this.CreateMap<Car, ExportCarPartsDto>()
                .ForMember(dto => dto.Parts,
                opt => opt.MapFrom(src => src.PartCars.Select(x => StartUp.mapper.Map<ExportPartPriceDto>(x)).ToList()));

            this.CreateMap<Car, ExportCarBasicAttributesDto>();
        }
    }
}
