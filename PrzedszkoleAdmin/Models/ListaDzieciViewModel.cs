namespace PrzedszkoleAdmin.Models
{
    public class ListaDzieciViewModel
    {
        public int DzieckoId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<ZajeciaDodatkoweViewModel> PrzypisaneZajecia { get; set; }
        public decimal LacznyKosztZajec { get; set; } // Dodaj nową właściwość dla łącznego kosztu zajęć

        public ListaDzieciViewModel()
        {
            PrzypisaneZajecia = new List<ZajeciaDodatkoweViewModel>();
        }
    }
}
