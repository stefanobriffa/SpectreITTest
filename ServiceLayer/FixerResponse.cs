using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class FixerResponse
    {
        public bool Success { get; set; }
        public int Timestamp { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
        public Error Error { get; set; }

        public FixerResponse()
        {
            Success = true;
            Error = new Error();
        }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string info { get; set; }
    }
}
