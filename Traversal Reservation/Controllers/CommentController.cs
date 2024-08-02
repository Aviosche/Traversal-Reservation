using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        

        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            
            comment.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.State = true;
            commentManager.TAdd(comment);
            return RedirectToAction("Index", "Destination");
        }
    }
}
