using OtoSoft.Plant.Entities.Concrete;
using OtoSoft.Plant.Entities.DTOs.Herb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Business.Abstract
{
    public interface IHerbService
    {
        List<HerbDto> GetAll();
        HerbDto GetById(int id);
        void Add(HerbCreateDto herb);
        void Update(HerbUpdateDto herb);
        void Delete(int id);
        List<HerbDto> GetWithComplaints();

    }
}
