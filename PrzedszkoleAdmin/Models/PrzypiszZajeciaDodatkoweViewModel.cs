using PrzedszkoleData.Data.CMS;

namespace PrzedszkoleAdmin.Models
{
    public class PrzypiszZajeciaDodatkoweViewModel
    {
        public int DzieckoId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<ZajeciaDodatkowe> DostepneZajecia { get; set; }
        public List<int> WybraneZajecia { get; set; }

        public PrzypiszZajeciaDodatkoweViewModel()
        {
            DostepneZajecia = new List<ZajeciaDodatkowe>();
            WybraneZajecia = new List<int>();
        }
    }
}
