using Microsoft.AspNetCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.ProjetoFinal.Models
{
    public class BrowsingHistoryModel
    {
        [Key]
        public int Id { get; set; }
        public string? Ip { get; set; }
        public DateTime? LastAccess { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
    }
}
