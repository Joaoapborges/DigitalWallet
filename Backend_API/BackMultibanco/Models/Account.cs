using System.ComponentModel.DataAnnotations.Schema;

namespace BackMultibanco.Models
{
    public class Account
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}
