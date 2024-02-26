public class FinanceTracker : IFinance
{
    private List<Transaction> transactions;

    public FinanceTracker()
    {
        transactions = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public List<Transaction> GetTransactions()
    {
        return transactions;
    }

    public List<Transaction> GetTransactionsByCategory(string category)
    {
        return transactions.FindAll(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
    }

    public decimal CalculateTotalIncome()
    {
        return transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
    }

    public decimal CalculateTotalExpenses()
    {
        return transactions.Where(t => t.Amount < 0).Sum(t => t.Amount);
    }

    public decimal CalculateBalance()
    {
        return transactions.Sum(t => t.Amount);
    }

    public void LoadTransactions(List<Transaction> loadedTransactions)
    {
        transactions = loadedTransactions;
    }
}
