using AutoMapper;
using OtoSoft.Plant.Business.Abstract;
using OtoSoft.Plant.Business.Infrastructure.AutoMapper;
using OtoSoft.Plant.DataAccess.Abstract;
using OtoSoft.Plant.Entities.Concrete;
using OtoSoft.Plant.Entities.DTOs.Complaint;
using OtoSoft.Plant.Entities.DTOs.Herb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Business.Concrete
{
    public class HerbManager : IHerbService
    {
        private readonly IHerbDal _herbDal;
        private readonly IComplaintService _complaintService;
        private readonly IMapper _mapper;
        public HerbManager(IHerbDal herbDal, IMapper mapper, IComplaintService complaintService)
        {
            _herbDal = herbDal;
            _mapper = mapper;
            _complaintService = complaintService;
        }

        public void Add(HerbCreateDto herbCreateDto)
        {
            Herb herb = _mapper.Map<Herb>(herbCreateDto);
            

            foreach (var item in herbCreateDto.Complaints)
            {
                herb.ComplaintHerbs.Add(new ComplaintHerb
                {
                    ComplaintId = item.ComplaintId
                });
            }

            _herbDal.Add(herb);
            
        }

        public void Delete(int id)
        {
            Herb herb = _herbDal.Get(x => x.Id == id);
            _herbDal.Delete(herb);
        }

        public List<HerbDto> GetAll()
        {
            List<Herb> herb = _herbDal.GetAllAsNoTracking();
            List<HerbDto> herbDtos = _mapper.Map<List<HerbDto>>(herb);
            return herbDtos;
        }

        public HerbDto GetById(int id)
        {
            return _mapper.Map<HerbDto>(_herbDal.Get(x => x.Id == id));
        }

        public List<HerbDto> GetWithComplaints()
        {
            List<HerbDto> herbDtos = _herbDal.GetWithComplaints();
            return herbDtos;
        }

        public void Update(HerbUpdateDto herbUpdateDto)
        {
            Herb _herb = _herbDal.Get(x => x.Id == herbUpdateDto.Id);

            _herb.Name = herbUpdateDto.Name;
            _herb.Description = herbUpdateDto.Description;
            _herb.Image = herbUpdateDto.Image;
            
            foreach (var item in herbUpdateDto.Complaints)
            {
                _herb.ComplaintHerbs.Add(new ComplaintHerb
                {
                    ComplaintId = item.ComplaintId
                });
            }

            _herbDal.Update(_mapper.Map<Herb>(_herb));
        }
    }
}
