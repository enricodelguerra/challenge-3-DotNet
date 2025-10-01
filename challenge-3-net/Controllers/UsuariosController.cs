using Microsoft.AspNetCore.Mvc;
using challenge_3_net.Models.DTOs;
using challenge_3_net.Services.Interfaces;

namespace challenge_3_net.Controllers
{
    /// <summary>
    /// Controller para gerenciamento de usuários
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuarioService usuarioService, ILogger<UsuariosController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os usuários com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10)</param>
        /// <returns>Lista paginada de usuários</returns>
        /// <response code="200">Retorna a lista de usuários</response>
        /// <response code="400">Parâmetros inválidos</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResultDto<UsuarioResponseDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PagedResultDto<UsuarioResponseDto>>> ObterTodos(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
                {
                    return BadRequest("pageNumber deve ser >= 1 e pageSize deve estar entre 1 e 100");
                }

                var resultado = await _usuarioService.ObterTodosAsync(pageNumber, pageSize);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter usuários");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Busca um usuário por ID
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Dados do usuário</returns>
        /// <response code="200">Retorna o usuário encontrado</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UsuarioResponseDto>> ObterPorId(int id)
        {
            try
            {
                var usuario = await _usuarioService.ObterPorIdAsync(id);
                if (usuario == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado");
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter usuário com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="dto">Dados do usuário a ser criado</param>
        /// <returns>Usuário criado</returns>
        /// <response code="201">Usuário criado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="409">Email ou CNPJ já existem</response>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioResponseDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<UsuarioResponseDto>> Criar([FromBody] CriarUsuarioDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = await _usuarioService.CriarAsync(dto);
                return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuário");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="dto">Dados atualizados do usuário</param>
        /// <returns>Usuário atualizado</returns>
        /// <response code="200">Usuário atualizado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="409">Email ou CNPJ já existem</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UsuarioResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<UsuarioResponseDto>> Atualizar(int id, [FromBody] AtualizarUsuarioDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = await _usuarioService.AtualizarAsync(id, dto);
                if (usuario == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado");
                }

                return Ok(usuario);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar usuário com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Exclui um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="204">Usuário excluído com sucesso</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var sucesso = await _usuarioService.ExcluirAsync(id);
                if (!sucesso)
                {
                    return NotFound($"Usuário com ID {id} não encontrado");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir usuário com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Realiza o login do usuário
        /// </summary>
        /// <param name="request">Dados de login (Email e Senha)</param>
        /// <returns>Usuário autenticado</returns>
        /// <response code="200">Login realizado com sucesso</response>
        /// <response code="401">Usuário ou senha inválidos</response>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var usuario = _usuarioService.Autenticar(request.Email, request.Senha);
            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos.");

            return Ok(usuario);
        }

        public class LoginRequest
        {
            public required string Email { get; set; }
            public required string Senha { get; set; }
        }
    }
}
