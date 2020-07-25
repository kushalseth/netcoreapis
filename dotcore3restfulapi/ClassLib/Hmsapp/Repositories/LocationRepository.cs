using Hmsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public int SaveDoctorPracticeSchedule(Location location)
        {
            int locationId = 0;
            using (var context = new ApplicationDbContext())
            {
                context.Locations.Add(location);
                locationId = context.SaveChanges();
            }

            return location.LocationId;

        }
    }
}