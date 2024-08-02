using System.ComponentModel.DataAnnotations;

namespace Traversal_Reservation.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lüften kullanıcı adınızı giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
