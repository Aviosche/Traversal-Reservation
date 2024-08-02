using BusinessLayer.Abstract.UowAbstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal_Reservation.Areas.Admin.Models;

namespace Traversal_Reservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountService.TGetById(model.SenderID);
            var valueReceiver = _accountService.TGetById(model.ReceiverID);

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;

            List<Account> modifiedAccounts = new List<Account>()
            {
                valueSender,
                valueReceiver
            };

            _accountService.TMultiUpdate(modifiedAccounts);
            return View();
        }



    }
}
