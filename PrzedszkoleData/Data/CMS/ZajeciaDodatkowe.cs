using PrzedszkoleData.Data.Manage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.CMS
{
    public class ZajeciaDodatkowe
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł zajęcia")]
        [MaxLength(400, ErrorMessage = "Tytuł powinien zawierać maksymalnie 400 znaków")]
        [Display(Name = "Tytuł")]
        public string? Tytul { get; set; }

        [Required(ErrorMessage = "Wpisz opis zajęci")]
        [MaxLength(1200, ErrorMessage = "Opis powinien zawierać maksymalnie 1200 znaków")]
        [Display(Name = "Opis")]
        public string? Opis { get; set; }

        [Required(ErrorMessage = "Wpisz cene za jedne zajęcia")]
        [Display(Name = "Cena")]
        [DisplayFormat(DataFormatString = "{0:#}")]
        public decimal? Cena { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }

    }
}
