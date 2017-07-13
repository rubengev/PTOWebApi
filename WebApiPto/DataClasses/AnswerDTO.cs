namespace WebApiPto.DataClasses
{
    public class AnswerDto
    {
        public int AnswerId { get; set; }
        public int PatientFormId { get; set; }
        public int QuestionId { get; set; }
        public bool AnswerChecked { get; set; }
        public string AnswerText { get; set; }

        public string Question { get; set; }

    }
}