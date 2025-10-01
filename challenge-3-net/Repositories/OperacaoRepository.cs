using Microsoft.EntityFrameworkCore;
using challenge_3_net.Data;
using challenge_3_net.Models;
using challenge_3_net.Repositories.Interfaces;

namespace challenge_3_net.Repositories
{
    /// <summary>
    /// Implementação do repositório de operações
    /// </summary>
    public class OperacaoRepository : Repository<Operacao>, IOperacaoRepository
    {
        public OperacaoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Operacao>> GetByMotoIdAsync(long motoId)
        {
            return await _dbSet
                .Include(o => o.Moto)
                .Include(o => o.Usuario)
                .Where(o => o.MotoId == motoId)
                .OrderByDescending(o => o.DataOperacao)
                .ToListAsync();
        }

        public async Task<IEnumerable<Operacao>> GetByUsuarioIdAsync(long usuarioId)
        {
            return await _dbSet
                .Include(o => o.Moto)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == usuarioId)
                .OrderByDescending(o => o.DataOperacao)
                .ToListAsync();
        }

        public async Task<IEnumerable<Operacao>> GetByTipoOperacaoAsync(TipoOperacao tipoOperacao)
        {
            return await _dbSet
                .Include(o => o.Moto)
                .Include(o => o.Usuario)
                .Where(o => o.TipoOperacao == tipoOperacao)
                .OrderByDescending(o => o.DataOperacao)
                .ToListAsync();
        }

        public async Task<IEnumerable<Operacao>> GetByPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await _dbSet
                .Include(o => o.Moto)
                .Include(o => o.Usuario)
                .Where(o => o.DataOperacao >= dataInicio && o.DataOperacao <= dataFim)
                .OrderByDescending(o => o.DataOperacao)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Operacao> Items, long TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
                .Include(o => o.Moto)
                .Include(o => o.Usuario)
                .AsQueryable();
                
            var totalCount = await query.LongCountAsync();
            
            var items = await query
                .OrderByDescending(o => o.DataOperacao)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<(IEnumerable<Operacao> Items, long TotalCount)> GetPagedByMotoIdAsync(long motoId, int pageNumber, int pageSize)
        {
            var query = _dbSet
                .Include(o => o.Moto)
                .Include(o => o.Usuario)
                .Where(o => o.MotoId == motoId)
                .AsQueryable();
                
            var totalCount = await query.LongCountAsync();
            
            var items = await query
                .OrderByDescending(o => o.DataOperacao)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<(IEnumerable<Operacao> Items, long TotalCount)> GetPagedByUsuarioIdAsync(long usuarioId, int pageNumber, int pageSize)
        {
            var query = _dbSet
                .Include(o => o.Moto)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == usuarioId)
                .AsQueryable();
                
            var totalCount = await query.LongCountAsync();
            
            var items = await query
                .OrderByDescending(o => o.DataOperacao)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
