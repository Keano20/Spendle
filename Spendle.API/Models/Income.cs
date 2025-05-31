namespace Spendle.API.Models
{
    public class Income
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Source { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}