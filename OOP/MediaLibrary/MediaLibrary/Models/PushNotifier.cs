using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PushNotifier : INotifier
    {
        public void Send(string recipient,  string message)
        {
            Console.WriteLine($"[PUSH] {recipient} - {message}");
        }
    }
}
