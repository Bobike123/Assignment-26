public interface IFinanceStorage
{
    List<Transaction> LoadTransactions();
    void SaveTransactions(List<Transaction> transactions);
}
