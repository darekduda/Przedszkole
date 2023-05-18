using PrzedszkoleData.Data.CMS;

namespace PrzedszkoleAdmin.Models
{
    public class DzieckoZajeciaViewModel
    {
        public int DzieckoId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<ZajeciaDodatkowe>? PrzypisaneZajecia { get; set; }

        public DzieckoZajeciaViewModel()
        {
            PrzypisaneZajecia = new List<ZajeciaDodatkowe>();
        }
    }
}
