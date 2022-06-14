using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;



namespace IP_Projekt.DB.Models


{
    public class Badania
    {
        public int BadanieId { get; set; }
       // [DisplayName("Nazwa")]
        public string Nazwa { get; set; }
        public string Lekarz { get; set; }

        public string Sala { get; set; }

        public string Godzina { get; set; }

        public string Pacjent { get; set; }

        //[DisplayName("Opis")]
        public string Opis{ get; set; }
        public bool Done { get; set; }
    }
}
