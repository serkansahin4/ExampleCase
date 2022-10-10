using Core.Utilities.ImageTools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoSoft.Plant.Business.Abstract;
using OtoSoft.Plant.Entities.DTOs.Complaint;
using OtoSoft.Plant.Entities.DTOs.ComplaintHerb;
using OtoSoft.Plant.Entities.DTOs.Herb;
using OtoSoft.Plant.WebUI.Areas.Admin.Models.Herb;
using System.Text.Json;

namespace OtoSoft.Plant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class HerbController : Controller
    {
        private readonly IHerbService _herbService;
        private readonly IComplaintService _complaintService;


        public HerbController(IHerbService herbService, IComplaintService complaintService)
        {
            _herbService = herbService;
            _complaintService = complaintService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<HerbDto> herbDtos = _herbService.GetWithComplaints();
            return View(herbDtos);
        }

        [HttpGet]

        public IActionResult Detail(int id)
        {
            HerbDto herbDto = _herbService.GetById(id);
            return View(herbDto);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            HerbDto herbDto = _herbService.GetById(id);
            return View(herbDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HerbUpdateVM herbUpdateVM)
        {
            HerbUpdateDto herbUpdateDto = new HerbUpdateDto
            {
                Id = herbUpdateVM.Id,
                Description = herbUpdateVM.Description,
                Name = herbUpdateVM.Name,
                Image = ImageConverterTool.ConvertToBase64(herbUpdateVM.Image).Result,

            };
            foreach (var item in herbUpdateVM.Complaints)
            {
                herbUpdateDto.Complaints.Add(new ComplaintHerbCreateDto
                {
                    ComplaintId = Convert.ToInt32(item)
                });
            }
            _herbService.Update(herbUpdateDto);
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _herbService.Delete(id);
            
            return Ok(Json(_herbService.GetAll()));
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ComplaintDto = _complaintService.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(HerbCreateVM herbCreateVM)
        {

            HerbCreateDto herbCreateDto = new HerbCreateDto();
            herbCreateDto.Image = ImageConverterTool.ConvertToBase64(herbCreateVM.Image).Result;
            herbCreateDto.Name = herbCreateVM.Name;
            herbCreateDto.Description = herbCreateVM.Description;
            foreach (var item in herbCreateVM.Complaints)
            {
                herbCreateDto.Complaints.Add(new ComplaintHerbCreateDto
                {
                    ComplaintId = Convert.ToInt32(item)
                });
            }

            _herbService.Add(herbCreateDto);
            ViewBag.ComplaintDto = _complaintService.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return View();
        }
    }
}
