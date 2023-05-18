using Microsoft.AspNetCore.Mvc.Rendering;

namespace PrzedszkoleAdmin.Models
{
    public class AssignChildrenViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<SelectListItem> Children { get; set; }
        public IEnumerable<string> SelectedChildrenIds { get; set; }
    }
}
