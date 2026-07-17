using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface ICustomer
    {
        double Balance { get; }

        void Withdrawal(double amount);
        void Deposit(double amount);

    }

    public interface IBanker : ICustomer
    {
        Person Holder { get; }
        string AccountNumber { get; }

        void ApplicateInterest();
    }
}
