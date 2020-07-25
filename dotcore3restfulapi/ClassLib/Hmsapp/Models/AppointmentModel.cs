using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Models
{
    public class AppointmentModel
    {

        public Guid DoctorId { get; set; }

        public Guid PatientId { get; set; }

        public DateTime BeforeOPDAppointmentTime { get; set; }

        public string AppointmentType { get; set; }

        public bool AppointmentCompleted { get; set; }

        public DateTime AfterOPDActualAppointmentTime { get; set; }

        public Guid OPDAttendedID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ApplicationClientId { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}