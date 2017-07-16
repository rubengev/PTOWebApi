using System;
using System.Collections.Generic;

namespace WebApiPto.DataClasses
{
    public class FormDetailDto
    {
        public int Id { get; set; }
        public int FormTypeId { get; set; }
        public string FormTypeName { get; set; }
        public string PatientId  { get; set; }
        public DateTime VisitDate{ get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}