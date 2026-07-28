using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Text;

namespace Models
{
    public class MediaLibrary
    {
        //VARIABLE
        private readonly Dictionary<string, Media> _medias = new();                     // = new(); équivaut à = new Dictionary<string, Media>(); dans ce cas-ci


        //CONSTRUCTEURS
        public KeyValuePair<string, Media>[] Medias => _medias.ToArray();               //Renvoie un tableau de key-value qui est UNE COPIE de _medias
        //public Dictionary<string, Media> Medias { get; init; }                        //ATTENTION : ici, le code renvoie la référence mémoire du dictionaire, et donc l'ouvre à la modification (CE QU'ON NE VEUT PAS!)

        public string Name { get; set; } = string.Empty;                                //Valeur par défaut = ""

        public INotifier? Notifier { get; set; }



        //INDEXEUR
        public Media? this[string isbn]
        {
            get
            {
                return _medias.GetValueOrDefault(isbn);                                 //Le tableau de KeyValuePair nécessite l'utilisation de GetValueOrDefault à la place de TryGetValue
                //Media media;
                //Medias.TryGetValue(isbn, out media);
                //return media;
            }

            //set                                                                       //Le set n'est pas nécessaire
            //{
            //    Medias[Isbn] = value;
            //}
        }

        public void Add(Media media)
        {
            if (media != null && !string.IsNullOrEmpty(media.Isbn))                     //Vérifie si l'objet donné en paramètre a été instancier au préalable et si son ISBN contient bien une valeur
            {
                _medias[media.Isbn] = media;
                media.BorrowedMediaEvent += OnBorrowedMedia;
            }
            //if(!_medias.ContainsKey(media.Isbn))
            //{
            //    media.BorrowedMediaEvent += BorrowedMediaAction;
            //    _medias.Add(media.Isbn, media);
            //}
        }


        public void Remove(string isbn)                                                 
        {
            //if(_medias.ContainsKey(Isbn))
            if(!string.IsNullOrEmpty(isbn))                                             //Vérifie si l'ISBN contient bien une valeur                        
            {
                var media = this[isbn];
                if(media != null)
                {
                    media.BorrowedMediaEvent -= OnBorrowedMedia;
                    _medias.Remove(isbn);
                }
            }
        }

        public void NotifySubscriber(string recipient, string message)
        { 
            Notifier?.Send(recipient, message);
        }

        public void OnBorrowedMedia(Media media)                                        //On... = Action qui se passe quand l'event X est trigger ! Dans la même classe que l'endroit 
        {
            Console.WriteLine($"Le média {media.Title} vient d'être emprunté");
        }


        public static MediaLibrary operator +(MediaLibrary mediaLibrary1, MediaLibrary mediaLibrary2)
        {
            if (mediaLibrary1 == null) throw new ArgumentNullException(nameof(mediaLibrary1));                           //Préviens les cas ou les librairies n'auraient pas encore été instanciées 
            if (mediaLibrary2 == null) throw new ArgumentNullException(nameof(mediaLibrary2));

            MediaLibrary finalMediaLibrary = new MediaLibrary { Name = $"{mediaLibrary1.Name} & {mediaLibrary2.Name}" }; //Permet de donner un nom à la nouvelle library 
            
            foreach (KeyValuePair<string, Media> keyValuePair in mediaLibrary1.Medias)
            {
                finalMediaLibrary.Add(keyValuePair.Value);
            }

            foreach (KeyValuePair<string, Media> keyValuePair in mediaLibrary2.Medias)
            {
                if (finalMediaLibrary[keyValuePair.Key] == null)
                {
                    finalMediaLibrary.Add(keyValuePair.Value);
                }
            }
            return finalMediaLibrary;
        }
    }
}


    
