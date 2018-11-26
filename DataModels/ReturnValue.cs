using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels
{
    public class ReturnValue
    {
        [Required(ErrorMessage = "Return value with not succeeded flag")]
        public bool Succeeded { get; set; }

        public List<string> Errors { get; set; }

        public AppUser AppUser { get; set; }

        public ReturnValue()
        {
            Succeeded = true;
            Errors = new List<string>();
        }
    }
}
