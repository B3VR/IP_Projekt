using IP_Projekt.DB.Models;
using IP_Projekt.DB.Models.Enums;

namespace IP_Projekt.DB.Repositories.WizytaRepositories
{
    public class WizytaRepository : IWizytaRepository
    {
        readonly IpprojContext _ipprojContext;

        public WizytaRepository(IpprojContext ipprojContext)
        {
            _ipprojContext = ipprojContext;
        }

        public void Add(Wizyta wizyta)
        {
            _ipprojContext.Add(wizyta);
            _ipprojContext.SaveChanges();
        }

        public Wizyta pobierzWizyte(int id) => _ipprojContext.wizyty.SingleOrDefault(x => x.id == id);

        public Wizyta pobierzAktualnaWizyteLekarza(string idLekarza)
        {
            throw new NotImplementedException();
        }

        public Wizyta pobierzAktualnaWizytePacjenta(string idPacjenta)
        {
            throw new NotImplementedException();
        }

        public ICollection<Wizyta> pobierzWizytyLekarza(string idLekarza)
        {
            return _ipprojContext.wizyty.Where(x => x.lekarzId == idLekarza).ToList();
        }

        public ICollection<Wizyta> pobierzWizytyPacjenta(string idPacjenta)
        {
            var lista = _ipprojContext.wizyty.Where(x => x.pacjentId == idPacjenta);
            return lista.ToList();
        }

        public void rozpocznijWizyte(int id)
        {
            Wizyta wizyta = _ipprojContext.wizyty.SingleOrDefault(x => x.id == id);
            wizyta.status = statusWizytyEnum.wTrakie;

            _ipprojContext.SaveChanges();
        }

        public void usunWizyte(int id)
        {
            throw new NotImplementedException();
        }

        public void zamknijWizyte(int id)
        {
            Wizyta wizyta = _ipprojContext.wizyty.SingleOrDefault(x => x.id == id);
            wizyta.status = statusWizytyEnum.zakonczona;

            _ipprojContext.SaveChanges();
        }
    }
}
