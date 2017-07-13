using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiPto.Models;

namespace WebApiPto.DataClasses
{
    public class PatientFormDto
    {
        public int PatientFormId { get; set; }
        public string PatientId { get; set; }
        public int FormTypeId { get; set; }

        public string FormTypeName { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

    }
}