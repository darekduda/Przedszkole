using PrzedszkoleData.Data.Manage;

namespace PrzedszkoleAdmin.Models
{
    public class NaleznoscViewModel
    {
        public Dziecko Dziecko { get; set; }
        public int Rok { get; set; }
        public int Miesiac { get; set; }
        public int SumaObecnosci { get; set; }
        public decimal CenaObecnosci { get; set; }
        public decimal CenaDodatkowa { get; set; }
        public decimal Naleznosc { get; set; }
    }
}
