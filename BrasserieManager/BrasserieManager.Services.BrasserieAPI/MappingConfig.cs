using AutoMapper;
using BrasserieManager.Services.BrasserieAPI.Models;
using BrasserieManager.Services.BrasserieAPI.Models.Dto;

namespace BrasserieManager.Services.BrasserieAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<BrasserieDto, Brasserie>();
                config.CreateMap<Brasserie, BrasserieDto>();
                config.CreateMap<BiereDto, Biere>();
                config.CreateMap<Biere, BiereDto>();
                config.CreateMap<Biere, BiereDetailsDto>()
                .ForMember(dest => dest.Brasserie, opt => opt.MapFrom(src => src.Brasserie.Nom));
            });

            return mappingConfig;
        }
    }
}
