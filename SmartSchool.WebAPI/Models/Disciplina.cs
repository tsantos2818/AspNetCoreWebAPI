namespace SmartSchool.WebAPI.Models
{
    public class Disciplina
    {
        public Disciplina()
        {
        }
        public Disciplina(int id, string name, int professorId, int cursoId)
        {
            Id = id;
            Name = name;
            ProfessorId = professorId;
            CursoId = cursoId;  
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CargaHoraria { get; set; }
        public int? PrerequisitoId { get; set; } = null;
        public int ProfessorId { get; set; }
        public int CursoId { get; set; }

        public Disciplina Prerequisito { get; set; }
        public Curso Curso { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
         
    }
}
