using Microsoft.AspNetCore.Identity;
using PrzedszkoleData.Data.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzedszkoleData.Data.Account
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Kraj { get; set; }
        public string? Wojewodztwo { get; set; }
        public string? Miasto { get; set; }
        public string? KodPocztowy { get; set; }
        public string? Ulica { get; set; }
        public string? NumerDomu { get; set; }
        public string? ProfilePicture { get; set; }
        public ICollection<Dziecko> Dzieci { get; set; }

    }
}
