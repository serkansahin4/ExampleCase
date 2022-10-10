using OtoSoft.Plant.Entities.DTOs.Complaint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Entities.DTOs.Herb
{
    public class HerbDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<ComplaintDto> ComplaintDto { get; set; }

    }
}
