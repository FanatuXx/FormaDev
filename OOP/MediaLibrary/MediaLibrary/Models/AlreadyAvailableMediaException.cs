using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Models
{
    public class AlreadyAvailableMediaException : Exception
    {
        //public string Message { get; set; }                                                   //PAS NECESSAIRE CAR L'EXCEPTION DE BASE CONTIENT DEJA UN MESSAGE

        public AlreadyAvailableMediaException() : base("Le média est déjà disponible")
        {
        }

        public AlreadyAvailableMediaException(string message) : base(message)
        {
        }

        public AlreadyAvailableMediaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
