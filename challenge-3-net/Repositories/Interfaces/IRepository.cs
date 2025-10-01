using System.Linq.Expressions;

namespace challenge_3_net.Repositories.Interfaces
{
    /// <summary>
    /// Interface base para repositórios seguindo o padrão Repository
    /// </summary>
    /// <typeparam name="T">Tipo da entidade</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtém uma entidade por ID
        /// </summary>
        /// <param name="id">ID da entidade</param>
        /// <returns>Entidade encontrada ou null</returns>
        Task<T?> GetByIdAsync(long id);

        /// <summary>
        /// Obtém todas as entidades
        /// </summary>
        /// <returns>Lista de entidades</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Obtém entidades com filtro
        /// </summary>
        /// <param name="predicate">Expressão de filtro</param>
        /// <returns>Lista de entidades filtradas</returns>
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Obtém a primeira entidade que atende ao filtro
        /// </summary>
        /// <param name="predicate">Expressão de filtro</param>
        /// <returns>Primeira entidade encontrada ou null</returns>
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adiciona uma nova entidade
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        /// <returns>Entidade adicionada</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Atualiza uma entidade existente
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada</param>
        /// <returns>Entidade atualizada</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Remove uma entidade
        /// </summary>
        /// <param name="entity">Entidade a ser removida</param>
        /// <returns>True se removida com sucesso</returns>
        Task<bool> RemoveAsync(T entity);

        /// <summary>
        /// Remove uma entidade por ID
        /// </summary>
        /// <param name="id">ID da entidade</param>
        /// <returns>True se removida com sucesso</returns>
        Task<bool> RemoveByIdAsync(long id);

        /// <summary>
        /// Verifica se existe uma entidade com o ID especificado
        /// </summary>
        /// <param name="id">ID da entidade</param>
        /// <returns>True se existe</returns>
        Task<bool> ExistsAsync(long id);

        /// <summary>
        /// Conta o total de entidades
        /// </summary>
        /// <returns>Total de entidades</returns>
        Task<long> CountAsync();

        /// <summary>
        /// Conta entidades com filtro
        /// </summary>
        /// <param name="predicate">Expressão de filtro</param>
        /// <returns>Total de entidades filtradas</returns>
        Task<long> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
