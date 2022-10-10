using AutoMapper;
using OtoSoft.Plant.Business.Abstract;
using OtoSoft.Plant.DataAccess.Abstract;
using OtoSoft.Plant.Entities.Concrete;
using OtoSoft.Plant.Entities.DTOs.Complaint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Business.Concrete
{
    public class ComplaintManager : IComplaintService
    {
        private readonly IComplaintDal _complaintDal;
        private readonly IMapper _mapper;
        public ComplaintManager(IComplaintDal complaintDal, IMapper mapper)
        {
            _complaintDal = complaintDal;
            _mapper = mapper;
        }

        public void Add(ComplaintCreateDto complaint)
        {
            _complaintDal.Add(_mapper.Map<Complaint>(complaint));
        }

        public void Delete(int id)
        {
            Complaint complaint = _complaintDal.Get(x => x.Id == id);
            _complaintDal.Delete(complaint);
        }

        public List<ComplaintDto> GetAll()
        {
            List<ComplaintDto> complaintDtos = _mapper.Map<List<ComplaintDto>>(_complaintDal.GetAllAsNoTracking());
            return complaintDtos;
        }

        

        public ComplaintDto GetById(int id)
        {
            return _mapper.Map<ComplaintDto>(_complaintDal.Get(x => x.Id == id));
        }

        public void Update(ComplaintUpdateDto complaint)
        {
            Complaint _complaint = _complaintDal.Get(x => x.Id == complaint.Id);
            _complaintDal.Update(_mapper.Map<Complaint>(_complaint));
        }
    }
}
