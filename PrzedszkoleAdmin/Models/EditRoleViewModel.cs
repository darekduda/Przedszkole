using System.ComponentModel.DataAnnotations;

namespace PrzedszkoleAdmin.Models
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
