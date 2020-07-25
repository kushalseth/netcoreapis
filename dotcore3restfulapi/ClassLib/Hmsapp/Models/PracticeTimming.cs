using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Models
{
    public class PracticeTimming
    {
        public Guid PracticeTimmingId { get; set; }  = Guid.NewGuid();

        public Guid DoctorId { get; set; }

        public int LocationId { get; set; }

        public DateTime SessionStartTime { get; set; }

        public DateTime SessionEndTime { get; set; }
        
        public DateTime Duration { get; set; }    
    }
}