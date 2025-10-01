using challenge_3_net.Models;
using challenge_3_net.Models.DTOs;

namespace challenge_3_net.Services.Interfaces
{
    /// <summary>
    /// Interface para serviço de status de motos
    /// </summary>
    public interface IStatusMotoService
    {
        /// <summary>
        /// Obtém todos os status com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de status</returns>
        Task<PagedResultDto<StatusMotoResponseDto>> ObterTodosAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Obtém status por ID
        /// </summary>
        /// <param name="id">ID do status</param>
        /// <returns>Status encontrado ou null</returns>
        Task<StatusMotoResponseDto?> ObterPorIdAsync(long id);

        /// <summary>
        /// Cria um novo status
        /// </summary>
        /// <param name="dto">Dados do status</param>
        /// <returns>Status criado</returns>
        Task<StatusMotoResponseDto> CriarAsync(CriarStatusMotoDto dto);

        /// <summary>
        /// Atualiza um status existente
        /// </summary>
        /// <param name="id">ID do status</param>
        /// <param name="dto">Dados atualizados</param>
        /// <returns>Status atualizado ou null se não encontrado</returns>
        Task<StatusMotoResponseDto?> AtualizarAsync(long id, AtualizarStatusMotoDto dto);

        /// <summary>
        /// Exclui um status
        /// </summary>
        /// <param name="id">ID do status</param>
        /// <returns>True se excluído com sucesso</returns>
        Task<bool> ExcluirAsync(long id);

        /// <summary>
        /// Verifica se status existe
        /// </summary>
        /// <param name="id">ID do status</param>
        /// <returns>True se existe</returns>
        Task<bool> ExisteAsync(long id);

        /// <summary>
        /// Obtém status atual de uma moto
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <returns>Status atual da moto ou null</returns>
        Task<StatusMotoResponseDto?> ObterStatusAtualAsync(long motoId);

        /// <summary>
        /// Obtém histórico de status de uma moto
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de status da moto</returns>
        Task<PagedResultDto<StatusMotoResponseDto>> ObterHistoricoPorMotoAsync(long motoId, int pageNumber, int pageSize);

        /// <summary>
        /// Obtém status por tipo
        /// </summary>
        /// <param name="status">Status a buscar</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de status do tipo</returns>
        Task<PagedResultDto<StatusMotoResponseDto>> ObterPorStatusAsync(StatusMotoEnum status, int pageNumber, int pageSize);
    }
}
