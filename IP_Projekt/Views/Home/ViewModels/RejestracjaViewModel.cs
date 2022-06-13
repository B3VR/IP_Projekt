using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Projekt.Views.Home.ViewModels
{
    public class RejestracjaViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string haslo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(haslo), ErrorMessage = "Przy potwierdzaniu wpisz takie samo hasło jak w polu powyżej")]
        public string potwierdz_haslo { get; set; }


    }
}
