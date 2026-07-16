using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Banque
    {
        public string Name { get; set; }

        private Dictionary<string, CheckingAccount> accounts = new Dictionary<string, CheckingAccount>();

        public Dictionary<string, CheckingAccount> Accounts { get; set; }

        public CheckingAccount this[string accountNumber]
        {
            get
            {
                CheckingAccount account;
                Accounts.TryGetValue(accountNumber, out account);
                return account;
            }

            set
            {
                Accounts[accountNumber] = value;
            }
        }

        public void Add(CheckingAccount account)
        {
            if (!accounts.ContainsKey(account.AccountNumber))
            {
                Accounts[account.AccountNumber] = account;
            }
        }

        public void Remove(string accountNumber)
        {
            Accounts.Remove(accountNumber);
        }


        //Voir CheckingAccount.cs pour comprendre pourquoi il est possible d'utiliser le + entre un double ou un objet CheckingAccount
        public double GetAccounts(Person holder)
        {
            double totalBalance = 0;

            foreach (CheckingAccount acc in Accounts.Values)
            {
                if (acc.holder == holder)
                {
                    totalBalance += acc;
                }
            }

            return totalBalance;
        }
    }
}
