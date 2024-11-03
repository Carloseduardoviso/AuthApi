
using AutoMapper;
using Bussines.Data.Entityes;
using Bussines.Data.Entityes.Gerenciamento;
using Bussines.Data.Models;
using Bussines.Data.Models.Gerenciamento;

namespace Bussines.Mappings
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Usuario, UsuarioVm>().ReverseMap().PreserveReferences();

            CreateMap<Pagination<Usuario>, Pagination<UsuarioVm>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest, destMember, context) =>
                src.Items.Select(item => context.Mapper.Map<UsuarioVm>(item)).ToList()))
            .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalItems));

            CreateMap<UsuarioSistema, UsuarioSistemaVm>().ReverseMap().PreserveReferences();

            CreateMap<Pagination<UsuarioSistema>, Pagination<UsuarioSistemaVm>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest, destMember, context) =>
                src.Items.Select(item => context.Mapper.Map<UsuarioSistemaVm>(item)).ToList()))
            .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalItems));

            #region Gerenciamento

            CreateMap<Consumidor, ConsumidorVm>().ReverseMap().PreserveReferences();

            CreateMap<Pagination<Consumidor>, Pagination<ConsumidorVm>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest, destMember, context) =>
               src.Items.Select(item => context.Mapper.Map<ConsumidorVm>(item)).ToList()))
            .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalItems));

            CreateMap<Sistema, SistemaVm>().ReverseMap().PreserveReferences();

            CreateMap<Pagination<Sistema>, Pagination<SistemaVm>>()

              .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest, destMember, context) =>
                 src.Items.Select(item => context.Mapper.Map<SistemaVm>(item)).ToList()))
              .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalItems));

            CreateMap<Servico, ServicoVm>().ReverseMap().PreserveReferences();

            CreateMap<Pagination<Servico>, Pagination<ServicoVm>>()
                  .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest, destMember, context) =>
                     src.Items.Select(item => context.Mapper.Map<ServicoVm>(item)).ToList()))
                  .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalItems));

            CreateMap<ConsumidorAgrupado, ConsumidorAgrupadoVm>().ReverseMap().PreserveReferences();

            CreateMap<Pagination<ConsumidorAgrupado>, Pagination<ConsumidorAgrupadoVm>>()
              .ForMember(dest => dest.Items, opt => opt.MapFrom((src, dest, destMember, context) =>
                 src.Items.Select(item => context.Mapper.Map<ConsumidorAgrupadoVm>(item)).ToList()))
              .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalItems));

            #endregion Gerenciamento
        }
    }
}
