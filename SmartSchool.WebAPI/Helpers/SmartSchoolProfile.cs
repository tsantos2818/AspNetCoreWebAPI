using AutoMapper;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(scr => $"{scr.Nome} {scr.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(scr => scr.DataNasc.GetCurrentAge())
                );

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

            CreateMap<Professor,ProfessorDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(scr => $"{scr.Name} {scr.Sobrenome}")
                 );
            CreateMap<ProfessorDto, Professor>();
            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();

            CreateMap<DisciplinaDto, Disciplina>().ReverseMap();
            CreateMap<CursoDto, Curso>().ReverseMap();

        }
    }
}
