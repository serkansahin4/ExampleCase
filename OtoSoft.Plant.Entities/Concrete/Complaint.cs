using OtoSoft.Plant.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Entities.Concrete
{
    public class Complaint:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ComplaintHerb> ComplaintHerbs { get; set; }
    }
}
