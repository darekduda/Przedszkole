namespace PrzedszkoleAdmin.Models
{
    public class PrzypiszDzieciViewModel
    {
        public string UserId { get; set; }
        public List<DzieckoViewModel> Dzieci { get; set; }

        public PrzypiszDzieciViewModel()
        {
            Dzieci = new List<DzieckoViewModel>();
        }
    }
}
