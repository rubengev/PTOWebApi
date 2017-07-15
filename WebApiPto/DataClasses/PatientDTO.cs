using System;

namespace WebApiPto.DataClasses
{
    public class PatientDto
    {
        public string id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
    
        public DateTime lastVisitDate { get; set; }

    }
}