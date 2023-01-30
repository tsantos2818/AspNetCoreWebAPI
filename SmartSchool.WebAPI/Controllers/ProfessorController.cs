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
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byid/{id}")]
        public IActionResult Get(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);

        }

        [HttpPost]
        public IActionResult PostProfessor(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpPut("UpdateProfessor/{id}")]
        public IActionResult PutProfessor(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (prof == null) return BadRequest("Não foi possivel alterar o professor");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete("DeleteProfessor/{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (professor == null) return BadRequest("Não Encontrado");

            _context.Remove(professor);
            _context.SaveChanges();

            return Ok("Professor " + professor.Name + " Deletado com Sucesso!");
        }
    }
}
