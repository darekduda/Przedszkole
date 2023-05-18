using PrzedszkoleData.Data.CMS;
using PrzedszkoleData.Data.Manage;

namespace PrzedszkoleAdmin.Models
{
    public class DzieckoZajeciaDodatkoweViewModel
    {
        public List<Dziecko> Dzieci { get; set; }
        public Dictionary<int, List<ZajeciaDodatkowe>> PrzypisaneZajecia { get; set; }
        public int DzieckoId { get; set; }
        public List<int> ZajeciaDodatkoweIds { get; set; }
        public int Miesiac { get; set; } // Zmieniono na typ int
        public int Rok { get; set; } // Zmieniono na typ int

        public List<ZajeciaDodatkowe> ZajeciaDodatkowe { get; set; } // Dodano listę wyboru ZajeciaDodatkowe

        public DzieckoZajeciaDodatkoweViewModel()
        {
            Dzieci = new List<Dziecko>();
            PrzypisaneZajecia = new Dictionary<int, List<ZajeciaDodatkowe>>();
            ZajeciaDodatkoweIds = new List<int>();
            ZajeciaDodatkowe = new List<ZajeciaDodatkowe>(); // Inicjalizuj listę wyboru ZajeciaDodatkowe
        }

        public void DodajDziecko(Dziecko dziecko, List<ZajeciaDodatkowe> zajeciaDodatkowe)
        {
            Dzieci.Add(dziecko);
            PrzypisaneZajecia[dziecko.Id] = zajeciaDodatkowe;
        }
    }
}
