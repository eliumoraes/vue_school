namespace API_DOTNET.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Nascimento { get; set; }
        public int TeacherId { get; set; }
    }
}