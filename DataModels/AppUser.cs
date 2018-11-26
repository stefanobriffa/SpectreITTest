using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataModels
{
    public class AppUser : IdentityUser
    {
        public string Password { get; set; }

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

        public virtual List<AppUserTransaction> Transactions  { get; set; }

        public bool IsBlocked { get; set; }

        public int CurrentBalance
        {
            get
            {
                if (Transactions == null || Transactions.Count == 0)
                    return 0;
                else
                    return Transactions.Select(t => t.Amount).Sum();
            }
        }

        public double CurrentBalanceForeignCurrency { get; set; }
    }
}