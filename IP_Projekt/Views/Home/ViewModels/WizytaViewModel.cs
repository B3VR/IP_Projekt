using IP_Projekt.DB.Models;

namespace IP_Projekt.Views.Home.ViewModels
{
    public class WizytaViewModel
    {
        public User user { get; set; }
        public IP_Projekt.DB.Models.Wizyta wizyta;
        public string imiePacjenta;
        public string imieLekarza;
        public string Opis { get; set; }
        public string Przebieg_wizyty { get; set; }
        public string Przepisane_leki { get; set; }
        public int Stwierdzona_choroba { get; set; }

        public int wizyta_id { get; set; }
    }
}
