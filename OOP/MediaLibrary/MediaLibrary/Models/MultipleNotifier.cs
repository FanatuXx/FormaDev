using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MultipleNotifier : INotifier
    {
        //private Action<string, string> _actions;
        private List<INotifier> notifiers = new List<INotifier>();
        public void Add(INotifier notifier)
        {
            //_actions += notifier.Send;
            notifiers.Add(notifier);
        }


        public void Send(string recipient, string message)
        {
            //_actions?.Invoke(recipient, message);
            foreach (var notifier in notifiers) {
                notifier.Send(recipient, message);
            }
        }
    }
}
