public class Transaction
{
    public Guid ID { get; private set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }

    public Transaction(DateTime date, string description, decimal amount, string category)
    {
        ID = Guid.NewGuid();
        Date = date;
        Description = description;
        Amount = amount;
        Category = category;
    }
}
