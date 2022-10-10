using Core.DataAccess;
using OtoSoft.Plant.Entities.Concrete;
using OtoSoft.Plant.Entities.DTOs.Herb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.DataAccess.Abstract
{
    public interface IHerbDal:IRepository<Herb>
    {
        List<HerbDto> GetWithComplaints(Expression<Func<HerbDto, bool>> filter=null);
    }
}
