using challenge_3_net.Models;
using challenge_3_net.Models.DTOs;

namespace challenge_3_net.Services.Interfaces
{
    /// <summary>
    /// Interface para serviço de operações
    /// </summary>
    public interface IOperacaoService
    {
        /// <summary>
        /// Obtém todas as operações com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de operações</returns>
        Task<PagedResultDto<OperacaoResponseDto>> ObterTodosAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Obtém operação por ID
        /// </summary>
        /// <param name="id">ID da operação</param>
        /// <returns>Operação encontrada ou null</returns>
        Task<OperacaoResponseDto?> ObterPorIdAsync(long id);

        /// <summary>
        /// Cria uma nova operação
        /// </summary>
        /// <param name="dto">Dados da operação</param>
        /// <returns>Operação criada</returns>
        Task<OperacaoResponseDto> CriarAsync(CriarOperacaoDto dto);

        /// <summary>
        /// Atualiza uma operação existente
        /// </summary>
        /// <param name="id">ID da operação</param>
        /// <param name="dto">Dados atualizados</param>
        /// <returns>Operação atualizada ou null se não encontrada</returns>
        Task<OperacaoResponseDto?> AtualizarAsync(long id, AtualizarOperacaoDto dto);

        /// <summary>
        /// Exclui uma operação
        /// </summary>
        /// <param name="id">ID da operação</param>
        /// <returns>True se excluída com sucesso</returns>
        Task<bool> ExcluirAsync(long id);

        /// <summary>
        /// Verifica se operação existe
        /// </summary>
        /// <param name="id">ID da operação</param>
        /// <returns>True se existe</returns>
        Task<bool> ExisteAsync(long id);

        /// <summary>
        /// Obtém operações por moto
        /// </summary>
        /// <param name="motoId">ID da moto</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de operações da moto</returns>
        Task<PagedResultDto<OperacaoResponseDto>> ObterPorMotoAsync(long motoId, int pageNumber, int pageSize);

        /// <summary>
        /// Obtém operações por usuário
        /// </summary>
        /// <param name="usuarioId">ID do usuário</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de operações do usuário</returns>
        Task<PagedResultDto<OperacaoResponseDto>> ObterPorUsuarioAsync(long usuarioId, int pageNumber, int pageSize);

        /// <summary>
        /// Obtém operações por tipo
        /// </summary>
        /// <param name="tipoOperacao">Tipo da operação</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de operações do tipo</returns>
        Task<PagedResultDto<OperacaoResponseDto>> ObterPorTipoAsync(TipoOperacao tipoOperacao, int pageNumber, int pageSize);
    }
}
