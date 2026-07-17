using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CheckingAccount : Account
    {

        private double creditLine = 50;


        public double CreditLine {
            get
            {
                return CreditLine;
            }

            private set
            {
                if (!(value >= 0))
                {
                    throw new InvalidOperationException("La ligne de crédit ne peut être négative");
                }
                CreditLine = value;
            }
        }

        public override void Withdrawal(double amount)
        {
            if (Balance - amount < -CreditLine)
            {
                throw new InsufficientBalanceException();
            }
            base.Withdrawal(amount);
        }

        protected override double InterestCalculation()
        {
            if (Balance >= 0)
            {
                return Balance * 0.03;
            }

            return Balance * 0.0975;
        }


        public CheckingAccount(string accountNumber, Person holder) : this(accountNumber, holder, 0, 0)
        {
        }

        public CheckingAccount(string accountNumber, Person holder, double balance) : this(accountNumber, holder, balance, 0)
        {
        }

        public CheckingAccount(string accountNumber, Person holder, double balance, double creditLine) : base(accountNumber, holder, balance)
        {
            CreditLine = creditLine;
        }
    }
}
