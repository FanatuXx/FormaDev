using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EmailNotifier : INotifier
    {
        private string sender;

        public string Sender
        {
            get { return sender; }
            private set { sender = value; }
        }

        public EmailNotifier(string sender)
        {
            Sender = sender;
        }


        public void Send(string recipient, string message)
        {
            Console.WriteLine($"[EMAIL] Envoi d'un mail à {recipient}\nObjet : Notification médiathèque\nCorps : {message}");
        }
    }
}
