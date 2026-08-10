namespace AuLitBabaCodeFirst.Model.Entities
{
    public class PastryCommand
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int PastryId {  get; set; }
        public int OrderedQuantity { get; set; }

        public Reservation Reservation { get; set; } = null!;
        public virtual Pastry Pastry { get; set; } = null!;
    }
}
