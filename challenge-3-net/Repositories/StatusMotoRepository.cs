using Microsoft.EntityFrameworkCore;
using challenge_3_net.Data;
using challenge_3_net.Models;
using challenge_3_net.Repositories.Interfaces;

namespace challenge_3_net.Repositories
{
    /// <summary>
    /// Implementação do repositório de status de motos
    /// </summary>
    public class StatusMotoRepository : Repository<StatusMoto>, IStatusMotoRepository
    {
        public StatusMotoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<StatusMoto?> GetStatusAtualAsync(long motoId)
        {
            return await _dbSet
                .Include(s => s.Moto)
                .Include(s => s.Usuario)
                .Where(s => s.MotoId == motoId)
                .OrderByDescending(s => s.DataStatus)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StatusMoto>> GetHistoricoByMotoIdAsync(long motoId)
        {
            return await _dbSet
                .Include(s => s.Moto)
                .Include(s => s.Usuario)
                .Where(s => s.MotoId == motoId)
                .OrderByDescending(s => s.DataStatus)
                .ToListAsync();
        }

        public async Task<IEnumerable<StatusMoto>> GetByStatusAsync(StatusMotoEnum status)
        {
            return await _dbSet
                .Include(s => s.Moto)
                .Include(s => s.Usuario)
                .Where(s => s.Status == status)
                .OrderByDescending(s => s.DataStatus)
                .ToListAsync();
        }

        public async Task<IEnumerable<StatusMoto>> GetByAreaAsync(string area)
        {
            return await _dbSet
                .Include(s => s.Moto)
                .Include(s => s.Usuario)
                .Where(s => s.Area == area)
                .OrderByDescending(s => s.DataStatus)
                .ToListAsync();
        }

        public async Task<IEnumerable<StatusMoto>> GetByPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await _dbSet
                .Include(s => s.Moto)
                .Include(s => s.Usuario)
                .Where(s => s.DataStatus >= dataInicio && s.DataStatus <= dataFim)
                .OrderByDescending(s => s.DataStatus)
                .ToListAsync();
        }

        public async Task<(IEnumerable<StatusMoto> Items, long TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
                .Include(s => s.Moto)
                .Include(s => s.Usuario)
                .AsQueryable();
                
            var totalCount = await query.LongCountAsync();
            
            var items = await query
                .OrderByDescending(s => s.DataStatus)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<(IEnumerable<StatusMoto> Items, long TotalCount)> GetPagedByMotoIdAsync(long motoId, int pageNumber, int pageSize)
        {
            var query = _dbSet
                .Include(s => s.Moto)
                .Include(s => s.Usuario)
                .Where(s => s.MotoId == motoId)
                .AsQueryable();
                
            var totalCount = await query.LongCountAsync();
            
            var items = await query
                .OrderByDescending(s => s.DataStatus)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
