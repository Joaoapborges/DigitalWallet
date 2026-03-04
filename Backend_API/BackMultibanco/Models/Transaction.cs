using System.ComponentModel.DataAnnotations.Schema;

namespace BackMultibanco.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }

        // sender
        public int? SenderCardId { get; set; }
        [ForeignKey("SenderCardId")]
        public Card? SenderCard { get; set; }

        // reciver
        public int? ReceiverCardId { get; set; }
        [ForeignKey("ReciverCardId")]
        public Card? ReciverCard { get; set; }

        // acrescentei
        public decimal Fee { get; set; }


    }
}
