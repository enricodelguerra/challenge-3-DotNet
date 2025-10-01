using AutoMapper;
using challenge_3_net.Models;
using challenge_3_net.Models.DTOs;
using challenge_3_net.Repositories.Interfaces;
using challenge_3_net.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace challenge_3_net.Services
{
    /// <summary>
    /// Serviço para gerenciamento de usuários
    /// </summary>
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper)
        {
            _usuarioRepository = usuarioRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedResultDto<UsuarioResponseDto>> ObterTodosAsync(int pageNumber, int pageSize)
        {
            var (items, totalCount) = await _usuarioRepository.GetPagedAsync(pageNumber, pageSize);
            var responseItems = _mapper.Map<IEnumerable<UsuarioResponseDto>>(items);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "usuarios", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "usuarios", GetBaseUrl());
        }

        public async Task<UsuarioResponseDto?> ObterPorIdAsync(long id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return null;

            var response = _mapper.Map<UsuarioResponseDto>(usuario);
            response.Links = CreateHateoasLinks(id, "usuarios", GetBaseUrl());

            return response;
        }

        public async Task<UsuarioResponseDto> CriarAsync(CriarUsuarioDto dto)
        {
            // Validar se email já existe
            if (await _usuarioRepository.EmailExistsAsync(dto.Email))
            {
                throw new InvalidOperationException("Email já está em uso");
            }

            // Validar se CNPJ já existe
            if (await _usuarioRepository.CnpjExistsAsync(dto.Cnpj))
            {
                throw new InvalidOperationException("CNPJ já está em uso");
            }

            var usuario = _mapper.Map<Usuario>(dto);
            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
            usuario.DataCriacao = DateTime.UtcNow;
            usuario.DataAtualizacao = DateTime.UtcNow;

            var usuarioCriado = await _usuarioRepository.AddAsync(usuario);
            var response = _mapper.Map<UsuarioResponseDto>(usuarioCriado);
            response.Links = CreateHateoasLinks(usuarioCriado.Id, "usuarios", GetBaseUrl());

            return response;
        }

        public async Task<UsuarioResponseDto?> AtualizarAsync(long id, AtualizarUsuarioDto dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return null;

            // Validar se email já existe (excluindo o próprio usuário)
            if (await _usuarioRepository.EmailExistsAsync(dto.Email, id))
            {
                throw new InvalidOperationException("Email já está em uso");
            }

            // Validar se CNPJ já existe (excluindo o próprio usuário)
            if (await _usuarioRepository.CnpjExistsAsync(dto.Cnpj, id))
            {
                throw new InvalidOperationException("CNPJ já está em uso");
            }

            _mapper.Map(dto, usuario);
            usuario.DataAtualizacao = DateTime.UtcNow;

            var usuarioAtualizado = await _usuarioRepository.UpdateAsync(usuario);
            var response = _mapper.Map<UsuarioResponseDto>(usuarioAtualizado);
            response.Links = CreateHateoasLinks(id, "usuarios", GetBaseUrl());

            return response;
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            return await _usuarioRepository.RemoveByIdAsync(id);
        }

        public async Task<bool> ExisteAsync(long id)
        {
            return await _usuarioRepository.ExistsAsync(id);
        }

        public async Task<UsuarioResponseDto?> ObterPorEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            if (usuario == null)
                return null;

            var response = _mapper.Map<UsuarioResponseDto>(usuario);
            response.Links = CreateHateoasLinks(usuario.Id, "usuarios", GetBaseUrl());

            return response;
        }

        public async Task<UsuarioResponseDto?> ObterPorCnpjAsync(string cnpj)
        {
            var usuario = await _usuarioRepository.GetByCnpjAsync(cnpj);
            if (usuario == null)
                return null;

            var response = _mapper.Map<UsuarioResponseDto>(usuario);
            response.Links = CreateHateoasLinks(usuario.Id, "usuarios", GetBaseUrl());

            return response;
        }

        public async Task<Usuario?> AutenticarAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
                return null;
            return usuario;
        }

        public Usuario? Autenticar(string email, string senha)
        {
            var usuarioTask = _usuarioRepository.GetByEmailAsync(email);
            usuarioTask.Wait();
            var usuario = usuarioTask.Result;
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
                return null;
            return usuario;
        }

        private string GetBaseUrl()
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
                return "https://localhost:7000";

            return $"{request.Scheme}://{request.Host}";
        }
    }
}
