using Hmsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Repositories
{
    public class PracticeTimmingRepository : IPracticeTimmingRepository
    {
        public Guid SavePracticeTimming(PracticeTimming practiceTimming)
        {
            //Guid practiceTimmings = Guid.Empty;
            using (var context = new ApplicationDbContext())
            {
                context.PracticeTimmings.Add(practiceTimming);
                context.SaveChanges();
            }

            return practiceTimming.PracticeTimmingId;
        }
    }
}