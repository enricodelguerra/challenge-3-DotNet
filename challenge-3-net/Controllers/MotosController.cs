using Microsoft.AspNetCore.Mvc;
using challenge_3_net.Models.DTOs;
using challenge_3_net.Services.Interfaces;

namespace challenge_3_net.Controllers
{
    /// <summary>
    /// Controller para gerenciamento de motos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MotosController : ControllerBase
    {
        private readonly IMotoService _motoService;
        private readonly ILogger<MotosController> _logger;

        public MotosController(IMotoService motoService, ILogger<MotosController> logger)
        {
            _motoService = motoService;
            _logger = logger;
        }

        /// <summary>
        /// Lista todas as motos com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10)</param>
        /// <returns>Lista paginada de motos</returns>
        /// <response code="200">Retorna a lista de motos</response>
        /// <response code="400">Parâmetros inválidos</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResultDto<MotoResponseDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PagedResultDto<MotoResponseDto>>> ObterTodas(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
                {
                    return BadRequest("pageNumber deve ser >= 1 e pageSize deve estar entre 1 e 100");
                }

                var resultado = await _motoService.ObterTodasAsync(pageNumber, pageSize);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter motos");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Busca uma moto por ID
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <returns>Dados da moto</returns>
        /// <response code="200">Retorna a moto encontrada</response>
        /// <response code="404">Moto não encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MotoResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MotoResponseDto>> ObterPorId(long id)
        {
            try
            {
                var moto = await _motoService.ObterPorIdAsync(id);
                if (moto == null)
                {
                    return NotFound($"Moto com ID {id} não encontrada");
                }

                return Ok(moto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter moto com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Busca uma moto por placa
        /// </summary>
        /// <param name="placa">Placa da moto</param>
        /// <returns>Dados da moto</returns>
        /// <response code="200">Retorna a moto encontrada</response>
        /// <response code="404">Moto não encontrada</response>
        [HttpGet("placa/{placa}")]
        [ProducesResponseType(typeof(MotoResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MotoResponseDto>> ObterPorPlaca(string placa)
        {
            try
            {
                var moto = await _motoService.ObterPorPlacaAsync(placa);
                if (moto == null)
                {
                    return NotFound($"Moto com placa {placa} não encontrada");
                }

                return Ok(moto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter moto com placa {Placa}", placa);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Busca uma moto por chassi
        /// </summary>
        /// <param name="chassi">Chassi da moto</param>
        /// <returns>Dados da moto</returns>
        /// <response code="200">Retorna a moto encontrada</response>
        /// <response code="404">Moto não encontrada</response>
        [HttpGet("chassi/{chassi}")]
        [ProducesResponseType(typeof(MotoResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MotoResponseDto>> ObterPorChassi(string chassi)
        {
            try
            {
                var moto = await _motoService.ObterPorChassiAsync(chassi);
                if (moto == null)
                {
                    return NotFound($"Moto com chassi {chassi} não encontrada");
                }

                return Ok(moto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter moto com chassi {Chassi}", chassi);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Lista motos por usuário
        /// </summary>
        /// <param name="usuarioId">ID do usuário</param>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10)</param>
        /// <returns>Lista paginada de motos do usuário</returns>
        /// <response code="200">Retorna a lista de motos do usuário</response>
        /// <response code="400">Parâmetros inválidos</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpGet("usuario/{usuarioId}")]
        [ProducesResponseType(typeof(PagedResultDto<MotoResponseDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResultDto<MotoResponseDto>>> ObterPorUsuario(
            long usuarioId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
                {
                    return BadRequest("pageNumber deve ser >= 1 e pageSize deve estar entre 1 e 100");
                }

                var resultado = await _motoService.ObterPorUsuarioAsync(usuarioId, pageNumber, pageSize);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter motos do usuário {UsuarioId}", usuarioId);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Cria uma nova moto
        /// </summary>
        /// <param name="dto">Dados da moto a ser criada</param>
        /// <returns>Moto criada</returns>
        /// <response code="201">Moto criada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="409">Placa ou chassi já existem</response>
        [HttpPost]
        [ProducesResponseType(typeof(MotoResponseDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<MotoResponseDto>> Criar([FromBody] CriarMotoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var moto = await _motoService.CriarAsync(dto);
                return CreatedAtAction(nameof(ObterPorId), new { id = moto.Id }, moto);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar moto");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Atualiza uma moto existente
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <param name="dto">Dados atualizados da moto</param>
        /// <returns>Moto atualizada</returns>
        /// <response code="200">Moto atualizada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Moto não encontrada</response>
        /// <response code="409">Placa ou chassi já existem</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MotoResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<MotoResponseDto>> Atualizar(long id, [FromBody] AtualizarMotoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var moto = await _motoService.AtualizarAsync(id, dto);
                if (moto == null)
                {
                    return NotFound($"Moto com ID {id} não encontrada");
                }

                return Ok(moto);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar moto com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Exclui uma moto
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="204">Moto excluída com sucesso</response>
        /// <response code="404">Moto não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Excluir(long id)
        {
            try
            {
                var sucesso = await _motoService.ExcluirAsync(id);
                if (!sucesso)
                {
                    return NotFound($"Moto com ID {id} não encontrada");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir moto com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}