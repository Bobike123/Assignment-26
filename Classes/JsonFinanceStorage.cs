using System.Text.Json;

public class JsonFinanceStorage : IFinanceStorage
{
    private string filePath;

    public JsonFinanceStorage()
    {
        filePath = "transactions.json";
    }

    public List<Transaction> LoadTransactions()
    {
        List<Transaction> transactions = new List<Transaction>();

        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonContent) ?? new List<Transaction>();
        }

        return transactions;
    }

    public void SaveTransactions(List<Transaction> transactions)
    {
        string jsonContent = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonContent);
    }
}
