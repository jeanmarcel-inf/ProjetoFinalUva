using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.ProjetoFinal.Models
{
    public class EmailModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual ClientModel Client { get; set; }

    }
}
