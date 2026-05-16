namespace Spendle.API.Models;

public class Transaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public Decimal Amount { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public bool IsRecurring { get; set; }
}