using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Models.ViewComponents.Default
{
    public class _SubAboutViewComponent : ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());

        public IViewComponentResult Invoke()
        {
            var values = subAboutManager.TGetList();
            return View(values); 
        }
    }
}
