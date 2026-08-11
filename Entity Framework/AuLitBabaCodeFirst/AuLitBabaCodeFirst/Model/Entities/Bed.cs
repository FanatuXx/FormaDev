namespace AuLitBabaCodeFirst.Model.Entities
{
    public class Bed
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;  //Permettra aux personnel d'identitfier les lits             null! => ne peut PAS être null
        public string Size { get; set; } = string.Empty;
        public bool IsPremium { get; set; }
        public string PillowType { get; set; } = string.Empty;


        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
