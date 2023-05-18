using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.Manage
{
    public class Obecnosc
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Wpisz datę")]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        public int DzieckoId { get; set; }
        public Dziecko? Dziecko { get; set; }

        [Display(Name = "Czy obecne")]
        public bool CzyObecne { get; set; }
    }
}
