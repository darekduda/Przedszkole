using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.CMS
{
    public class Adres
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Kod pocztowy powinien zawierać maksymalnie 5 znaków")]
        [Display(Name = "Kod pocztowy")]
        public string? KodPocztowy { get; set; }

        [MaxLength(50, ErrorMessage = "Miasto powinno zawierać maksymalnie 50 znaków")]
        [Display(Name = "Miasto")]
        public string? Miasto { get; set; }

        [MaxLength(50, ErrorMessage = "Ulica powinna zawierać maksymalnie 50 znaków")]
        [Display(Name = "Ulica")]
        public string? Ulica { get; set; }

        [MaxLength(10, ErrorMessage = "Numer budynku powinien zawierać maksymalnie 10 znaków")]
        [Display(Name = "Numer budynku")]
        public string? NumerBudynku { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
    }
}
