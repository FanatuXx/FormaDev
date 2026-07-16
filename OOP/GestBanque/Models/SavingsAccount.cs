using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SavingsAccount : Account
    {
        public DateTime lastWithdrawalDate { get; set; }
    }
}
