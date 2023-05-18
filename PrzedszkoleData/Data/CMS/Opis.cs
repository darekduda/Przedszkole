using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.CMS
{
    public class Opis
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł ")]
        [MaxLength(150, ErrorMessage = "Nagłówek powinien zawierać maksymalnie 150 znaków")]
        [Display(Name = "Tytół")]
        public string? Tytul { get; set; }

        [Required(ErrorMessage = "Wpisz opis")]
        [MaxLength(150, ErrorMessage = "Opis powinien zawierać maksymalnie 150 znaków")]
        [Display(Name = "Opis")]
        public string? Nazwa { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
    }
}
