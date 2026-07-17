using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SavingsAccount : Account
    {
        private DateTime lastWithdrawalDate;
        public DateTime LastWithdrawalDate
        {
            get
            {
                return lastWithdrawalDate;
            }
            private set
            {
                DateTime today = DateTime.Now;
                //Check si la valeur rentrée n'est pas dans le futur OU + de 110ans dans le passé
                if (value <= today)
                {
                    lastWithdrawalDate = value;
                }
            }
        }

        public override void Withdrawal(double amount)
        {
            if (Balance - amount < 0)
            {
                throw new InsufficientBalanceException();
            }
            LastWithdrawalDate = DateTime.Now;
            base.Withdrawal(amount);
        }

        protected override double InterestCalculation()
        {
            return Balance * 0.045;
        }


        public SavingsAccount(string accountNumber, Person holder) : this(accountNumber, holder, 0)
        {
        }

        public SavingsAccount(string accountNumber, Person holder, double balance) : base(accountNumber, holder, balance)
        {
        }
    }
}
