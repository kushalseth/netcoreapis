using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp.Models
{
    public class PracticeTimmingsVM
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PinCode { get; set; }

        public int PhoneNumber { get; set; }

        public List<PracticeSession> PracticeSession { get; set; }

        public DateTime Duration { get; set; }
    }

    public class PracticeSession {
        public DateTime SessionStartTime { get; set; }

        public DateTime SessionEndTime { get; set; }

        public string[] Days { set; get; }

    }
}