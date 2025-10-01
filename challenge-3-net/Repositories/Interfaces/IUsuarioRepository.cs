using challenge_3_net.Models;

namespace challenge_3_net.Repositories.Interfaces
{
    /// <summary>
    /// Interface específica para repositório de usuários
    /// </summary>
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        /// <summary>
        /// Obtém usuário por email
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Usuário encontrado ou null</returns>
        Task<Usuario?> GetByEmailAsync(string email);

        /// <summary>
        /// Obtém usuário por CNPJ
        /// </summary>
        /// <param name="cnpj">CNPJ do usuário</param>
        /// <returns>Usuário encontrado ou null</returns>
        Task<Usuario?> GetByCnpjAsync(string cnpj);

        /// <summary>
        /// Verifica se email já existe
        /// </summary>
        /// <param name="email">Email a verificar</param>
        /// <param name="excludeId">ID a excluir da verificação (para atualizações)</param>
        /// <returns>True se email já existe</returns>
        Task<bool> EmailExistsAsync(string email, long? excludeId = null);

        /// <summary>
        /// Verifica se CNPJ já existe
        /// </summary>
        /// <param name="cnpj">CNPJ a verificar</param>
        /// <param name="excludeId">ID a excluir da verificação (para atualizações)</param>
        /// <returns>True se CNPJ já existe</returns>
        Task<bool> CnpjExistsAsync(string cnpj, long? excludeId = null);

        /// <summary>
        /// Obtém usuários com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de usuários</returns>
        Task<(IEnumerable<Usuario> Items, long TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
    }
}
