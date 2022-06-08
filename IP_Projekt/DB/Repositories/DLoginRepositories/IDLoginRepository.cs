using IP_Projekt.DB.Models;

namespace IP_Projekt.DB.Repositories.DLoginRepositories
{
    public interface IDLoginRepository
    {
        void Add(DLogin dLogin);
        void Update(int id, DLogin dLogin);
        DLogin Get(int id);
        IQueryable<DLogin> GetAll();
        void Delete(int id);
    }
}
