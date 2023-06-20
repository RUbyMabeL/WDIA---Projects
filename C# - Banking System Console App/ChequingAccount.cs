using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus
{
    public class ChequingAccount : Account
    {
        public static double Balance { get; protected set; } = 0;
        public static double DailyWithdrawalLimit { get; } = 300;
        public static double DailyWithdrawalTotal { get; private set; } = 0;

        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            DailyWithdrawalTotal += amount;
        }

        public override void Transfer(Account destinationAccount, double amount)
        {
            Balance -= amount;
            destinationAccount.Deposit(amount);
            DailyWithdrawalTotal += amount;
        }
    }
}