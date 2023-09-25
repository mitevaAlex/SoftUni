namespace TeisterMask
{
    using AutoMapper;
    using System;
    using System.Globalization;
    using System.Linq;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.DataProcessor.ImportDto;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TeisterMaskProfile()
        {
            this.CreateMap<ImportTaskDto, Task>()
                .ForMember(dto => dto.OpenDate,
                opt => opt.MapFrom(src => DateTime.ParseExact(src.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dto => dto.DueDate,
                opt => opt.MapFrom(src => DateTime.ParseExact(src.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dto => dto.ExecutionType,
                opt => opt.MapFrom(src => (ExecutionType)src.ExecutionType))
                .ForMember(dto => dto.LabelType,
                opt => opt.MapFrom(src => (LabelType)src.LabelType));

            this.CreateMap<ImportProjectDto, Project>()
                .ForMember(dto => dto.Tasks,
                opt => opt.MapFrom(src => src.Tasks.Select(x => StartUp.mapper.Map<Task>(x))))
                .ForMember(dto => dto.OpenDate,
                opt => opt.MapFrom(src => DateTime.ParseExact(src.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dto => dto.DueDate,
                opt => opt.MapFrom(src => string.IsNullOrEmpty(src.DueDate) ? null : ((DateTime?)DateTime.ParseExact(src.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))));
        }
    }
}
