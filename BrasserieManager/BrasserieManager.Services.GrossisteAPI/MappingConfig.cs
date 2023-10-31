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
                config.CreateMap<BiereGrossiste, BiereGrossisteDetailsDto>()
                .ForMember(dest => dest.Biere, opt => opt.MapFrom(src => src.Biere.Nom))
                .ForMember(dest => dest.Grossiste, opt => opt.MapFrom(src => src.Grossiste.Nom))
                .ForMember(dest => dest.Brasserie, opt => opt.MapFrom(src => src.Biere.Brasserie.Nom));
                config.CreateMap<BiereCommandeDto, BiereCommande>();
                config.CreateMap<CommandeDto, Commande>();
            });

            return mappingConfig;
        }
    }
}
