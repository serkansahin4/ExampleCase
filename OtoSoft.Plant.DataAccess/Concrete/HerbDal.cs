using Core.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using OtoSoft.Plant.DataAccess.Abstract;
using OtoSoft.Plant.DataAccess.Concrete.Contexts;
using OtoSoft.Plant.Entities.Concrete;
using OtoSoft.Plant.Entities.DTOs.Complaint;
using OtoSoft.Plant.Entities.DTOs.Herb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.DataAccess.Concrete
{
    public class HerbDal : EfRepository<Herb>, IHerbDal
    {
        public HerbDal(HerbContext context) : base(context)
        {

        }
        public List<HerbDto> GetWithComplaints(Expression<Func<HerbDto, bool>> filter=null)
        {
            var queryable = _entity.Include(x => x.ComplaintHerbs).ThenInclude(x=>x.Complaint).AsNoTracking().Select(x => new HerbDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                ComplaintDto = x.ComplaintHerbs.Select(x => new ComplaintDto
                {
                    Id = x.ComplaintId,
                    Name = x.Complaint.Name,
                    Description = x.Complaint.Description
                }).ToList()
            });

            return filter == null ? queryable.ToList(): queryable.Where(filter).ToList();
        }

    }
}
