using OtoSoft.Plant.Entities.DTOs.Complaint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Business.Abstract
{
    public interface IComplaintService
    {
        List<ComplaintDto> GetAll();
        ComplaintDto GetById(int id);
        void Add(ComplaintCreateDto herb);
        void Update(ComplaintUpdateDto herb);
        void Delete(int id);
    }
}
