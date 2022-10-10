using Microsoft.AspNetCore.Mvc;
using OtoSoft.Plant.Business.Abstract;
using OtoSoft.Plant.Entities.DTOs.Complaint;

namespace OtoSoft.Plant.WebUI.Controllers
{
   
    public class ComplaintController : Controller
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ComplaintDto> complaintDtos = _complaintService.GetAll();
            return View(complaintDtos);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            ComplaintDto complaintDto = _complaintService.GetById(id);
            return View(complaintDto);
        }
    }
}
