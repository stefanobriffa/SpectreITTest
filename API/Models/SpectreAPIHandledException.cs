using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpectreAPI.Models
{
    public class SpectreAPIHandledException : Exception
    {
        public SpectreAPIHandledException() : base() { }

        public SpectreAPIHandledException(string message) : base(message) { }

        public SpectreAPIHandledException(string message, Exception e) : base(message, e) { }
    }
}