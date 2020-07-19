using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Models
{
    public class DoctorPatients
    {
        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public string PhoneNumber { get; set; }

        public IList<ApplicationClient> PatientsList { get; set; } 
    }
}