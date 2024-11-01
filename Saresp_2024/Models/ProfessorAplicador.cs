using System.ComponentModel.DataAnnotations;

namespace Saresp_2024.Models
{
    public class ProfessorAplicador
    {
        [Display(Name = "Código")]
        public int? IdProfessor { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string NomeProf { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O campo RG é obrigatorio")]
        public string RG { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo telefone é obrigatorio")]

        public ulong Telefone { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo CPF é obrigatorio")]

        public ulong CPF { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatorio")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

        
    }
}
