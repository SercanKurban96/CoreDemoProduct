using System.ComponentModel.DataAnnotations;

namespace CoreDemoProduct.PresentationLayer.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
