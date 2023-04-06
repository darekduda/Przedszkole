using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.CMS
{
    public class HarmonogramDzienny
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł nagłówka")]
        [MaxLength(400, ErrorMessage = "Nagłówek powinien zawierać maksymalnie 150 znaków")]
        [Display(Name = "Tytuł")]
        public string? Tytul { get; set; }

        [Required(ErrorMessage = "Wpisz opis")]
        [MaxLength(400, ErrorMessage = "Opis powinien zawierać maksymalnie 150 znaków")]
        [Display(Name = "Opis")]
        public string? Opis { get; set; }

        [Required(ErrorMessage = "Wpisz godzinę rozpoczęcia zajęć")]
        [Display(Name = "Godzina rozpoczęcia")]
        public String? GodzinaRozpoczecia { get; set; }

        [Required(ErrorMessage = "Wpisz godzinę zakończenia zajęć")]
        [Display(Name = "Godzina zakończenia")]
        public String? GodzinaZakonczenia { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
    }
}
