using SpectreAPI.Models;
using System;
using System.Collections.Generic;

namespace DataModels
{
    public class AppReturnObject
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}