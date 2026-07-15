using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CheckingAccount
    {
        private double balance = 0;
        private double creditLine = 50;
        public Person holder;

        public static double operator +(CheckingAccount c1, double amount)
        {
            if (c1.Balance > 0)
            {
                return c1.Balance + amount;
            }

            else
            {
                return c1.Balance;
            }
        }

        public string AccountNumber { get; set; }

        public double Balance {
            get
            {
                return balance;
            }
            private set
            {
                if (value >= -CreditLine)
                {
                    balance = value;
                }
            }
        }

        public double CreditLine {
            get
            {
                return CreditLine;
            }
            set
            {
                if (value >= 0)
                {
                    CreditLine = value;
                }
            }
        }

        public Person Holder {
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
            Balance += amount;
        }

        public void Withdrawal(double amount)
        {
            Balance -= amount;
        }

        public double GetAccounts(Person holder)
        {

        }
    }
}
