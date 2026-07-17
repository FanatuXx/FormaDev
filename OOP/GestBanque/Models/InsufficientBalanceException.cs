using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class InsufficientBalanceException : Exception
    {
        public string Message { get; set; }

        public InsufficientBalanceException()
        {
            Message = "Your balance is too low to do this withdrawal.";
        }
    }
}
