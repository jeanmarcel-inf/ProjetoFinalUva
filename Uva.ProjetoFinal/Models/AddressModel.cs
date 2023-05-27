using Azure.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.ProjetoFinal.Models
{
    public class AddressModel
    {
        [Key]
        public int Id { get; set; }
        public string Cep { get; set; }
        public string HomeNumber { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
    }
}
