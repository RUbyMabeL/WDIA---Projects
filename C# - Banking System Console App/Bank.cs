using Bonus;
using System.Security.Principal;
using System.Xml.Linq;

Console.Write("Enter Customer Name: ");
string name = Console.ReadLine();
Customer customer = new Customer(name);

ChequingAccount chkaccount = new ChequingAccount();
SavingAccount savaccount = new SavingAccount();

customer.Accounts.Add(chkaccount);
customer.Accounts.Add(savaccount);

List<Transaction> transactions1 = new List<Transaction>();
List<Transaction> transactions2 = new List<Transaction>();

bool exit = false;
while (!exit)
{
    Console.WriteLine("\nSelect one of the following activities:\n");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Withdraw");
    Console.WriteLine("3. Transfer");
    Console.WriteLine("4. Account Activity Enquiry");
    Console.WriteLine("5. Balance Enquiry");
    Console.WriteLine("6. Exit\n");
    Console.Write("Enter your selection (1-6): ");
    int selection = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch (selection)
    {
        case 1:
            Console.Write("Select account (1 - Chequing Account, 2 - Saving Account) : ");
            int accountSelection = int.Parse(Console.ReadLine());
            Console.Write("\nEnter amount: ");
            double amount = double.Parse(Console.ReadLine());
            if (accountSelection == 1)
            {
                chkaccount.Deposit(amount);
                Console.WriteLine("\n     Deposit completed. Account current balance: $" + ChequingAccount.Balance);
                transactions1.Add(new Transaction(TransactionType.Deposit, amount));
            }
            else
            {
                savaccount.Deposit(amount);
                Console.WriteLine("\n     Deposit completed. Account current balance: $" + SavingAccount.Balance);
                transactions2.Add(new Transaction(TransactionType.Deposit, amount));
                transactions2.Add(new Transaction(TransactionType.Interest, amount * SavingAccount.InterestRate));
            }
            Console.WriteLine();
            break;

        case 2:
            Console.Write("Select account (1 - Chequing Account, 2 - Saving Account) : ");
            int accountSelection2 = int.Parse(Console.ReadLine());
            Console.Write("\nEnter amount: ");
            double amount2 = double.Parse(Console.ReadLine());
            if (accountSelection2 == 1)
            {
                if (amount2 > ChequingAccount.Balance)
                {
                    Console.WriteLine("\n     Insufficient fund. Account current balance: $" + ChequingAccount.Balance);
                }
                else if (amount2 > ChequingAccount.DailyWithdrawalLimit - ChequingAccount.DailyWithdrawalTotal)
                {
                    Console.WriteLine("\n     Exceed the daily max withdraw amount: $" + ChequingAccount.DailyWithdrawalLimit);
                }
                else
                {
                    chkaccount.Withdraw(amount2);
                    Console.WriteLine("\n     Withdraw completed. Account current balance: $" + ChequingAccount.Balance);
                    transactions1.Add(new Transaction(TransactionType.Withdraw, amount2));
                }
            }
            else
            {
                if (amount2 + SavingAccount.PenaltyAmount > SavingAccount.Balance)
                {
                    Console.WriteLine("\n     Insufficient fund. Account current balance: $" + SavingAccount.Balance);
                }
                else
                {
                    savaccount.Withdraw(amount2);
                    Console.WriteLine("\n     Withdraw completed. Account current balance: $" + SavingAccount.Balance);
                    transactions2.Add(new Transaction(TransactionType.Withdraw, amount2));
                    transactions2.Add(new Transaction(TransactionType.Penalty, SavingAccount.PenaltyAmount));
                }
            }
            Console.WriteLine();
            break;

        case 3:
            Console.Write("Select accounts (1 - from Chequing to Saving; 2 - from Saving to Chequing): ");
            int accountSelection3 = int.Parse(Console.ReadLine());
            Console.Write("\nEnter amount: ");
            double amount3 = double.Parse(Console.ReadLine());
            if (accountSelection3 == 1)
            {
                if (amount3 > ChequingAccount.Balance)
                {
                    Console.WriteLine("\n     Insufficient fund. Account current balance: $" + ChequingAccount.Balance);
                }
                else if (amount3 > ChequingAccount.DailyWithdrawalLimit - ChequingAccount.DailyWithdrawalTotal)
                {
                    Console.WriteLine("\n     Exceed the daily max withdraw amount: $" + ChequingAccount.DailyWithdrawalLimit);
                }
                else
                {
                    chkaccount.Transfer(savaccount, amount3);
                    Console.WriteLine("\n     Transfer completed.");
                    transactions1.Add(new Transaction(TransactionType.TransferOut, amount3));
                    transactions2.Add(new Transaction(TransactionType.TransferIn, amount3));
                }
            }
            else
            {
                if (amount3 + SavingAccount.PenaltyAmount > SavingAccount.Balance)
                {
                    Console.WriteLine("\n     Insufficient fund. Account current balance: $" + SavingAccount.Balance);
                }
                else
                {
                    savaccount.Transfer(chkaccount, amount3);
                    Console.WriteLine("\n     Transfer completed.");
                    transactions2.Add(new Transaction(TransactionType.TransferOut, amount3));
                    transactions1.Add(new Transaction(TransactionType.TransferIn, amount3));
                    transactions2.Add(new Transaction(TransactionType.Penalty, SavingAccount.PenaltyAmount));
                }
            }
            Console.WriteLine();
            break;

        case 4:
            Console.WriteLine("Chequing Account: \n");
            Console.WriteLine("\tAmount\t\t\tDate\t\t\tActivity");
            Console.WriteLine("\t------\t\t\t----\t\t\t--------");
            foreach (Transaction transaction in transactions1)
            {
                Console.WriteLine("\t$" + transaction.Amount + "\t\t\t" + transaction.Date + "\t\t" + transaction.Type);
            }
            Console.WriteLine();
            Console.WriteLine("Saving Account: \n");
            Console.WriteLine("\tAmount\t\t\tDate\t\t\tActivity");
            Console.WriteLine("\t------\t\t\t----\t\t\t--------");
            foreach (Transaction transaction in transactions2)
            {
                Console.WriteLine("\t$" + transaction.Amount + "\t\t\t" + transaction.Date + "\t\t" + transaction.Type);
            }
            Console.WriteLine();
            break;

        case 5:
            Console.WriteLine("Current Balance: ");
            Console.WriteLine("\tAccount\t\t\t\t\tBalance");
            Console.WriteLine("\t-------\t\t\t\t\t-------");
            Console.WriteLine("\tChequing\t\t\t\t" + "$" +ChequingAccount.Balance);
            Console.WriteLine("\tSaving\t\t\t\t\t" + "$" + SavingAccount.Balance);
            Console.WriteLine();
            break;

        case 6:
            Console.WriteLine("\nThank you for using Algonquin Banking System!");
            Environment.Exit(0);
            break;
    }
}
