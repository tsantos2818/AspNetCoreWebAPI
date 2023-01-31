using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;

        public Repository(SmartContext context)
        {
            _context = context;
        }


        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinas(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                                        .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno GetAllAlunoById(int alunoId ,bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().Where(aluno => aluno.Id == alunoId);

            return query.First();
        }

        public Professor[] GetAllProfessores(bool includeAluno = false)
        {
            IQueryable<Professor> query= _context.Professores;

            if (includeAluno)
            {
                query = query.Include(disciplina => disciplina.Disciplinas)
                                .ThenInclude(alunoDisciplina => alunoDisciplina.AlunosDisciplinas)
                                .ThenInclude(aluno => aluno.Aluno);
            }

            query = query.AsNoTracking().OrderBy(pf => pf.Id);

            return query.ToArray();

        }

        public Professor[] GetAllProfessoresByDisciplinas(int disciplinaId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(disciplina => disciplina.Disciplinas)
                                .ThenInclude(alunoDisciplina => alunoDisciplina.AlunosDisciplinas)
                                .ThenInclude(aluno => aluno.Aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                                        .Where(professor => professor.Disciplinas.Any(d => d.Id == disciplinaId));

            return query.ToArray();
        }

        public Professor GetAllProfessorById(int professorId , bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(disciplina => disciplina.Disciplinas)
                                .ThenInclude(alunoDisciplina => alunoDisciplina.AlunosDisciplinas)
                                .ThenInclude(aluno => aluno.Aluno);
            }

            query = query.AsNoTracking().Where(pf => pf.Id == professorId); 

            return query.First();
        }
    }
}
