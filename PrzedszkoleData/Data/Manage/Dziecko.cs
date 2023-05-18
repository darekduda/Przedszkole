using PrzedszkoleData.Data.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.Manage
{
    public class Dziecko
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz imię dziecka")]
        [MaxLength(50, ErrorMessage = "Imię powinno zawierać maksymalnie 50 znaków")]
        [Display(Name = "Imię")]
        public string? Imie { get; set; }

        [Required(ErrorMessage = "Wpisz nazwisko dziecka")]
        [MaxLength(50, ErrorMessage = "Nazwisko powinno zawierać maksymalnie 50 znaków")]
        [Display(Name = "Nazwisko")]
        public string? Nazwisko { get; set; }

        [Required(ErrorMessage = "Wpisz datę urodzenia dziecka")]
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateTime DataUrodzenia { get; set; }
        public bool CzyAktywny { get; set; }

        public int? GrupaId { get; set; }
        public Grupa? Grupa { get; set; }
        public ICollection<DzieckoZajeciaDodatkowe> ZajeciaDodatkowe { get; set; }

    }
}
