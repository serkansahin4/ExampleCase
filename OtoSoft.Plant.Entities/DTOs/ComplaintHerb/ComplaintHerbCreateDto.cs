using OtoSoft.Plant.Entities.DTOs.Complaint;
using OtoSoft.Plant.Entities.DTOs.Herb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Entities.DTOs.ComplaintHerb
{
    public class ComplaintHerbCreateDto
    {
        public int HerbId { get; set; }
        public int ComplaintId { get; set; }
        public ComplaintDto ComplaintDto { get; set; }
        public HerbDto HerbDto { get; set; }
    }
}
