using Hmsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Hmsapp.Repositories
{
    public class ApplicationClientRepository : IApplicationClientRepository
    {
        public IList<ApplicationClient> GetListOfPatientsForDoctor(string doctorId)
        {
            IList<ApplicationClient> applicationClients = new List<ApplicationClient>();
            using (var ctx = new ApplicationDbContext()) {
                applicationClients = ctx.ApplicationClients.Where(x => x.ParentOperatorId == doctorId).ToList();
            }

            return applicationClients;
        }

        public Guid SaveClientProfile(PatientProfileModel patientProfileModel, string doctorId)
        {
            ApplicationClient applicationClient = new ApplicationClient();
            using (var ctx = new ApplicationDbContext())
            {
                // applicationOperator = GetDoctorDetails(userId);

                ctx.Configuration.ProxyCreationEnabled = true;
                ctx.Configuration.LazyLoadingEnabled = true;
                applicationClient.FirstName = patientProfileModel.FirstName;
                applicationClient.LastName = patientProfileModel.LastName;
                applicationClient.ParentOperatorId = doctorId;

                ctx.ApplicationClients.Add(applicationClient);
                //ctx.Entry(applicationClient).CurrentValues.SetValues(applicationClient);
                ctx.SaveChanges();
            }
            return applicationClient.ApplicationClientId;
        }
    }
}