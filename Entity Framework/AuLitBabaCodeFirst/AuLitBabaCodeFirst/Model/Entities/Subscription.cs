using System.ComponentModel.DataAnnotations;

namespace AuLitBabaCodeFirst.Model.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal MonthlyPrice { get; set; }
        public int ContractDuration { get; set; }
        public bool IsPremium { get; set; }

        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}
