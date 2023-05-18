using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace PrzedszkoleAdmin.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Kraj { get; set; }

        public string Wojewodztwo { get; set; }

        public string Miasto { get; set; }

        [Display(Name = "Postal Code")]
        public string KodPocztowy { get; set; }

        public string Ulica { get; set; }

        [Display(Name = "House Number")]
        public string NumerDomu { get; set; }

    }
}
