namespace WebApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public virtual Owner Owner { get; set; }
        public int? OwnerId { get; set; }
    }
}
