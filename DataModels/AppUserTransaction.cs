using System;
using System.ComponentModel.DataAnnotations;

namespace DataModels
{
    public class AppUserTransaction
    {
        [Key]
        public long PK { get; set; }

        public DateTime TransDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Transaction amounnt is required")]
        public int Amount { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}