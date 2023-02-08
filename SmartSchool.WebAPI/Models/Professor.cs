namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor(int id, int registro, string name, string sobrenome, string telefone)
        {
            Id = id;
            Registro = registro;
            Name = name;
            Sobrenome = sobrenome;
            Telefone = telefone;
        }
        public Professor()
        {
        }

        public int Id { get; set; }
        public int Registro { get; set; }
        public string Name { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
