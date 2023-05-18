using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.CMS
{
    public class Parametr
    {
        [Key]
        public int IdParametru { get; set; }

        [Required(ErrorMessage = "Kod jest wymagany")]
        [MaxLength(10, ErrorMessage = "Kod powinien zawierać max 10 znaków")]
        public string? Kod { get; set; } // do precyzyjnego rozpoznawania pola po nazwie

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(30, ErrorMessage = "Nazwa powinna zawierać max 30 znaków")]
        public string? Nazwa { get; set; }

        [Required(ErrorMessage = "Wartość jest wymagana")]
        [Display(Name = "Wartość")]
        public string? Wartosc { get; set; } // treść pola

        public string? Opis { get; set; } // dodatkowe uwagi widoczne tylko z poziomu Intranetu
        public bool CzyAktywny { get; set; }

    }
}
