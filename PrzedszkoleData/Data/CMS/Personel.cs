using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.CMS
{
    public class Personel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz imię")]
        [MaxLength(150, ErrorMessage = "Imię powinno zawierać maksymalnie 150 znaków")]
        [Display(Name = "Imię")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Wpisz Naziwsko")]
        [MaxLength(150, ErrorMessage = "Naziwsko powinno zawierać maksymalnie 150 znaków")]
        [Display(Name = "Naziwsko")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Wpisz stanowsio")]
        [MaxLength(150, ErrorMessage = "Stanowsiko powinno zawierać maksymalnie 150 znaków")]
        [Display(Name = "Stanowsiko")]
        public string? Stanowsiko { get; set; }

        [NotMapped]
        [Display(Name = "Profilowe zdjęcie")]
        public IFormFile? ImageFile { get; set; }
        public string? ProfilePicture { get; set; }



    }
}
