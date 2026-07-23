using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ConsoleNotifier : INotifier
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"[CONSOLE] A {recipient} : {message}");
        }
    }
}
