using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPto.DataClasses
{
    public class PatientDto
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public DateTime LastVisitDate { get; set; }

    }
}