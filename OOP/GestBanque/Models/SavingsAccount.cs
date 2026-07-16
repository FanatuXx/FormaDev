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
            set
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
            if (Balance - amount >= 0)
            {
                LastWithdrawalDate = DateTime.Now;
                base.Withdrawal(amount);
            }
        }

        protected override double InterestCalculation()
        {
            return Balance * 0.045;
        }
    }
}
