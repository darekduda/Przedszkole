
using PrzedszkoleData.Data.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.Manage
{
    public class DzieckoZajeciaDodatkowe
    {
        [Key]
        public int Id { get; set; }

        public int DzieckoId { get; set; }
        public Dziecko Dziecko { get; set; }

        public int ZajeciaDodatkoweId { get; set; }
        public ZajeciaDodatkowe ZajeciaDodatkowe { get; set; }

        public DateTime Data { get; set; } // Dodaj kolumnę Data typu DateTime

    }
}
