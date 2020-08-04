using System;
using System.Collections;

namespace Hmsapp.Models
{
    public class ApplicationClient
    {
        public Guid ApplicationClientId { set; get; } = Guid.NewGuid();

        public string OperatorId { set; get; }


        public string ParentOperatorId { set; get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string test { get; set; }

    }
}