using challenge_3_net.Models;

namespace challenge_3_net.Repositories.Interfaces
{
    /// <summary>
    /// Interface específica para repositório de status de motos
    /// </summary>
    public interface IStatusMotoRepository : IRepository<StatusMoto>
    {
        /// <summary>
        /// Obtém status atual de uma moto
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <returns>Status atual da moto ou null</returns>
        Task<StatusMoto?> GetStatusAtualAsync(long motoId);

        /// <summary>
        /// Obtém histórico de status de uma moto
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <returns>Lista de status da moto</returns>
        Task<IEnumerable<StatusMoto>> GetHistoricoByMotoIdAsync(long motoId);

        /// <summary>
        /// Obtém status por tipo
        /// </summary>
        /// <param name="status">Status a buscar</param>
        /// <returns>Lista de status do tipo</returns>
        Task<IEnumerable<StatusMoto>> GetByStatusAsync(StatusMotoEnum status);

        /// <summary>
        /// Obtém status por área
        /// </summary>
        /// <param name="area">Área a buscar</param>
        /// <returns>Lista de status da área</returns>
        Task<IEnumerable<StatusMoto>> GetByAreaAsync(string area);

        /// <summary>
        /// Obtém status por período
        /// </summary>
        /// <param name="dataInicio">Data de início</param>
        /// <param name="dataFim">Data de fim</param>
        /// <returns>Lista de status no período</returns>
        Task<IEnumerable<StatusMoto>> GetByPeriodoAsync(DateTime dataInicio, DateTime dataFim);

        /// <summary>
        /// Obtém status com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de status</returns>
        Task<(IEnumerable<StatusMoto> Items, long TotalCount)> GetPagedAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Obtém status por moto com paginação
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de status da moto</returns>
        Task<(IEnumerable<StatusMoto> Items, long TotalCount)> GetPagedByMotoIdAsync(long motoId, int pageNumber, int pageSize);
    }
}
