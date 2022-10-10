using AutoMapper;
using OtoSoft.Plant.Entities.Concrete;
using OtoSoft.Plant.Entities.DTOs.Complaint;
using OtoSoft.Plant.Entities.DTOs.ComplaintHerb;
using OtoSoft.Plant.Entities.DTOs.Herb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Business.Infrastructure.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Herb, HerbDto>().ReverseMap();
            CreateMap<Herb, HerbCreateDto>().ReverseMap();
            CreateMap<Herb, HerbUpdateDto>().ReverseMap();

            CreateMap<Complaint, ComplaintDto>().ReverseMap();
            CreateMap<Complaint, ComplaintUpdateDto>().ReverseMap();
            CreateMap<Complaint, ComplaintCreateDto>().ReverseMap();

            CreateMap<ComplaintHerb, ComplaintHerbDto>().ReverseMap();
            CreateMap<ComplaintHerb, ComplaintHerbCreateDto>().ReverseMap();
        }
    }
}
