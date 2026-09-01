namespace Label.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genra { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
