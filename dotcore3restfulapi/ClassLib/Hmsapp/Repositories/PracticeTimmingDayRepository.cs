using Hmsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Repositories
{
    public class PracticeTimmingDayRepository : IPracticeTimmingDayRepository
    {
        public Guid SavePracticeTimmingDayRepository(PracticeTimmingDay practiceTimmingDay)
        {
            using(var context = new ApplicationDbContext())
            {
                context.PracticeTimmingDays.Add(practiceTimmingDay);
                context.SaveChanges();
            }
            return practiceTimmingDay.PracticeTimmingDayId;
        }
    }
}