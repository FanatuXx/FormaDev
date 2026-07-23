using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Account : IBanker
    {
        private double balance = 0;
        public Person holder;
        public string AccountNumber { get; private set; }


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
            private set
            {
                holder = value;
            }
        }

        public Account(string accountNumber, Person holder)
        {
            AccountNumber = accountNumber;
            Holder = holder;
        }

        public Account(string accountNumber, Person holder, double balance): this(accountNumber, holder)
        {
            Balance = balance;
        }


        public void Deposit(double amount)
        {
            if (!(amount > 0))
            {
                throw new ArgumentOutOfRangeException("montant", "Le montant déposé doit être plus grand que 0.");
            }

            Balance += amount;

            if (balance < 0)
            {

            }
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

        //public event SwitchToNegativeDelegate SwitchToNegativeEvent;
        public event Action<Account> SwitchToNegativeEvent = null;


        protected void TriggerSwitchToNegativeEvent()
        {
            SwitchToNegativeEvent?.Invoke(this);
        }

    }
}
