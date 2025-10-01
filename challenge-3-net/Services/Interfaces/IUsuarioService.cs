using challenge_3_net.Models.DTOs;
using challenge_3_net.Models; // Adiciona o using para o namespace onde Usuario está definido

namespace challenge_3_net.Services.Interfaces
{
    /// <summary>
    /// Interface para serviço de usuários
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Obtém todos os usuários com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de usuários</returns>
        Task<PagedResultDto<UsuarioResponseDto>> ObterTodosAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Obtém usuário por ID
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Usuário encontrado ou null</returns>
        Task<UsuarioResponseDto?> ObterPorIdAsync(long id);

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="dto">Dados do usuário</param>
        /// <returns>Usuário criado</returns>
        Task<UsuarioResponseDto> CriarAsync(CriarUsuarioDto dto);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="dto">Dados atualizados</param>
        /// <returns>Usuário atualizado ou null se não encontrado</returns>
        Task<UsuarioResponseDto?> AtualizarAsync(long id, AtualizarUsuarioDto dto);

        /// <summary>
        /// Exclui um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>True se excluído com sucesso</returns>
        Task<bool> ExcluirAsync(long id);

        /// <summary>
        /// Verifica se usuário existe
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>True se existe</returns>
        Task<bool> ExisteAsync(long id);

        /// <summary>
        /// Obtém usuário por email
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Usuário encontrado ou null</returns>
        Task<UsuarioResponseDto?> ObterPorEmailAsync(string email);

        /// <summary>
        /// Obtém usuário por CNPJ
        /// </summary>
        /// <param name="cnpj">CNPJ do usuário</param>
        /// <returns>Usuário encontrado ou null</returns>
        Task<UsuarioResponseDto?> ObterPorCnpjAsync(string cnpj);

        /// <summary>
        /// Autentica um usuário pelo e-mail e senha.
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Usuário autenticado ou null</returns>
        Usuario? Autenticar(string email, string senha);
    }
}
