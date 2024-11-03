using System.ComponentModel.DataAnnotations;

namespace Saresp_2024.Models
{
    public class Aluno
    {
        [Display(Name = "Código")]
        public int? IdAluno { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string NomeAluno { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatorio")]
        public string Email { get; set; }

        [Display(Name = "Turma")]
        [Required(ErrorMessage = "O campo Turma é obrigatorio")]
        public string Turma { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo telefone é obrigatorio")]

        public ulong Telefone { get; set; }

        [Display(Name = "Serie")]
        [Required(ErrorMessage = "O campo Serie é obrigatorio")]

        public int Serie { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatorio")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }
    }
}
