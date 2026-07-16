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

            set
            {
                if (value >= 0)
                {
                    CreditLine = value;
                }
            }
        }

        public override void Withdrawal(double amount)
        {
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
    }
}
