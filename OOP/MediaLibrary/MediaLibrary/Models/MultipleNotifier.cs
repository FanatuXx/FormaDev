using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MultipleNotifier : INotifier
    {
        //private Action<string, string> _actions;
        private readonly List<INotifier> _notifiers = new List<INotifier>();
        public void Add(INotifier notifier)
        {
            if (notifier != null)
            {
            _notifiers.Add(notifier);
            }
        }


        public void Send(string recipient, string message)
        {
            foreach (var notifier in _notifiers) 
            {
                notifier.Send(recipient, message);
            }
        }
    }
}
