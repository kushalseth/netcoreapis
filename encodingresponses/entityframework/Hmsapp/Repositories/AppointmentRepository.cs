using Hmsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public bool SaveAppointment(Appointments appointment)
        {
            using (var ctx = new ApplicationDbContext()) {
                ctx.Appointments.Add(appointment);
                ctx.SaveChanges();
            }
            return true;
        }
    }
}