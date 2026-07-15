using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CheckingAccount
    {
        private string accountNumber;
        private double balance;
        private double creditLine;
        private Person holder;

        private string AccountNumber {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
            } 
        }

        private double Balance {
            get
            {
                return balance;
            }
        }

        private double CreditLine {
            get
            {
                return CreditLine;
            }
            set
            {
                if (value <= 0)
                {
                    CreditLine = value;
                }
            }
        }

        private Person Holder {
            get
            {
                return holder;
            }
            set
            {
                holder = value;
            }
        }


        public void Deposit(double amount)
        {
            balance = Balance + amount;
        }

        public void Withdrawal(double amount)
        {
            if (Balance - amount > -CreditLine)
            {
                balance = Balance - amount;
            }
        }
    }
}
