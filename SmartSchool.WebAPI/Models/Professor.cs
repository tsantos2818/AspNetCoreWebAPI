namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Professor()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
