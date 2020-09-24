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

        // PONTO DESCARTE
        Task<PontoDescarte[]> GetAllPontosDescarteAsync(bool includeItem);
        Task<PontoDescarte> GetPontoDescarteAsyncById(int pontodescarteId, bool includeItem);

        // ITEM
        Task<Item[]> GetAllItensAsync(bool includePontoDescarte);
        Task<Item> GetItemAsyncById(int itemId, bool includePontoDescarte);

        // PONTO DESCARTE ITEM
        Task<PontoDescarteItem[]> GetAllPontoDescarteItensAsync(bool includePontoDescarte, bool includeItem);
        Task<PontoDescarteItem> GetPontoDescarteItemAsyncById(int pontodescarteitemId, bool includePontoDescarte, bool includeItem);
    }
}