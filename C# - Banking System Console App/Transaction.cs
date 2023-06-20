using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus
{
    public class Transaction
    {
        public string Date { get; }
        public TransactionType Type { get; }
        public double Amount { get; }

        public Transaction(TransactionType type, double amount)
        {
            Date = DateTime.Now.ToString("M/dd/yyyy");
            Type = type;
            Amount = amount;
        }

        public static implicit operator Transaction(List<Transaction> v)
        {
            throw new NotImplementedException();
        }
    }

    public enum TransactionType
    {
        Deposit,
        Withdraw,
        TransferOut,
        Penalty,
        TransferIn,
        Interest
    }
}
