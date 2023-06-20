using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus
{
    public class Account
    {

        public virtual void Deposit(double amount)
        {
        }

        public virtual void Withdraw(double amount)
        {
        }

        public virtual void Transfer(Account destinationAccount, double amount)
        {
        }
    }
}