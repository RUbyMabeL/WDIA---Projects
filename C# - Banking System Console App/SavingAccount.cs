using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bonus
{
    public class SavingAccount : Account
    {
        public static double Balance { get; protected set; } = 0;
        public static double InterestRate { get; } = 0.03;
        public static int PenaltyAmount { get; } = 10;

        public override void Deposit(double amount)
        {
            Balance += amount + (amount * InterestRate);
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount + PenaltyAmount;
        }

        public override void Transfer(Account destinationAccount, double amount)
        {
            Balance -= amount + PenaltyAmount;
            destinationAccount.Deposit(amount);
        }
    }
}
