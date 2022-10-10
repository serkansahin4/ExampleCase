using Microsoft.AspNetCore.Mvc.Rendering;

namespace OtoSoft.Plant.WebUI.Areas.Admin.Models.Herb
{
    public class HerbCreateVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public List<string> Complaints { get; set; }
    }
}
