
using AutoMapper;
using Bussines.Data.Entityes;
using Bussines.Data.Models;

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
        }
    }
}
