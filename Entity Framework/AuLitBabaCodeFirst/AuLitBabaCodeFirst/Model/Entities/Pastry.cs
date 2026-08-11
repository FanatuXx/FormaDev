namespace AuLitBabaCodeFirst.Model.Entities
{
    public class Pastry
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StockQuantity { get; set; }
        public string Allergens { get; set; } = string.Empty;
        public string Taste { get; set; } = string.Empty;
        public bool IsReservedPremium { get; set; } = false;


        public  Reservation Reservation { get; set; }
        public ICollection<PastryCommand> Commands { get; set; } = new List<PastryCommand>();

    }
}
