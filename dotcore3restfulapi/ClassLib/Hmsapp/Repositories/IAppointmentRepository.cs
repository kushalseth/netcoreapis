using Hmsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hmsapp.Repositories
{
    public interface IAppointmentRepository
    {
        bool SaveAppointment(Appointments appointment);
    }
}
