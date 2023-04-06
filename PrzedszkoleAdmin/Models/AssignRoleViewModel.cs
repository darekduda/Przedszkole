using Microsoft.AspNetCore.Mvc.Rendering;


namespace PrzedszkoleAdmin.Models
{
    public class AssignRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
