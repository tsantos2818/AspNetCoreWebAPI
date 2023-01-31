using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinas(int disciplinaId, bool includeProfessor = false);
        Aluno GetAllAlunoById(int alunoId, bool includeProfessor = false);

        Professor[] GetAllProfessores(bool includeDisciplina = false);
        Professor[] GetAllProfessoresByDisciplinas(int disciplinaId, bool includeAluno = false);
        Professor GetAllProfessorById(int professorId, bool includeAluno = false);


    }
}
