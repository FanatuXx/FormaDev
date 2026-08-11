namespace AuLitBabaCodeFirst.Model.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        //public int PastryID { get; set; }

        public int BedId { get; set; }

        //public bool Premium { get; set; }

        public DateTime BegginingDateHour { get; set; }
        public DateTime GetEndDateHour() => BegginingDateHour.AddHours(1);
        public bool IsActive() => DateTime.Now >= BegginingDateHour && DateTime.Now <= GetEndDateHour();

        //public decimal Price { get; set; }

        public Bed Bed { get; set; } = null!;
        public Client Client { get; set; } = null!;
        public ICollection<PastryCommand> Commands { get; set; } = new List<PastryCommand>();
        //public virtual Pastry Pastry { get; set; }
    }
}
