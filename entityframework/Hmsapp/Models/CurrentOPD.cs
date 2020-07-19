using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Models
{
    public class CurrentOPD
    {
        public Guid CurrentOPDId { set; get; } = Guid.NewGuid();

        public string DisplayNumber { get; set; }

        public Guid DoctorId { get; set; }

        public Guid PatientId { get; set; }
    }
}