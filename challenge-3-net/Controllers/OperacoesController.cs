using Microsoft.AspNetCore.Mvc;
using challenge_3_net.Models.DTOs;
using challenge_3_net.Services.Interfaces;

namespace challenge_3_net.Controllers
{    /// <summary>
     /// Controller para gerenciamento de operações
     /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OperacoesController : ControllerBase
    {
        private readonly IOperacaoService _operacaoService;
        private readonly ILogger<OperacoesController> _logger;

        public OperacoesController(IOperacaoService operacaoService, ILogger<OperacoesController> logger)
        {
            _operacaoService = operacaoService;
            _logger = logger;
        }

        /// <summary>
        /// Lista todas as operações com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10)</param>
        /// <returns>Lista paginada de operações</returns>
        /// <response code="200">Retorna a lista de operações</response>
        /// <response code="400">Parâmetros inválidos</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResultDto<OperacaoResponseDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PagedResultDto<OperacaoResponseDto>>> ObterTodos(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
                {
                    return BadRequest("pageNumber deve ser >= 1 e pageSize deve estar entre 1 e 100");
                }

                var resultado = await _operacaoService.ObterTodosAsync(pageNumber, pageSize);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter operações");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Busca uma operação por ID
        /// </summary>
        /// <param name="id">ID da operação</param>
        /// <returns>Dados da operação</returns>
        /// <response code="200">Retorna a operação encontrada</response>
        /// <response code="404">Operação não encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OperacaoResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OperacaoResponseDto>> ObterPorId(int id)
        {
            try
            {
                var operacao = await _operacaoService.ObterPorIdAsync(id);
                if (operacao == null)
                {
                    return NotFound($"Operação com ID {id} não encontrada");
                }

                return Ok(operacao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter operação com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Cria uma nova operação
        /// </summary>
        /// <param name="dto">Dados da operação a ser criada</param>
        /// <returns>Operação criada</returns>
        /// <response code="201">Operação criada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Moto ou usuário não encontrados</response>
        [HttpPost]
        [ProducesResponseType(typeof(OperacaoResponseDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OperacaoResponseDto>> Criar([FromBody] CriarOperacaoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var operacao = await _operacaoService.CriarAsync(dto);
                return CreatedAtAction(nameof(ObterPorId), new { id = operacao.Id }, operacao);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar operação");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Atualiza uma operação existente
        /// </summary>
        /// <param name="id">ID da operação</param>
        /// <param name="dto">Dados atualizados da operação</param>
        /// <returns>Operação atualizada</returns>
        /// <response code="200">Operação atualizada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Operação não encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OperacaoResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OperacaoResponseDto>> Atualizar(int id, [FromBody] AtualizarOperacaoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var operacao = await _operacaoService.AtualizarAsync(id, dto);
                if (operacao == null)
                {
                    return NotFound($"Operação com ID {id} não encontrada");
                }

                return Ok(operacao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar operação com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Exclui uma operação
        /// </summary>
        /// <param name="id">ID da operação</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="204">Operação excluída com sucesso</response>
        /// <response code="404">Operação não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var sucesso = await _operacaoService.ExcluirAsync(id);
                if (!sucesso)
                {
                    return NotFound($"Operação com ID {id} não encontrada");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir operação com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
