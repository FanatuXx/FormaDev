using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface INotifier
    {
        void Send(string recipient, string message);
    }
}
