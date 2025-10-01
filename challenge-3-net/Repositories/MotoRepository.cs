using Microsoft.EntityFrameworkCore;
using challenge_3_net.Data;
using challenge_3_net.Models;
using challenge_3_net.Repositories.Interfaces;

namespace challenge_3_net.Repositories
{
    /// <summary>
    /// Implementação do repositório de motos
    /// </summary>
    public class MotoRepository : Repository<Moto>, IMotoRepository
    {
        public MotoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Moto?> GetByPlacaAsync(string placa)
        {
            return await _dbSet
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Placa == placa);
        }

        public async Task<Moto?> GetByChassiAsync(string chassi)
        {
            return await _dbSet
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Chassi == chassi);
        }

        public async Task<bool> PlacaExistsAsync(string placa, long? excludeId = null)
        {
            var query = _dbSet.Where(m => m.Placa == placa);
            
            if (excludeId.HasValue)
            {
                query = query.Where(m => m.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> ChassiExistsAsync(string chassi, long? excludeId = null)
        {
            var query = _dbSet.Where(m => m.Chassi == chassi);
            
            if (excludeId.HasValue)
            {
                query = query.Where(m => m.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Moto>> GetByUsuarioIdAsync(long usuarioId)
        {
            return await _dbSet
                .Include(m => m.Usuario)
                .Where(m => m.UsuarioId == usuarioId)
                .OrderBy(m => m.Placa)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Moto> Items, long TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
                .Include(m => m.Usuario)
                .AsQueryable();
                
            var totalCount = await query.LongCountAsync();
            
            var items = await query
                .OrderBy(m => m.Placa)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<(IEnumerable<Moto> Items, long TotalCount)> GetPagedByUsuarioIdAsync(long usuarioId, int pageNumber, int pageSize)
        {
            var query = _dbSet
                .Include(m => m.Usuario)
                .Where(m => m.UsuarioId == usuarioId)
                .AsQueryable();
                
            var totalCount = await query.LongCountAsync();
            
            var items = await query
                .OrderBy(m => m.Placa)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
