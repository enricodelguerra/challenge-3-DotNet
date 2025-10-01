using challenge_3_net.Models;

namespace challenge_3_net.Repositories.Interfaces
{
    /// <summary>
    /// Interface específica para repositório de operações
    /// </summary>
    public interface IOperacaoRepository : IRepository<Operacao>
    {
        /// <summary>
        /// Obtém operações por moto
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <returns>Lista de operações da moto</returns>
        Task<IEnumerable<Operacao>> GetByMotoIdAsync(long motoId);

        /// <summary>
        /// Obtém operações por usuário
        /// </summary>
        /// <param name="usuarioId">ID do usuário</param>
        /// <returns>Lista de operações do usuário</returns>
        Task<IEnumerable<Operacao>> GetByUsuarioIdAsync(long usuarioId);

        /// <summary>
        /// Obtém operações por tipo
        /// </summary>
        /// <param name="tipoOperacao">Tipo da operação</param>
        /// <returns>Lista de operações do tipo</returns>
        Task<IEnumerable<Operacao>> GetByTipoOperacaoAsync(TipoOperacao tipoOperacao);

        /// <summary>
        /// Obtém operações por período
        /// </summary>
        /// <param name="dataInicio">Data de início</param>
        /// <param name="dataFim">Data de fim</param>
        /// <returns>Lista de operações no período</returns>
        Task<IEnumerable<Operacao>> GetByPeriodoAsync(DateTime dataInicio, DateTime dataFim);

        /// <summary>
        /// Obtém operações com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de operações</returns>
        Task<(IEnumerable<Operacao> Items, long TotalCount)> GetPagedAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Obtém operações por moto com paginação
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de operações da moto</returns>
        Task<(IEnumerable<Operacao> Items, long TotalCount)> GetPagedByMotoIdAsync(long motoId, int pageNumber, int pageSize);

        /// <summary>
        /// Obtém operações por usuário com paginação
        /// </summary>
        /// <param name="usuarioId">ID do usuário</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de operações do usuário</returns>
        Task<(IEnumerable<Operacao> Items, long TotalCount)> GetPagedByUsuarioIdAsync(long usuarioId, int pageNumber, int pageSize);
    }
}
