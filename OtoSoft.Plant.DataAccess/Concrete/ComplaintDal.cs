using Core.DataAccess.Concrete;
using OtoSoft.Plant.DataAccess.Abstract;
using OtoSoft.Plant.DataAccess.Concrete.Contexts;
using OtoSoft.Plant.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.DataAccess.Concrete
{
    public class ComplaintDal:EfRepository<Complaint>,IComplaintDal
    {
        public ComplaintDal(HerbContext context) : base(context)
        {

        }
    }
}
