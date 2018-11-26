using System.ComponentModel.DataAnnotations;

namespace SpectreAPI.Models
{
    public class UserAccount
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Username must be minimum 2 charaters")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be minimum 6 charaters")]
        public string Password { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter Valid Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "First name must be minimum 2 charaters")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Last name must be minimum 2 charaters")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Country is required")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Last name must be minimum 2 charaters")]
        public string Country { get; set; }
        public string LoggedOn { get; set; }
        public decimal CurrentBalance { get; set; }
        public double CurrentBalanceForeignCurrency { get; set; }
    }
}