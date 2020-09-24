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

        // USUÁRIO
        public async Task<Usuario[]> GetAllUsuariosAsync()
        {
            IQueryable<Usuario> query = _context.usuario;

            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario.id);

            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioAsyncById(int usuarioId)
        {
            IQueryable<Usuario> query = _context.usuario;

            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario.id)
                         .Where(usuario => usuario.id == usuarioId);

            return await query.FirstOrDefaultAsync();
        }

        // PONTO DESCARTE
        public async Task<PontoDescarte[]> GetAllPontosDescarteAsync(bool includeItem)
        {
            IQueryable<PontoDescarte> query = _context.pontodescarte;

            if (includeItem)
            {
                query = query.Include(pd => pd.pontodescarteitem)
                             .ThenInclude(pdt => pdt.item);
            }

            query = query.AsNoTracking()
                         .OrderBy(pontodescarte => pontodescarte.id);

            return await query.ToArrayAsync();
        }

        public async Task<PontoDescarte> GetPontoDescarteAsyncById(int pontodescarteId, bool includeItem)
        {
            IQueryable<PontoDescarte> query = _context.pontodescarte;

            if (includeItem)
            {
                query = query.Include(pd => pd.pontodescarteitem)
                             .ThenInclude(pdt => pdt.item);
            }

            query = query.AsNoTracking()
                         .OrderBy(pontodescarte => pontodescarte.id)
                         .Where(pontodescarte => pontodescarte.id == pontodescarteId);

            return await query.FirstOrDefaultAsync();
        }
        
        // ITEM
        public async Task<Item[]> GetAllItensAsync(bool includePontoDescarte)
        {
            IQueryable<Item> query = _context.item;

            if (includePontoDescarte)
            {
                query = query.Include(i => i.pontodescarteitem)
                             .ThenInclude(pdt => pdt.pontodescarte);
            }

            query = query.AsNoTracking()
                         .OrderBy(item => item.id);

            return await query.ToArrayAsync();
        }

        public async Task<Item> GetItemAsyncById(int itemId, bool includePontoDescarte)
        {
            IQueryable<Item> query = _context.item;

            if (includePontoDescarte)
            {
                query = query.Include(i => i.pontodescarteitem)
                             .ThenInclude(pdt => pdt.pontodescarte);
            }

            query = query.AsNoTracking()
                         .OrderBy(item => item.id)
                         .Where(item => item.id == itemId);

            return await query.FirstOrDefaultAsync();
        }

        // PONTO DESCARTE ITEM
        public async Task<PontoDescarteItem[]> GetAllPontoDescarteItensAsync(bool includePontoDescarte, bool includeItem)
        {
            IQueryable<PontoDescarteItem> query = _context.pontodescarteitem;

            if (includePontoDescarte)
            {
                query = query.Include(pdt => pdt.pontodescarte);
            }

            if (includeItem)
            {
                query = query.Include(pdt => pdt.item);
            }

            query = query.AsNoTracking()
                         .OrderBy(pontodescarteitem => pontodescarteitem.id);

            return await query.ToArrayAsync();
        }

        public async Task<PontoDescarteItem> GetPontoDescarteItemAsyncById(int pontodescarteitemId, bool includePontoDescarte, bool includeItem)
        {
            IQueryable<PontoDescarteItem> query = _context.pontodescarteitem;

            if (includePontoDescarte)
            {
                query = query.Include(pdt => pdt.pontodescarte);
            }

            if (includeItem)
            {
                query = query.Include(pdt => pdt.item);
            }

            query = query.AsNoTracking()
                         .OrderBy(pontodescarteitem => pontodescarteitem.id)
                         .Where(pontodescarteitem => pontodescarteitem.id == pontodescarteitemId);

            return await query.FirstOrDefaultAsync();
        }

    }
}