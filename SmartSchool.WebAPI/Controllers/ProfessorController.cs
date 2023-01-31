using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
           _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return new JsonResult(result);
        }

        [HttpGet("byid/{id}")]
        public IActionResult Get(int id)
        {
            var professor = _repo.GetAllProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);

        }

        [HttpPost]
        public IActionResult PostProfessor(Professor professor)
        {
            _repo.Add(professor);
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            };

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("UpdateProfessor/{id}")]
        public IActionResult PutProfessor(int id, Professor professor)
        {
            var prof = _repo.GetAllProfessorById(id);
            if (prof == null) return BadRequest("Não foi possivel alterar o professor");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
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
