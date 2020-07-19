using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Models
{
    public class PracticeTimmingDay
    {
        public Guid PracticeTimmingDayId { get; set; } = Guid.NewGuid();

        public int DayId { get; set; }

        public Guid PracticeTimmingsId { get; set; }
    }
}