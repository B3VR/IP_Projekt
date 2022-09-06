using IP_Projekt.DB;
using IP_Projekt.DB.Models;
using IP_Projekt.DB.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IP_Projekt.Views.NowaWizyta.ViewModel
{
    public class NowaWizytaViewModel
    {
        public SelectList lekarze;
        [Required]
        public string lekarzId { get; set; }
        public RodzajPoradniEnum rodzajPoradni { get; set; }
        [Required]
        public string opisObjawow { get; set; }
        [Required]
        [BindProperty]
        public DateTime dataWizyty { get; set; }

    }
}
