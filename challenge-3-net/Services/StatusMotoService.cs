using AutoMapper;
using challenge_3_net.Models;
using challenge_3_net.Models.DTOs;
using challenge_3_net.Repositories.Interfaces;
using challenge_3_net.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace challenge_3_net.Services
{
    /// <summary>
    /// Serviço para gerenciamento de status de motos
    /// </summary>
    public class StatusMotoService : BaseService, IStatusMotoService
    {
        private readonly IStatusMotoRepository _statusMotoRepository;
        private readonly IMotoRepository _motoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StatusMotoService(
            IStatusMotoRepository statusMotoRepository,
            IMotoRepository motoRepository,
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper)
        {
            _statusMotoRepository = statusMotoRepository;
            _motoRepository = motoRepository;
            _usuarioRepository = usuarioRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedResultDto<StatusMotoResponseDto>> ObterTodosAsync(int pageNumber, int pageSize)
        {
            var (items, totalCount) = await _statusMotoRepository.GetPagedAsync(pageNumber, pageSize);
            var responseItems = _mapper.Map<IEnumerable<StatusMotoResponseDto>>(items);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "status-motos", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "status-motos", GetBaseUrl());
        }

        public async Task<StatusMotoResponseDto?> ObterPorIdAsync(long id)
        {
            var statusMoto = await _statusMotoRepository.GetByIdAsync(id);
            if (statusMoto == null)
                return null;

            var response = _mapper.Map<StatusMotoResponseDto>(statusMoto);
            response.Links = CreateHateoasLinks(id, "status-motos", GetBaseUrl());

            return response;
        }

        public async Task<StatusMotoResponseDto> CriarAsync(CriarStatusMotoDto dto)
        {
            // Validar se moto existe
            if (!await _motoRepository.ExistsAsync(dto.MotoId))
            {
                throw new InvalidOperationException("Moto não encontrada");
            }

            // Validar se usuário existe
            if (!await _usuarioRepository.ExistsAsync(dto.UsuarioId))
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            var statusMoto = _mapper.Map<StatusMoto>(dto);
            statusMoto.DataStatus = DateTime.UtcNow;

            var statusCriado = await _statusMotoRepository.AddAsync(statusMoto);
            var response = _mapper.Map<StatusMotoResponseDto>(statusCriado);
            response.Links = CreateHateoasLinks(statusCriado.Id, "status-motos", GetBaseUrl());

            return response;
        }

        public async Task<StatusMotoResponseDto?> AtualizarAsync(long id, AtualizarStatusMotoDto dto)
        {
            var statusMoto = await _statusMotoRepository.GetByIdAsync(id);
            if (statusMoto == null)
                return null;

            // Validar se moto existe
            if (!await _motoRepository.ExistsAsync(dto.MotoId))
            {
                throw new InvalidOperationException("Moto não encontrada");
            }

            // Validar se usuário existe
            if (!await _usuarioRepository.ExistsAsync(dto.UsuarioId))
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            _mapper.Map(dto, statusMoto);

            var statusAtualizado = await _statusMotoRepository.UpdateAsync(statusMoto);
            var response = _mapper.Map<StatusMotoResponseDto>(statusAtualizado);
            response.Links = CreateHateoasLinks(id, "status-motos", GetBaseUrl());

            return response;
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            return await _statusMotoRepository.RemoveByIdAsync(id);
        }

        public async Task<bool> ExisteAsync(long id)
        {
            return await _statusMotoRepository.ExistsAsync(id);
        }

        public async Task<StatusMotoResponseDto?> ObterStatusAtualAsync(long motoId)
        {
            // Validar se moto existe
            if (!await _motoRepository.ExistsAsync(motoId))
            {
                throw new InvalidOperationException("Moto não encontrada");
            }

            var statusMoto = await _statusMotoRepository.GetStatusAtualAsync(motoId);
            if (statusMoto == null)
                return null;

            var response = _mapper.Map<StatusMotoResponseDto>(statusMoto);
            response.Links = CreateHateoasLinks(statusMoto.Id, "status-motos", GetBaseUrl());

            return response;
        }

        public async Task<PagedResultDto<StatusMotoResponseDto>> ObterHistoricoPorMotoAsync(long motoId, int pageNumber, int pageSize)
        {
            // Validar se moto existe
            if (!await _motoRepository.ExistsAsync(motoId))
            {
                throw new InvalidOperationException("Moto não encontrada");
            }

            var (items, totalCount) = await _statusMotoRepository.GetPagedByMotoIdAsync(motoId, pageNumber, pageSize);
            var responseItems = _mapper.Map<IEnumerable<StatusMotoResponseDto>>(items);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "status-motos", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "status-motos", GetBaseUrl());
        }

        public async Task<PagedResultDto<StatusMotoResponseDto>> ObterPorStatusAsync(StatusMotoEnum status, int pageNumber, int pageSize)
        {
            var statusMotos = await _statusMotoRepository.GetByStatusAsync(status);
            var totalCount = statusMotos.LongCount();
            
            var responseItems = _mapper.Map<IEnumerable<StatusMotoResponseDto>>(statusMotos)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "status-motos", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "status-motos", GetBaseUrl());
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
