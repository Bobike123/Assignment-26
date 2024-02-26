class Program
{
    static void Main(string[] args)
    {
        IFinance financeTracker = new FinanceTracker();
        IFinanceStorage financeStorage = new JsonFinanceStorage(); 

        financeTracker.LoadTransactions(financeStorage.LoadTransactions()); 

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Welcome to Personal Finance Tracker!");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. View Transactions");
            Console.WriteLine("3. View Financial Summaries");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    AddTransaction(financeTracker);
                    break;
                case "2":
                    Console.Clear();
                    ViewTransactions(financeTracker);
                    break;
                case "3":
                    Console.Clear();
                    ViewFinancialSummaries(financeTracker);
                    break;
                case "4":
                    Console.Clear();
                    exit = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        financeStorage.SaveTransactions(financeTracker.GetTransactions()); 
    }

    static void AddTransaction(IFinance financeTracker)
    {
        Console.WriteLine("Enter transaction details:");

        Console.Write("Date (dd/mm/yyyy): ");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
        {
            Console.WriteLine("Invalid date format. Please enter date in dd/mm/yyyy format.");
            Console.Write("Date (dd/mm/yyyy): ");
        }

        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        decimal amount;
        Console.Write("Amount: ");
        while (!decimal.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Invalid amount. Please enter a valid number.");
            Console.Write("Amount: ");
        }

        Console.Write("Category: ");
        string category = Console.ReadLine() ?? ""; 


        financeTracker.AddTransaction(new Transaction(date, description, amount, category));

        Console.WriteLine("Transaction added successfully!");
    }


    static void ViewTransactions(IFinance financeTracker)
    {
        Console.WriteLine("Transactions:");
        var transactions = financeTracker.GetTransactions();
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"ID: {transaction.ID}, Date: {transaction.Date.ToShortDateString()}, Description: {transaction.Description}, Amount: {transaction.Amount}, Category: {transaction.Category}");
        }
    }

    static void ViewFinancialSummaries(IFinance financeTracker)
    {
        decimal totalIncome = financeTracker.CalculateTotalIncome();
        decimal totalExpenses = financeTracker.CalculateTotalExpenses();
        decimal balance = financeTracker.CalculateBalance();

        Console.WriteLine($"Total Income: {totalIncome}");
        Console.WriteLine($"Total Expenses: {totalExpenses}");
        Console.WriteLine($"Balance: {balance}");
    }
}
