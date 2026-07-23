using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Models
{
    public class AlreadyAvailableMediaException : Exception
    {
        public string Message { get; set; }

        public AlreadyAvailableMediaException()
        {
            Message = "Le média ne peut être retourné puisqu'il est déjà en stock";
        }
    }
}
