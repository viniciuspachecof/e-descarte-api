using System.Threading.Tasks;
using e_descarte_api.Models;

namespace e_descarte_api.Data
{
    public interface IRepository
    {
        // GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // USUÁRIO
        Task<Usuario[]> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioAsyncById(int usuarioId);
        Task<Usuario> GetUsuarioAsyncByNamePassword(string email, string senha);

        // PONTO DESCARTE
        Task<PontoDescarte[]> GetAllPontosDescarteAsync(bool includeCidade, bool includeUsuario);
        Task<PontoDescarte> GetPontoDescarteAsyncById(int pontodescarteId, bool includeCidade, bool includeUsuario);

        // ITEM
        Task<Item[]> GetAllItensAsync();
        Task<Item> GetItemAsyncById(int itemId);

        // PONTO DESCARTE ITEM
        Task<PontoDescarteItem[]> GetAllPontoDescarteItensAsync(bool includePontoDescarte, bool includeItem, bool includeCidade, bool includeUsuario);
        Task<PontoDescarteItem> GetPontoDescarteItemAsyncById(int pontodescarteitemId, bool includePontoDescarte, bool includeItem, bool includeCidade, bool includeUsuario);
        Task<PontoDescarteItem[]> GetPontoDescarteItensAsyncByPontoDescarteId(int pontodescarteId, bool includePontoDescarte, bool includeItem, bool includeCidade, bool includeUsuario);
        Task<PontoDescarteItem[]> GetPontoDescarteItensAsyncByPontoDescarteUsuarioId(int pontodescarteId, int usuarioId, bool includePontoDescarte, bool includeItem, bool includeCidade, bool includeUsuario);

        // CIDADE
        Task<Cidade[]> GetAllCidadesAsync();
        Task<Cidade> GetCidadeAsyncById(int cidadeId);
    }
}