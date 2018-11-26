using System.ComponentModel.DataAnnotations;

namespace SpectreAPI.Models
{
    public class UserFunds
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserID is required")]
        public string UserID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Transaction amount is required")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Amount cannot be 0")]
        public int Amount { get; set; }
    }
}