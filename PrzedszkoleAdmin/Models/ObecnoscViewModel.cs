using PrzedszkoleData.Data.Manage;

namespace PrzedszkoleAdmin.Models
{
    public class ObecnoscViewModel
    {
        public DateTime Data { get; set; }
        public List<Dziecko> Dzieci { get; set; }
        public Dictionary<int, bool> Obecnosci { get; set; }
    }
}
