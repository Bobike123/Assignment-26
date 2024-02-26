public interface IFinance
{
    void AddTransaction(Transaction transaction);
    List<Transaction> GetTransactions();
    List<Transaction> GetTransactionsByCategory(string category);
    decimal CalculateTotalIncome();
    decimal CalculateTotalExpenses();
    decimal CalculateBalance();
    void LoadTransactions(List<Transaction> transactions); // Add this method
}
