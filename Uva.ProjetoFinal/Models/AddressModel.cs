using Azure.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.ProjetoFinal.Models
{
    public class AddressModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(8)]
        [MinLength(8, ErrorMessage = "Minimo de caracteres não foi alcançado")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string HomeNumber { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
    }
}
