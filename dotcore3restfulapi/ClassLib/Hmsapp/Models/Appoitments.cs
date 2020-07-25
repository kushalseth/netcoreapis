using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Models
{
    public class Appointments
    {
        public Guid AppointmentId { set; get; } = Guid.NewGuid();

        public Guid DoctorId { get; set; }

        public Guid PatientId { get; set; }

        public DateTime BeforeOPDAppointmentTime { get; set; }

        public string AppointmentType { get; set; }

        public bool AppointmentCompleted { get; set; }

        public DateTime AfterOPDActualAppointmentTime { get; set; }

        public Guid OPDAttendedID { get; set; }

    }
}