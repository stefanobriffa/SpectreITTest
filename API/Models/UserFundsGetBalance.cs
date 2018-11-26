using System.ComponentModel.DataAnnotations;

namespace SpectreAPI.Models
{
    public class UserGetBalance
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserID is required")]
        public string UserID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Exchange rate is required")]
        public string ExchangeRate { get; set; }
    }
}