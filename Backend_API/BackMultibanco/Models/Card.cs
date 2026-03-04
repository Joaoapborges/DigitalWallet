using System.ComponentModel.DataAnnotations.Schema;

namespace BackMultibanco.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }

        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account? Account { get; set; }


        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public Bank? Bank { get; set; }

    }
}
