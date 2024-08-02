using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [Route("AddGuide")]
        public IActionResult AddGuide()
        {
            
            return View();
        }
        
        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            if(result.IsValid)
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index");

            }
            else
            {
                foreach(var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                return View();
            }
        }

        [Route("EditGuide")]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }

        [Route("EditGuide")]
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }

        [Route("ChangeToActive/{id}")]
        public IActionResult ChangeToActive(int id)
        {
            _guideService.TChangeToTrue(id);
            return RedirectToAction("Index","Guide",new {area="Admin"});
        }

        [Route("ChangeToPassive/{id}")]
        public IActionResult ChangeToPassive(int id)
        {
            _guideService.TChangeToFalse(id);
            return RedirectToAction("Index","Guide", new { area = "Admin" });
        }
    }
}
