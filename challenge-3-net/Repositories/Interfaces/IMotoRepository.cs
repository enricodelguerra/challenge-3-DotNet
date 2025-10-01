using challenge_3_net.Models;

namespace challenge_3_net.Repositories.Interfaces
{
    /// <summary>
    /// Interface específica para repositório de motos
    /// </summary>
    public interface IMotoRepository : IRepository<Moto>
    {
        /// <summary>
        /// Obtém moto por placa
        /// </summary>
        /// <param name="placa">Placa da moto</param>
        /// <returns>Moto encontrada ou null</returns>
        Task<Moto?> GetByPlacaAsync(string placa);

        /// <summary>
        /// Obtém moto por chassi
        /// </summary>
        /// <param name="chassi">Chassi da moto</param>
        /// <returns>Moto encontrada ou null</returns>
        Task<Moto?> GetByChassiAsync(string chassi);

        /// <summary>
        /// Verifica se placa já existe
        /// </summary>
        /// <param name="placa">Placa a verificar</param>
        /// <param name="excludeId">ID a excluir da verificação (para atualizações)</param>
        /// <returns>True se placa já existe</returns>
        Task<bool> PlacaExistsAsync(string placa, long? excludeId = null);

        /// <summary>
        /// Verifica se chassi já existe
        /// </summary>
        /// <param name="chassi">Chassi a verificar</param>
        /// <param name="excludeId">ID a excluir da verificação (para atualizações)</param>
        /// <returns>True se chassi já existe</returns>
        Task<bool> ChassiExistsAsync(string chassi, long? excludeId = null);

        /// <summary>
        /// Obtém motos por usuário
        /// </summary>
        /// <param name="usuarioId">ID do usuário</param>
        /// <returns>Lista de motos do usuário</returns>
        Task<IEnumerable<Moto>> GetByUsuarioIdAsync(long usuarioId);

        /// <summary>
        /// Obtém motos com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de motos</returns>
        Task<(IEnumerable<Moto> Items, long TotalCount)> GetPagedAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Obtém motos por usuário com paginação
        /// </summary>
        /// <param name="usuarioId">ID do usuário</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de motos do usuário</returns>
        Task<(IEnumerable<Moto> Items, long TotalCount)> GetPagedByUsuarioIdAsync(long usuarioId, int pageNumber, int pageSize);
    }
}
