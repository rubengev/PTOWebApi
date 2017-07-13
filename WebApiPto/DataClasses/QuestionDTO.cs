
namespace WebApiPto.DataClasses
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public bool Checked { get; set; }
        public string Answer { get; set; }
    }
}