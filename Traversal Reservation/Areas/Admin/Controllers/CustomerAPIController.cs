using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Traversal_Reservation.Areas.Admin.Models;

namespace Traversal_Reservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CustomerAPIController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerAPIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5019/api/Customer");
            if (responseMessage.IsSuccessStatusCode)
            { 
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CustomerViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerViewModel customerViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(customerViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5019/api/Customer", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5019/api/Customer/{id}");
            if(responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5019/api/Customer/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CustomerViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerViewModel customerViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(customerViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5019/api/Customer", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

    }
}
