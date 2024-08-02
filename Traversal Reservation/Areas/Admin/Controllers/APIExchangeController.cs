using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Traversal_Reservation.Areas.Admin.Models;

namespace Traversal_Reservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class APIExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<BookingExchangeNestedViewModel> bookingExchangeNestedViewModels = new List<BookingExchangeNestedViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=TRY"),
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
                var values = JsonConvert.DeserializeObject<BookingExchangeNestedViewModel>(body);
                return View(values.exchange_rates);
            }
        }
    }
}
