using System.Collections.Generic;

namespace API_DOTNET.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Student> Students { get; set; }
    }
}