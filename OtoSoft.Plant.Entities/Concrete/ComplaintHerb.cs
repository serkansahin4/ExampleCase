using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Entities.Concrete
{
    public class ComplaintHerb
    {
        public int HerbId { get; set; }
        public int ComplaintId { get; set; }
        public Complaint Complaint { get; set; }
        public Herb Herb { get; set; }
    }
}
