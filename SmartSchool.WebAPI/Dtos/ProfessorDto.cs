using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Dtos
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Name { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;

    }
}
