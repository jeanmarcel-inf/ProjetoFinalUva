using System.ComponentModel.DataAnnotations;

namespace Uva.ProjetoFinal.Models
{
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }

    }
}
