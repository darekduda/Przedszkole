using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrzedszkoleData.Data.Manage;

namespace PrzedszkoleData.Data.CMS
{
    public class Grupa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę grupy")]
        [MaxLength(150, ErrorMessage = "Nazwa powinna zawierać maksymalnie 150 znaków")]
        [Display(Name = "Nazwa")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
        public List<Dziecko>? Dziecko { get; set; }

    }
}
