using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Reservation.Areas.Admin.Models;

namespace Traversal_Reservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var city_name = (string)TempData["city"];
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&locale=en-gb&children_ages=5%2C0&filter_by_currency=EUR&checkin_date=2024-09-14&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&dest_type=city&dest_id=-1746443&adults_number=2&checkout_date=2024-09-15&order_by=popularity&include_adjacency=true&room_number=1&page_number=0&units=metric"),
                Headers =
    {
        { "x-rapidapi-key", "32bbbbc8dcmsh5d68af23b623349p1d86bajsnac6b4d4cfa17" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            }; 
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);
                return View(values.results);
            }
        }

        public IActionResult GetCityDestID()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string city_name)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={city_name}&locale=en-gb"),
                Headers =
    {
        { "x-rapidapi-key", "32bbbbc8dcmsh5d68af23b623349p1d86bajsnac6b4d4cfa17" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            TempData["city"] = city_name;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return RedirectToAction("Index");
            }
        }
    
    
    }
}
