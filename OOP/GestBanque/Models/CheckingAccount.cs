using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CheckingAccount : Account
    {

        private double creditLine = 50;

        public CheckingAccount(double bal) : base(bal)
        {
        }

        public override double Balance {
            get
            {
                return base.Balance;
            }

            private set
            {
                if (value >= -CreditLine)
                {
                    base.bal = value;
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
    }
}
