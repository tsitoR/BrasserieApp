using AutoMapper;
using BrasserieManager.Services.GrossisteAPI.Models;
using BrasserieManager.Services.GrossisteAPI.Models.Dto;

namespace BrasserieManager.Services.GrossisteAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<GrossisteDto, Grossiste>();
                config.CreateMap<Grossiste, GrossisteDto>();
                config.CreateMap<BiereGrossisteDto, BiereGrossiste>();
                config.CreateMap<BiereGrossiste, BiereGrossisteDto>();
            });

            return mappingConfig;
        }
    }
}
