using Microsoft.AspNetCore.Mvc;
using challenge_3_net.Models;
using challenge_3_net.Models.DTOs;
using challenge_3_net.Services.Interfaces;

namespace challenge_3_net.Controllers
{
    /// <summary>
    /// Controller para gerenciamento de status de motos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StatusMotosController : ControllerBase
    {
        private readonly IStatusMotoService _statusMotoService;
        private readonly ILogger<StatusMotosController> _logger;

        public StatusMotosController(IStatusMotoService statusMotoService, ILogger<StatusMotosController> logger)
        {
            _statusMotoService = statusMotoService;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os status com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10)</param>
        /// <returns>Lista paginada de status</returns>
        /// <response code="200">Retorna a lista de status</response>
        /// <response code="400">Parâmetros inválidos</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResultDto<StatusMotoResponseDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PagedResultDto<StatusMotoResponseDto>>> ObterTodos(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
                {
                    return BadRequest("pageNumber deve ser >= 1 e pageSize deve estar entre 1 e 100");
                }

                var resultado = await _statusMotoService.ObterTodosAsync(pageNumber, pageSize);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter status");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Busca um status por ID
        /// </summary>
        /// <param name="id">ID do status</param>
        /// <returns>Dados do status</returns>
        /// <response code="200">Retorna o status encontrado</response>
        /// <response code="404">Status não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StatusMotoResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StatusMotoResponseDto>> ObterPorId(long id)
        {
            try
            {
                var status = await _statusMotoService.ObterPorIdAsync(id);
                if (status == null)
                {
                    return NotFound($"Status com ID {id} não encontrado");
                }

                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter status com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Busca o status atual de uma moto
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <returns>Status atual da moto</returns>
        /// <response code="200">Retorna o status atual da moto</response>
        /// <response code="404">Moto não encontrada ou sem status</response>
        [HttpGet("moto/{motoId}/atual")]
        [ProducesResponseType(typeof(StatusMotoResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StatusMotoResponseDto>> ObterStatusAtual(long motoId)
        {
            try
            {
                var status = await _statusMotoService.ObterStatusAtualAsync(motoId);
                if (status == null)
                {
                    return NotFound($"Status atual da moto {motoId} não encontrado");
                }

                return Ok(status);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter status atual da moto {MotoId}", motoId);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Lista histórico de status de uma moto
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10)</param>
        /// <returns>Lista paginada de status da moto</returns>
        /// <response code="200">Retorna o histórico de status da moto</response>
        /// <response code="400">Parâmetros inválidos</response>
        /// <response code="404">Moto não encontrada</response>
        [HttpGet("moto/{motoId}/historico")]
        [ProducesResponseType(typeof(PagedResultDto<StatusMotoResponseDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResultDto<StatusMotoResponseDto>>> ObterHistoricoPorMoto(
            long motoId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
                {
                    return BadRequest("pageNumber deve ser >= 1 e pageSize deve estar entre 1 e 100");
                }

                var resultado = await _statusMotoService.ObterHistoricoPorMotoAsync(motoId, pageNumber, pageSize);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter histórico de status da moto {MotoId}", motoId);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Lista status por tipo
        /// </summary>
        /// <param name="status">Tipo de status</param>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10)</param>
        /// <returns>Lista paginada de status do tipo</returns>
        /// <response code="200">Retorna a lista de status do tipo</response>
        /// <response code="400">Parâmetros inválidos</response>
        [HttpGet("tipo/{status}")]
        [ProducesResponseType(typeof(PagedResultDto<StatusMotoResponseDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PagedResultDto<StatusMotoResponseDto>>> ObterPorTipo(
            StatusMotoEnum status,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
                {
                    return BadRequest("pageNumber deve ser >= 1 e pageSize deve estar entre 1 e 100");
                }

                var resultado = await _statusMotoService.ObterPorStatusAsync(status, pageNumber, pageSize);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter status por tipo {Status}", status);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Cria um novo status
        /// </summary>
        /// <param name="dto">Dados do status a ser criado</param>
        /// <returns>Status criado</returns>
        /// <response code="201">Status criado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Moto ou usuário não encontrados</response>
        [HttpPost]
        [ProducesResponseType(typeof(StatusMotoResponseDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StatusMotoResponseDto>> Criar([FromBody] CriarStatusMotoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var status = await _statusMotoService.CriarAsync(dto);
                return CreatedAtAction(nameof(ObterPorId), new { id = status.Id }, status);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar status");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Atualiza um status existente
        /// </summary>
        /// <param name="id">ID do status</param>
        /// <param name="dto">Dados atualizados do status</param>
        /// <returns>Status atualizado</returns>
        /// <response code="200">Status atualizado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Status, moto ou usuário não encontrados</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(StatusMotoResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StatusMotoResponseDto>> Atualizar(long id, [FromBody] AtualizarStatusMotoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var status = await _statusMotoService.AtualizarAsync(id, dto);
                if (status == null)
                {
                    return NotFound($"Status com ID {id} não encontrado");
                }

                return Ok(status);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar status com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Exclui um status
        /// </summary>
        /// <param name="id">ID do status</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="204">Status excluído com sucesso</response>
        /// <response code="404">Status não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Excluir(long id)
        {
            try
            {
                var sucesso = await _statusMotoService.ExcluirAsync(id);
                if (!sucesso)
                {
                    return NotFound($"Status com ID {id} não encontrado");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir status com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
