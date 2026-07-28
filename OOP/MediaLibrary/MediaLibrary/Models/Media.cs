using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Media
    {
        public string Isbn { get; private set; }
        public string Title { get; private set; }


        private bool isAvailable;
        public bool IsAvailable
        {
            get { return isAvailable; }
            private set { isAvailable = value; }
        }

        public Media(string isbn, string title, bool isAvailable) : this(isbn, title)
        {
            IsAvailable = isAvailable;
        }

        public Media(string isbn, string title)
        {
            Isbn = isbn;
            Title = title;
        }

        public void Borrow()
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException("Le média en question n'est pas disponible. Il n'est donc pas possible de l'emprunter.");
            }

            else
            {
                BorrowedMediaEvent?.Invoke(this);
                IsAvailable = false;
            }
        }

        public void Return()
        {
            if (IsAvailable)
            {
                throw new AlreadyAvailableMediaException();
            }

            IsAvailable = true;
        }

        public abstract int LoanDurationDays();

        public int ReturnDatePreview(DateTime loanDate)
        {
            int returnDate;
            returnDate = loanDate.Day + this.LoanDurationDays();
            return returnDate;
        }


        public Action<Media> BorrowedMediaEvent;
    }
}
