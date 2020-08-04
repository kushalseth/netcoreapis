using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Models
{
    public class Professtional
    {
        public Guid ProfesstionalId { set; get; } = Guid.NewGuid();

        public string OperatorId { get; set; }

        public int OfferId { get; set; }

        public string Address { get; set; }

        public string GeoLocation { get; set; }
    }
}