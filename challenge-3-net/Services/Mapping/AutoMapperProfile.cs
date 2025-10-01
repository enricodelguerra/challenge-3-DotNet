using AutoMapper;
using challenge_3_net.Models;
using challenge_3_net.Models.DTOs;

namespace challenge_3_net.Services.Mapping
{
    /// <summary>
    /// Perfil de mapeamento do AutoMapper
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeamentos para Usuario
            CreateMap<Usuario, UsuarioResponseDto>()
                .ForMember(dest => dest.Links, opt => opt.Ignore());

            CreateMap<CriarUsuarioDto, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
                .ForMember(dest => dest.Motos, opt => opt.Ignore())
                .ForMember(dest => dest.Operacoes, opt => opt.Ignore());

            CreateMap<AtualizarUsuarioDto, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
                .ForMember(dest => dest.Motos, opt => opt.Ignore())
                .ForMember(dest => dest.Operacoes, opt => opt.Ignore());

            // Mapeamentos para Moto
            CreateMap<Moto, MotoResponseDto>()
                .ForMember(dest => dest.NomeFilial, opt => opt.MapFrom(src => src.Usuario.NomeFilial))
                .ForMember(dest => dest.Links, opt => opt.Ignore());

            CreateMap<CriarMotoDto, Moto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Operacoes, opt => opt.Ignore())
                .ForMember(dest => dest.StatusMotos, opt => opt.Ignore());

            CreateMap<AtualizarMotoDto, Moto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Operacoes, opt => opt.Ignore())
                .ForMember(dest => dest.StatusMotos, opt => opt.Ignore());

            // Mapeamentos para Operacao
            CreateMap<Operacao, OperacaoResponseDto>()
                .ForMember(dest => dest.PlacaMoto, opt => opt.MapFrom(src => src.Moto.Placa))
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario.NomeFilial))
                .ForMember(dest => dest.Links, opt => opt.Ignore());

            CreateMap<CriarOperacaoDto, Operacao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataOperacao, opt => opt.Ignore())
                .ForMember(dest => dest.Moto, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<AtualizarOperacaoDto, Operacao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataOperacao, opt => opt.Ignore())
                .ForMember(dest => dest.Moto, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            // Mapeamentos para StatusMoto
            CreateMap<StatusMoto, StatusMotoResponseDto>()
                .ForMember(dest => dest.PlacaMoto, opt => opt.MapFrom(src => src.Moto.Placa))
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario.NomeFilial))
                .ForMember(dest => dest.Links, opt => opt.Ignore());

            CreateMap<CriarStatusMotoDto, StatusMoto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataStatus, opt => opt.Ignore())
                .ForMember(dest => dest.Moto, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<AtualizarStatusMotoDto, StatusMoto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataStatus, opt => opt.Ignore())
                .ForMember(dest => dest.Moto, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());
        }
    }
}
