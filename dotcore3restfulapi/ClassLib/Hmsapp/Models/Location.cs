using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Models
{
    public class Location
    {
        public int LocationId { get; set; } 

        public string Address { get; set; }

        public string City { get; set; }

        public string Sate { get; set; }

        public string PinCode { get; set; }

        public int PhoneNumber { get; set; }
    }
}