using AutoMapper;
using challenge_3_net.Models;
using challenge_3_net.Models.DTOs;
using challenge_3_net.Repositories.Interfaces;
using challenge_3_net.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace challenge_3_net.Services
{
    /// <summary>
    /// Serviço para gerenciamento de operações
    /// </summary>
    public class OperacaoService : BaseService, IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;
        private readonly IMotoRepository _motoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OperacaoService(
            IOperacaoRepository operacaoRepository,
            IMotoRepository motoRepository,
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper)
        {
            _operacaoRepository = operacaoRepository;
            _motoRepository = motoRepository;
            _usuarioRepository = usuarioRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedResultDto<OperacaoResponseDto>> ObterTodosAsync(int pageNumber, int pageSize)
        {
            var (items, totalCount) = await _operacaoRepository.GetPagedAsync(pageNumber, pageSize);
            var responseItems = _mapper.Map<IEnumerable<OperacaoResponseDto>>(items);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "operacoes", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "operacoes", GetBaseUrl());
        }

        public async Task<OperacaoResponseDto?> ObterPorIdAsync(long id)
        {
            var operacao = await _operacaoRepository.GetByIdAsync(id);
            if (operacao == null)
                return null;

            var response = _mapper.Map<OperacaoResponseDto>(operacao);
            response.Links = CreateHateoasLinks(id, "operacoes", GetBaseUrl());

            return response;
        }

        public async Task<OperacaoResponseDto> CriarAsync(CriarOperacaoDto dto)
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

            var operacao = _mapper.Map<Operacao>(dto);
            operacao.DataOperacao = DateTime.UtcNow;

            var operacaoCriada = await _operacaoRepository.AddAsync(operacao);
            var response = _mapper.Map<OperacaoResponseDto>(operacaoCriada);
            response.Links = CreateHateoasLinks(operacaoCriada.Id, "operacoes", GetBaseUrl());

            return response;
        }

        public async Task<OperacaoResponseDto?> AtualizarAsync(long id, AtualizarOperacaoDto dto)
        {
            var operacao = await _operacaoRepository.GetByIdAsync(id);
            if (operacao == null)
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

            _mapper.Map(dto, operacao);

            var operacaoAtualizada = await _operacaoRepository.UpdateAsync(operacao);
            var response = _mapper.Map<OperacaoResponseDto>(operacaoAtualizada);
            response.Links = CreateHateoasLinks(id, "operacoes", GetBaseUrl());

            return response;
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            return await _operacaoRepository.RemoveByIdAsync(id);
        }

        public async Task<bool> ExisteAsync(long id)
        {
            return await _operacaoRepository.ExistsAsync(id);
        }

        public async Task<PagedResultDto<OperacaoResponseDto>> ObterPorMotoAsync(long motoId, int pageNumber, int pageSize)
        {
            // Validar se moto existe
            if (!await _motoRepository.ExistsAsync(motoId))
            {
                throw new InvalidOperationException("Moto não encontrada");
            }

            var (items, totalCount) = await _operacaoRepository.GetPagedByMotoIdAsync(motoId, pageNumber, pageSize);
            var responseItems = _mapper.Map<IEnumerable<OperacaoResponseDto>>(items);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "operacoes", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "operacoes", GetBaseUrl());
        }

        public async Task<PagedResultDto<OperacaoResponseDto>> ObterPorUsuarioAsync(long usuarioId, int pageNumber, int pageSize)
        {
            // Validar se usuário existe
            if (!await _usuarioRepository.ExistsAsync(usuarioId))
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            var (items, totalCount) = await _operacaoRepository.GetPagedByUsuarioIdAsync(usuarioId, pageNumber, pageSize);
            var responseItems = _mapper.Map<IEnumerable<OperacaoResponseDto>>(items);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "operacoes", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "operacoes", GetBaseUrl());
        }

        public async Task<PagedResultDto<OperacaoResponseDto>> ObterPorTipoAsync(TipoOperacao tipoOperacao, int pageNumber, int pageSize)
        {
            var operacoes = await _operacaoRepository.GetByTipoOperacaoAsync(tipoOperacao);
            var totalCount = operacoes.LongCount();
            
            var responseItems = _mapper.Map<IEnumerable<OperacaoResponseDto>>(operacoes)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "operacoes", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "operacoes", GetBaseUrl());
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
