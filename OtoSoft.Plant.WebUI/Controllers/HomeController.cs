using Microsoft.AspNetCore.Mvc;
using OtoSoft.Plant.Business.Abstract;
using OtoSoft.Plant.Entities.DTOs.Herb;

namespace OtoSoft.Plant.WebUI.Controllers
{     
    public class HomeController : Controller
    {
        private readonly IHerbService _herbService;

        public HomeController(IHerbService herbService)
        {
            _herbService = herbService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<HerbDto> herbDtos= _herbService.GetWithComplaints();
            return View(herbDtos);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            HerbDto herbDto = _herbService.GetById(id);
            return View(herbDto);
        }


    }
}
