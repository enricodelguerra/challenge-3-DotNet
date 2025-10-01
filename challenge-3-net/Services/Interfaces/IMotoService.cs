using challenge_3_net.Models.DTOs;

namespace challenge_3_net.Services.Interfaces
{
    /// <summary>
    /// Interface para serviço de motos
    /// </summary>
    public interface IMotoService
    {
        /// <summary>
        /// Obtém todas as motos com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de motos</returns>
        Task<PagedResultDto<MotoResponseDto>> ObterTodasAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Obtém moto por ID
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <returns>Moto encontrada ou null</returns>
        Task<MotoResponseDto?> ObterPorIdAsync(long id);

        /// <summary>
        /// Cria uma nova moto
        /// </summary>
        /// <param name="dto">Dados da moto</param>
        /// <returns>Moto criada</returns>
        Task<MotoResponseDto> CriarAsync(CriarMotoDto dto);

        /// <summary>
        /// Atualiza uma moto existente
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <param name="dto">Dados atualizados</param>
        /// <returns>Moto atualizada ou null se não encontrada</returns>
        Task<MotoResponseDto?> AtualizarAsync(long id, AtualizarMotoDto dto);

        /// <summary>
        /// Exclui uma moto
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <returns>True se excluída com sucesso</returns>
        Task<bool> ExcluirAsync(long id);

        /// <summary>
        /// Verifica se moto existe
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <returns>True se existe</returns>
        Task<bool> ExisteAsync(long id);

        /// <summary>
        /// Obtém moto por placa
        /// </summary>
        /// <param name="placa">Placa da moto</param>
        /// <returns>Moto encontrada ou null</returns>
        Task<MotoResponseDto?> ObterPorPlacaAsync(string placa);

        /// <summary>
        /// Obtém moto por chassi
        /// </summary>
        /// <param name="chassi">Chassi da moto</param>
        /// <returns>Moto encontrada ou null</returns>
        Task<MotoResponseDto?> ObterPorChassiAsync(string chassi);

        /// <summary>
        /// Obtém motos por usuário
        /// </summary>
        /// <param name="usuarioId">ID do usuário</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Lista paginada de motos do usuário</returns>
        Task<PagedResultDto<MotoResponseDto>> ObterPorUsuarioAsync(long usuarioId, int pageNumber, int pageSize);
    }
}
