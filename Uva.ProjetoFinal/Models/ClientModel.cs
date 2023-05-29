using System.ComponentModel.DataAnnotations;

namespace Uva.ProjetoFinal.Models
{
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(11)]
        [MinLength(11, ErrorMessage = "Minimo de caracteres não foi atingido")]
        public string Cpf { get; set; }
    }
}
