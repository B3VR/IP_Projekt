using IP_Projekt.DB.Models;

namespace IP_Projekt.DB.Repositories.DLoginRepositories
{
    public class DLoginRepository : IDLoginRepository
    {
        private readonly IpprojContext ipprojContext;
        public DLoginRepository(IpprojContext ipprojContext)
        {
            this.ipprojContext = ipprojContext;
        }

        // Dodawanie jeszcze nie działa bo coś z kluczem głównym się pierdoli
        public void Add(DLogin dLogin)
        {
            ipprojContext.dLogins.Add(dLogin);
            ipprojContext.SaveChanges();
        }

        public void Delete(int id)
        {
            DLogin toDelete = ipprojContext.dLogins.SingleOrDefault(x => x.D_ID == id);

            if (toDelete != null)
            {
                ipprojContext.dLogins.Remove(toDelete);
                ipprojContext.SaveChanges();
            }
        }

        public DLogin Get(int id)
        {
            return ipprojContext.dLogins.SingleOrDefault(x => x.D_ID == id);
        }

        public IQueryable<DLogin> GetAll()
        {
            return ipprojContext.dLogins.Where(x => x.D_ID != null);
        }

        public void Update(int id, DLogin dLogin)
        {
            // szukamy rekordu o danym id
            DLogin toUpdate = ipprojContext.dLogins.SingleOrDefault(x => x.D_ID == id);

            if (toUpdate != null)
            {
                // przypisujemy do rekordu o danym id pola do zmiany i zapisujemy
                toUpdate.D_log = dLogin.D_log;
                toUpdate.D_pass = dLogin.D_pass;

                ipprojContext.SaveChanges();
            }
        }
    }
}
