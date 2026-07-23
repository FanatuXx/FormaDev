using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SmsNotifier : INotifier
    {
        public void Send(string recipient, string message)
        {
            message = message.Length > 160 ? message.Substring(0, 157) + "..." : message;
            Console.WriteLine($"[SMS] vers {recipient} : {message}");  
        }
    }
}
