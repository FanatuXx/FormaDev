using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Bank
    {
        public string Name { get; init; }

        private Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        public Dictionary<string, Account> Accounts { get; init; }

        public Account this[string accountNumber]
        {
            get
            {
                Account account;
                Accounts.TryGetValue(accountNumber, out account);
                return account;
            }

            set
            {
                Accounts[accountNumber] = value;
            }
        }

        public void Add(Account account)
        {
            if (!accounts.ContainsKey(account.AccountNumber))
            {
                account.SwitchToNegativeEvent += SwitchToNegativeAction;
                Accounts[account.AccountNumber] = account;
            }
        }

        public void Remove(string accountNumber)
        {
            Account a = Accounts[accountNumber];
            a.SwitchToNegativeEvent -= SwitchToNegativeAction;
            Accounts.Remove(accountNumber);
            
        }


        //Voir CheckingAccount.cs pour comprendre pourquoi il est possible d'utiliser le + entre un double ou un objet CheckingAccount
        public double GetAccounts(Person holder)
        {
            double totalBalance = 0;

            foreach (Account acc in Accounts.Values)
            {
                if (acc.holder == holder)
                {
                    totalBalance += acc;
                }
            }

            return totalBalance;
        }

        public Bank(string name)
        {
            Name = name;
        }

        public void SwitchToNegativeAction(Account account)
        {
            Console.WriteLine($"Le compte {account.AccountNumber} est passé en négatif");
        }
    }
}
