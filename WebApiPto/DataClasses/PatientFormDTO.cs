using System;

namespace WebApiPto.DataClasses
{
    public class PatientFormDto
    {
        public int Id { get; set; }
        public int FormTypeId { get; set; }
        public string FormTypeName { get; set; }
        public string PatientId { get; set; }
        public DateTime VisitDate { get; set; }
    }
}