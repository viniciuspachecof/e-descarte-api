using System.Linq;
using System.Threading.Tasks;
using e_descarte_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_descarte_api.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //PONTO DESCARTE
        public async Task<PontoDescarte[]> GetAllPontosDescarteAsync()
        {
            IQueryable<PontoDescarte> query = _context.pontodescarte;

            query = query.AsNoTracking()
                         .OrderBy(pontodescarte => pontodescarte.id);

            return await query.ToArrayAsync();
        }

        public async Task<PontoDescarte> GetPontoDescarteAsyncById(int pontodescarteId)
        {
            IQueryable<PontoDescarte> query = _context.pontodescarte;

            query = query.AsNoTracking()
                         .OrderBy(pontodescarte => pontodescarte.id)
                         .Where(pontodescarte => pontodescarte.id == pontodescarteId);

            return await query.FirstOrDefaultAsync();
        }

    }
}