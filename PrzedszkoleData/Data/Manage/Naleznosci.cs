using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.Manage
{
    public class Naleznosci
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz rok")]
        [Display(Name = "Rok")]
        public int Rok { get; set; }

        [Required(ErrorMessage = "Wpisz miesiąc")]
        [Display(Name = "Miesiąc")]
        public int Miesiac { get; set; }

        [Required(ErrorMessage = "Wpisz kwotę")]
        [Display(Name = "Kwota")]
        [DisplayFormat(DataFormatString = "{0:#}")]
        public decimal Kwota { get; set; }

        public int DzieckoId { get; set; }
        public Dziecko Dziecko { get; set; }
    }
}
