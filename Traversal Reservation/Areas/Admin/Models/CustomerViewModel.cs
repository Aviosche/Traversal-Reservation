using Newtonsoft.Json;

namespace Traversal_Reservation.Areas.Admin.Models
{
    public class CustomerViewModel
    {
        [JsonProperty("customerID")]
        public int CustomerID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("mail")]
        public string Mail { get; set; }

    }
}
