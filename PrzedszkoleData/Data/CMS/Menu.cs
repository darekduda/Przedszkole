using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.CMS
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytół śniadania")]
        [MaxLength(300, ErrorMessage = "Tytuł powienien zawierać maksymalnie 300 znaków")]
        [Display(Name = "Tytuł śniadania")]
        public string? TytulSniadania { get; set; }

        [Required(ErrorMessage = "Wpisz opis śniadania")]
        [MaxLength(600, ErrorMessage = "Opis powinien zawierać maksymalnie 600 znaków")]
        [Display(Name = "Opis śniadania")]
        public string? OpisSniadania { get; set; }

        [Required(ErrorMessage = "Wpisz tytół pierwszego dania")]
        [MaxLength(300, ErrorMessage = "Tytuł powienien zawierać maksymalnie 300 znaków")]
        [Display(Name = "Pierwsze danie")]
        public string? TytulPierwszegoDania { get; set; }

        [Required(ErrorMessage = "Wpisz opis pierwszego dania")]
        [MaxLength(600, ErrorMessage = "Opis powinien zawierać maksymalnie 600 znaków")]
        [Display(Name = "Opis pierwszego dania")]
        public string? OpisPierwszegoDania { get; set; }

        [Required(ErrorMessage = "Wpisz tytół drugiego dania")]
        [MaxLength(300, ErrorMessage = "Tytuł powienien zawierać maksymalnie 300 znaków")]
        [Display(Name = "Tytuł drugiego dania")]
        public string? TytulDrugiegoDania { get; set; }

        [Required(ErrorMessage = "Wpisz opis drugiego dania")]
        [MaxLength(600, ErrorMessage = "Opis powinien zawierać maksymalnie 600 znaków")]
        [Display(Name = "Opis drugiego dania")]
        public string? OpisDrugiegoDania { get; set; }

        [Required(ErrorMessage = "Wpisz tytół podwieczorku")]
        [MaxLength(300, ErrorMessage = "Tytuł powienien zawierać maksymalnie 300 znaków")]
        [Display(Name = "Tytuł powieczorku")]
        public string? TytulPodwieczorku { get; set; }

        [Required(ErrorMessage = "Wpisz opis powieczorku ")]
        [MaxLength(600, ErrorMessage = "Opis powinien zawierać maksymalnie 600 znaków")]
        [Display(Name = "Opis podwieczorku")]
        public string? OpisPodwieczorku { get; set; }

        [Required(ErrorMessage = "Wpisz dzień w którym jest posiłek")]
        [Display(Name = "Dzień")]
        public DateTime? Dzien { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
    }
}