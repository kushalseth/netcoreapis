using Hmsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hmsapp.Repositories
{
    public interface IApplicationClientRepository
    {
        IList<ApplicationClient> GetListOfPatientsForDoctor(string doctorId);
        Guid SaveClientProfile(PatientProfileModel patientProfileModel, string doctorId);
    }
}
