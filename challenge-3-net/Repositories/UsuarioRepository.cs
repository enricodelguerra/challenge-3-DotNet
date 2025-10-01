using Microsoft.EntityFrameworkCore;
using challenge_3_net.Data;
using challenge_3_net.Models;
using challenge_3_net.Repositories.Interfaces;

namespace challenge_3_net.Repositories
{
    /// <summary>
    /// Implementação do repositório de usuários
    /// </summary>
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> GetByCnpjAsync(string cnpj)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.Cnpj == cnpj);
        }

        public async Task<bool> EmailExistsAsync(string email, long? excludeId = null)
        {
            var query = _dbSet.Where(u => u.Email == email);
            
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> CnpjExistsAsync(string cnpj, long? excludeId = null)
        {
            var query = _dbSet.Where(u => u.Cnpj == cnpj);
            
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<(IEnumerable<Usuario> Items, long TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet.AsQueryable();
            var totalCount = await query.LongCountAsync();
            
            var items = await query
                .OrderBy(u => u.NomeFilial)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
