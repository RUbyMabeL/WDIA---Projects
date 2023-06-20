using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus
{
    public class Customer
    {
        public string Name { get; }
        public List<Account> Accounts = new List<Account> { };

        public Customer(string name)
        {
            Name = name;
        }
    }
}
