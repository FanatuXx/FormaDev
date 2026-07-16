using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Account
    {
        private double balance = 0;
        public Person holder;
        public string AccountNumber { get; set; }


        public virtual double Balance
        {
            get
            {
                return balance;
            }
            
            private set
            {
                balance = value;
            }
        }

        public Person Holder
        {
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

        public virtual void Withdrawal(double amount)
        {
            Balance -= amount;
        }

        protected abstract double InterestCalculation();


        public void ApplicateInterest()
        {
            Balance += InterestCalculation();
        }



        public static double operator +(Account c1, double amount)
        {
            if (c1.Balance > 0)
            {
                return c1.Balance + amount;
            }

            return amount;
        }

        public static double operator +(double amount, Account c1)
        {
            return c1 + amount;
        }
    }
}
