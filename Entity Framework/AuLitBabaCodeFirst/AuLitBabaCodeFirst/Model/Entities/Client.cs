using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuLitBabaCodeFirst.Model.Entities
{
    public class Client
    {
        //[Key]
        public int Id { get; set; }
        //[Required]
        //[StringLength(50)]
        public string LastName { get; set; } = null!;
        //[Required]
        //[StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        //[Required]
        //[StringLength(50)]
        //[EmailAddress]
        public string Email { get; set; } = null!;
        //[Required]
        public DateTime BirthDate { get; set; }
        public DateTime LastVisit { get; set; }
        public int SubscriptionId { get; set; }

        //[ForeignKey(nameof(SubscriptionId))]
        public Subscription Subscription { get; set; } //Subscription car One to One
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();  //ICollection car One to Many
    }
}
