using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        // GET api/<AlunoController>/5
        [HttpGet("alunoId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAllAlunoById(id,false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado");

            //_context.Add(aluno);
            //_context.SaveChanges();
            //return Ok(aluno);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAllAlunoById(id);
            if (alu == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não Atualizado");

            //_context.Update(aluno);
            //_context.SaveChanges();
            //return Ok(aluno);
        }

        // Patch api/<AlunoController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAllAlunoById(id);
            if (alu == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não Atualizado");

            //_context.Update(aluno);
            //_context.SaveChanges();
            //return Ok(aluno);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAllAlunoById(id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno " + aluno.Nome + " Deletado com Sucesso!"); ;
            }

            return BadRequest("Aluno " + aluno.Nome + " Não Deletado com Sucesso!");

            //_context.Remove(aluno);
            //_context.SaveChanges();
            //return Ok("Aluno " + aluno.Nome + " Deletado com Sucesso!");
        }
    }
}
