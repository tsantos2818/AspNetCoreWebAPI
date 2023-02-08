using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo,
                                    IMapper mapper)
        {
           _repo = repo;
           _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(result));
        }

        [HttpGet("GetJsonProfessor")]
        public IActionResult GetJsonProfessor()
        {
            return Ok(new ProfessorRegistrarDto());
        }

        [HttpGet("professorId/{id}")]
        public IActionResult Get(int id)
        {
            var professor = _repo.GetAllProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");

            return Ok(_mapper.Map<ProfessorDto>(professor));

        }

        [HttpPost]
        public IActionResult PostProfessor(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if(_repo.SaveChanges())
            {
                return Created($"/api/professor/professorId/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            };

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("UpdateProfessor/{id}")]
        public IActionResult PutProfessor(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetAllProfessorById(id);
            if (professor == null) return BadRequest("Não foi possivel alterar o professor");

            _mapper.Map(model, professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/professorId/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            };

            return BadRequest("Professor não atualizado");
        }

        [HttpDelete("DeleteProfessor/{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            var professor = _repo.GetAllProfessorById(id);
            if (professor == null) return BadRequest("Não Encontrado");

            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor " + professor.Name + " Deletado com Sucesso!");
            };

            return BadRequest("Professor não Deletado");
        }
    }
}
