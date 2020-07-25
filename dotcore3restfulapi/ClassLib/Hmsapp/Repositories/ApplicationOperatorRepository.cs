using Hmsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Data.Entity;

namespace Hmsapp.Repositories
{
    /// <summary>
    /// If DbContext.Configuration.ProxyCreationEnabled is set to false, DbContext will not load child objects for some parent object unless Include method is called on parent object. Setting DbContext.Configuration.LazyLoadingEnabled to true or false will have no impact on its behaviours.

    /// If DbContext.Configuration.ProxyCreationEnabled is set to true, child objects will be loaded automatically, and DbContext.Configuration.LazyLoadingEnabled value will control when child objects are loaded.
    /// </summary>
    public class ApplicationOperatorRepository : IApplicationOperatorRepository
    {

        public ApplicationOperator GetDoctorDetails(string userId)
        {
            ApplicationOperator applicationOperator = null;
            using (var ctx = new ApplicationDbContext())
            {

                ctx.Configuration.ProxyCreationEnabled = true;
                ctx.Configuration.LazyLoadingEnabled = true;
                applicationOperator =  ctx.Users.Include(x => x.ApplicationClients).Include(x => x.Professtionals).FirstOrDefault(x => x.Id ==  userId);
               // applicationOperator = ctx.Users.FirstOrDefault(x => x.Id ==  userId);
                //applicationOperator.ApplicationClients = new ApplicationClient();
                //applicationOperator.ApplicationClients = ctx.ApplicationClients.Find(applicationOperator.Id);
            }

            return applicationOperator;
        }

        public bool SaveDoctorProfile(DoctorProfileModel doctorProfileModel, string userId)
        {
            ApplicationOperator applicationOperator = null;
            using (var ctx = new ApplicationDbContext())
            {
                // applicationOperator = GetDoctorDetails(userId);

                ctx.Configuration.ProxyCreationEnabled = true;
                ctx.Configuration.LazyLoadingEnabled = true;
                applicationOperator = ctx.Users.Include(x => x.ApplicationClients).Include(x => x.Professtionals).FirstOrDefault(x => x.Id == userId);
                applicationOperator.PhoneNumber = doctorProfileModel.PhoneNumber;
                if (applicationOperator.ApplicationClients != null)
                {
                    applicationOperator.ApplicationClients.FirstName = doctorProfileModel.FirstName;
                    applicationOperator.ApplicationClients.LastName = doctorProfileModel.LastName;
                }
                ctx.Entry(applicationOperator).CurrentValues.SetValues(applicationOperator);
                ctx.SaveChanges();
            }
            return true;
        }
    }
}