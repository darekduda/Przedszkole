using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.CMS
{
    public class Nazwa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł strony")]
        [MaxLength(150, ErrorMessage = "Tytul powinien zawierać maksymalnie 150 znaków")]
        [Display(Name = "Tytuł")]
        public string? Tytul { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
    }
}
