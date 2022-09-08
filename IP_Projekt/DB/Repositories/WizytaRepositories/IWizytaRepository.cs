using IP_Projekt.DB.Models;

namespace IP_Projekt.DB.Repositories.WizytaRepositories
{
    public interface IWizytaRepository
    {
        public void Add(Wizyta wizyta);
        public void zamknijWizyte(int id);
        public void rozpocznijWizyte(int id);
        public void usunWizyte(int id);
        public ICollection<Wizyta> pobierzWizytyPacjenta(string idPacjenta);
        public ICollection<Wizyta> pobierzWizytyLekarza(string idLekarza);
        public Wizyta pobierzAktualnaWizytePacjenta(string idPacjenta);
        public Wizyta pobierzAktualnaWizyteLekarza(string idLekarza);

        public Wizyta pobierzWizyte(int id);
    }
}
