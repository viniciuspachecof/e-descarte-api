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

        public async Task<Usuario> GetUsuarioAsyncByNamePassword(string email, string senha)
        {
            IQueryable<Usuario> query = _context.usuario;

            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario.id)                         
                         .Where(usuario => usuario.email == email && usuario.senha == senha);

            return await query.FirstOrDefaultAsync();
        }

        // PONTO DESCARTE
        public async Task<PontoDescarte[]> GetAllPontosDescarteAsync(bool includeCidade, bool includeUsuario)
        {
            IQueryable<PontoDescarte> query = _context.pontodescarte;

            if (includeCidade)
            {
                query = query.Include(pd => pd.cidade);
            }

            if (includeUsuario)
            {
                query = query.Include(pd => pd.usuario);
            }

            query = query.AsNoTracking()
                         .OrderBy(pontodescarte => pontodescarte.id);

            return await query.ToArrayAsync();
        }

        public async Task<PontoDescarte> GetPontoDescarteAsyncById(int pontodescarteId, bool includeCidade, bool includeUsuario)
        {
            IQueryable<PontoDescarte> query = _context.pontodescarte;
       
            if (includeCidade)
            {
                query = query.Include(pd => pd.cidade);
            }

            if (includeUsuario)
            {
                query = query.Include(pd => pd.usuario);
            }

            query = query.AsNoTracking()
                         .OrderBy(pontodescarte => pontodescarte.id)
                         .Where(pontodescarte => pontodescarte.id == pontodescarteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PontoDescarte[]> GetPontoDescarteAsyncByUsuarioId(int usuarioId, bool includeCidade, bool includeUsuario)
        {
            IQueryable<PontoDescarte> query = _context.pontodescarte;
       
            if (includeCidade)
            {
                query = query.Include(pd => pd.cidade);
            }

            if (includeUsuario)
            {
                query = query.Include(pd => pd.usuario);
            }

            query = query.AsNoTracking()
                         .OrderBy(pontodescarte => pontodescarte.id)
                         .Where(pontodescarte => pontodescarte.usuarioId == usuarioId);

            return await query.ToArrayAsync();
        }
        
        // ITEM
        public async Task<Item[]> GetAllItensAsync()
        {
            IQueryable<Item> query = _context.item;

            query = query.AsNoTracking()
                         .OrderBy(item => item.id);

            return await query.ToArrayAsync();
        }

        public async Task<Item> GetItemAsyncById(int itemId)
        {
            IQueryable<Item> query = _context.item;

            query = query.AsNoTracking()
                         .OrderBy(item => item.id)
                         .Where(item => item.id == itemId);

            return await query.FirstOrDefaultAsync();
        }

        // PONTO DESCARTE ITEM
        public async Task<PontoDescarteItem[]> GetAllPontoDescarteItensAsync(bool includePontoDescarte, bool includeItem, bool includeCidade, bool includeUsuario)
        {
            IQueryable<PontoDescarteItem> query = _context.pontodescarteitem;

            if (includePontoDescarte)
            {
                query = query.Include(pdt => pdt.pontodescarte);
            }

            if (includeCidade)
            {
                query = query.Include(pdt => pdt.pontodescarte)
                             .ThenInclude(pd => pd.cidade);
            }

            if (includeItem)
            {
                query = query.Include(pdt => pdt.item);
            }

            if (includeUsuario)
            {
                query = query.Include(pdt => pdt.usuario);
            }

            query = query.AsNoTracking()
                         .OrderBy(pontodescarteitem => pontodescarteitem.id);

            return await query.ToArrayAsync();
        }

        public async Task<PontoDescarteItem> GetPontoDescarteItemAsyncById(int pontodescarteitemId, bool includePontoDescarte, bool includeItem, bool includeCidade, bool includeUsuario)
        {
            IQueryable<PontoDescarteItem> query = _context.pontodescarteitem;

            if (includePontoDescarte)
            {
                query = query.Include(pdt => pdt.pontodescarte);
            }

            if (includeCidade)
            {
                query = query.Include(pdt => pdt.pontodescarte)
                             .ThenInclude(pd => pd.cidade);
            }

            if (includeItem)
            {
                query = query.Include(pdt => pdt.item);
            }

            if (includeUsuario)
            {
                query = query.Include(pdt => pdt.usuario);
            }

            query = query.AsNoTracking()
                         .OrderBy(pontodescarteitem => pontodescarteitem.id)
                         .Where(pontodescarteitem => pontodescarteitem.id == pontodescarteitemId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PontoDescarteItem[]> GetPontoDescarteItensAsyncByPontoDescarteId(int pontodescarteId, bool includePontoDescarte, bool includeItem, bool includeCidade, bool includeUsuario)
        {
            IQueryable<PontoDescarteItem> query = _context.pontodescarteitem;

            if (includePontoDescarte)
            {
                query = query.Include(pdt => pdt.pontodescarte);
            }

            if (includeCidade)
            {
                query = query.Include(pdt => pdt.pontodescarte)
                             .ThenInclude(pd => pd.cidade);
            }

            if (includeItem)
            {
                query = query.Include(pdt => pdt.item);
            }

            if (includeUsuario)
            {
                query = query.Include(pdt => pdt.usuario);
            }

            query = query.AsNoTracking()
                         .OrderBy(pdt => pdt.id)                         
                         .Where(pdt => pdt.pontodescarteId == pontodescarteId);

            return await query.ToArrayAsync();
        }

        public async Task<PontoDescarteItem[]> GetPontoDescarteItensAsyncByPontoDescarteUsuarioId(int pontodescarteId, int usuarioId, bool includePontoDescarte, bool includeItem, bool includeCidade, bool includeUsuario)
        {
            IQueryable<PontoDescarteItem> query = _context.pontodescarteitem;

            if (includePontoDescarte)
            {
                query = query.Include(pdt => pdt.pontodescarte);
            }

            if (includeCidade)
            {
                query = query.Include(pdt => pdt.pontodescarte)
                             .ThenInclude(pd => pd.cidade);
            }

            if (includeItem)
            {
                query = query.Include(pdt => pdt.item);
            }

            if (includeUsuario)
            {
                query = query.Include(pdt => pdt.usuario);
            }

            query = query.AsNoTracking()
                         .OrderBy(pdt => pdt.id)                         
                         .Where(pdt => pdt.pontodescarteId == pontodescarteId && pdt.usuarioId == usuarioId);

            return await query.ToArrayAsync();
        }       

        // CIDADE
        public async Task<Cidade[]> GetAllCidadesAsync()
        {
            IQueryable<Cidade> query = _context.cidade;
        
            query = query.AsNoTracking()
                         .OrderBy(cidade => cidade.id);

            return await query.ToArrayAsync();
        }

        public async Task<Cidade> GetCidadeAsyncById(int cidadeId)
        {
            IQueryable<Cidade> query = _context.cidade;
        
            query = query.AsNoTracking()
                         .OrderBy(cidade => cidade.id)
                         .Where(cidade => cidade.id == cidadeId);

            return await query.FirstOrDefaultAsync();
        }

    }
}