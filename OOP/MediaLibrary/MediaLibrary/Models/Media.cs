using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Media
    {
        //PROPRIETES
        public string Isbn { get; private set; }
        public string Title { get; private set; }
        public bool IsAvailable { get; private set; } = true;                       //Permet de mettre la propriété en lecture seule et lui attribuer une valeur par défaut = true !

        //Autre manière de faire, mais sans valeur par défaut !

        //private bool isAvailable;
        //public bool IsAvailable
        //{
        //    get { return isAvailable; }
        //    private set { isAvailable = value; }
        //}




        //CONSTRUCTEURS
        protected Media(string isbn, string title)
        {
            Isbn = isbn;
            Title = title;
        }

        public Media(string isbn, string title, bool isAvailable) : this(isbn, title)
        {
            IsAvailable = isAvailable;
        }



        //EVENT
        public Action<Media>? BorrowedMediaEvent;                                   //Le "?" permet de dire au programme qu'on est certain que le type ne sera pas null et ainsi enlever l'avertissement de console
                                                                                    // Action<Type> = event TypeDelegate DelegateEvent => Permet de lier la classe à l'appel d'événements



        //FONCTIONS
        public virtual void Borrow()                                                //Virtual = possibilité d'override dans les fonctions enfants
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException($"Le média {Title} (ISBN : {Isbn}) n'est pas disponible. Il n'est donc pas possible de l'emprunter.");
            }

            IsAvailable = false;
            BorrowedMediaEvent?.Invoke(this);                                       //Event?.Invoke(this) => Permet d'appeler l'événement => Va vérifier si des fonctions sont liées (+= / -=) à cet événement
        }

        public virtual void Return()                                                //Virtual = possibilité d'override dans les fonctions enfants
        {
            if (IsAvailable)
            {
                throw new AlreadyAvailableMediaException($"Le média {Title} (ISBN: {Isbn}) est déjà disponible, impossible de le retourner.");
            }
            IsAvailable = true;
        }

        public abstract int LoanDurationDays();


        public DateTime ReturnDatePreview(DateTime loanDate)
        {
            return loanDate.AddDays(LoanDurationDays());
        }

        //COMMENT MOI J'AVAIS FAIT
        //public int ReturnDatePreview(DateTime loanDate)
        //{
        //    int returnDate;
        //    returnDate = loanDate.Day + this.LoanDurationDays();
        //    return returnDate;
        //}

    }
}
