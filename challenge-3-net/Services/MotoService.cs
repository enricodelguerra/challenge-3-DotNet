using AutoMapper;
using challenge_3_net.Models;
using challenge_3_net.Models.DTOs;
using challenge_3_net.Repositories.Interfaces;
using challenge_3_net.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace challenge_3_net.Services
{
    /// <summary>
    /// Serviço para gerenciamento de motos
    /// </summary>
    public class MotoService : BaseService, IMotoService
    {
        private readonly IMotoRepository _motoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MotoService(
            IMotoRepository motoRepository,
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper)
        {
            _motoRepository = motoRepository;
            _usuarioRepository = usuarioRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedResultDto<MotoResponseDto>> ObterTodasAsync(int pageNumber, int pageSize)
        {
            var (items, totalCount) = await _motoRepository.GetPagedAsync(pageNumber, pageSize);
            var responseItems = _mapper.Map<IEnumerable<MotoResponseDto>>(items);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "motos", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "motos", GetBaseUrl());
        }

        public async Task<MotoResponseDto?> ObterPorIdAsync(long id)
        {
            var moto = await _motoRepository.GetByIdAsync(id);
            if (moto == null)
                return null;

            var response = _mapper.Map<MotoResponseDto>(moto);
            response.Links = CreateHateoasLinks(id, "motos", GetBaseUrl());

            return response;
        }

        public async Task<MotoResponseDto> CriarAsync(CriarMotoDto dto)
        {
            // Validar se usuário existe
            if (!await _usuarioRepository.ExistsAsync(dto.UsuarioId))
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            // Validar se placa já existe
            if (await _motoRepository.PlacaExistsAsync(dto.Placa))
            {
                throw new InvalidOperationException("Placa já está em uso");
            }

            // Validar se chassi já existe
            if (await _motoRepository.ChassiExistsAsync(dto.Chassi))
            {
                throw new InvalidOperationException("Chassi já está em uso");
            }

            var moto = _mapper.Map<Moto>(dto);
            moto.DataCriacao = DateTime.UtcNow;
            moto.DataAtualizacao = DateTime.UtcNow;

            var motoCriada = await _motoRepository.AddAsync(moto);
            var response = _mapper.Map<MotoResponseDto>(motoCriada);
            response.Links = CreateHateoasLinks(motoCriada.Id, "motos", GetBaseUrl());

            return response;
        }

        public async Task<MotoResponseDto?> AtualizarAsync(long id, AtualizarMotoDto dto)
        {
            var moto = await _motoRepository.GetByIdAsync(id);
            if (moto == null)
                return null;

            // Validar se usuário existe
            if (!await _usuarioRepository.ExistsAsync(dto.UsuarioId))
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            // Validar se placa já existe (excluindo a própria moto)
            if (await _motoRepository.PlacaExistsAsync(dto.Placa, id))
            {
                throw new InvalidOperationException("Placa já está em uso");
            }

            // Validar se chassi já existe (excluindo a própria moto)
            if (await _motoRepository.ChassiExistsAsync(dto.Chassi, id))
            {
                throw new InvalidOperationException("Chassi já está em uso");
            }

            _mapper.Map(dto, moto);
            moto.DataAtualizacao = DateTime.UtcNow;

            var motoAtualizada = await _motoRepository.UpdateAsync(moto);
            var response = _mapper.Map<MotoResponseDto>(motoAtualizada);
            response.Links = CreateHateoasLinks(id, "motos", GetBaseUrl());

            return response;
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            return await _motoRepository.RemoveByIdAsync(id);
        }

        public async Task<bool> ExisteAsync(long id)
        {
            return await _motoRepository.ExistsAsync(id);
        }

        public async Task<MotoResponseDto?> ObterPorPlacaAsync(string placa)
        {
            var moto = await _motoRepository.GetByPlacaAsync(placa);
            if (moto == null)
                return null;

            var response = _mapper.Map<MotoResponseDto>(moto);
            response.Links = CreateHateoasLinks(moto.Id, "motos", GetBaseUrl());

            return response;
        }

        public async Task<MotoResponseDto?> ObterPorChassiAsync(string chassi)
        {
            var moto = await _motoRepository.GetByChassiAsync(chassi);
            if (moto == null)
                return null;

            var response = _mapper.Map<MotoResponseDto>(moto);
            response.Links = CreateHateoasLinks(moto.Id, "motos", GetBaseUrl());

            return response;
        }

        public async Task<PagedResultDto<MotoResponseDto>> ObterPorUsuarioAsync(long usuarioId, int pageNumber, int pageSize)
        {
            // Validar se usuário existe
            if (!await _usuarioRepository.ExistsAsync(usuarioId))
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            var (items, totalCount) = await _motoRepository.GetPagedByUsuarioIdAsync(usuarioId, pageNumber, pageSize);
            var responseItems = _mapper.Map<IEnumerable<MotoResponseDto>>(items);

            // Adicionar links HATEOAS para cada item
            foreach (var item in responseItems)
            {
                item.Links = CreateHateoasLinks(item.Id, "motos", GetBaseUrl());
            }

            return CreatePagedResult(responseItems, pageNumber, pageSize, totalCount, "motos", GetBaseUrl());
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
