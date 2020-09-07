using System.Threading.Tasks;
using e_descarte_api.Models;

namespace e_descarte_api.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //PONTO DESCARTE
        Task<PontoDescarte[]> GetAllPontosDescarteAsync();        
        Task<PontoDescarte> GetPontoDescarteAsyncById(int pontodescarteId);
    }
}