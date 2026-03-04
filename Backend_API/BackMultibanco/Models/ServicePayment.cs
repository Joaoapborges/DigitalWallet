using System.ComponentModel.DataAnnotations.Schema;

namespace BackMultibanco.Models
{
    public class ServicePayment
    {
        public int Id { get; set; }
        public string Entity { get; set; }
        public string Reference { get; set; }


        public int ServiceProviderId { get; set; }
        [ForeignKey("ServiceProviderId")]
        public ServiceProvider ServiceProvider { get; set; }


        public int TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public Transaction Transaction { get; set; }

    }
}
