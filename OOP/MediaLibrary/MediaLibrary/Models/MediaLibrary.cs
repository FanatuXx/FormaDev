using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Text;

namespace Models
{
    public class MediaLibrary
    {
        private Dictionary<string, Media> medias = new Dictionary<string, Media>();

        public Dictionary<string, Media> Medias { get; init; }

        public string Name { get; set; }

        public INotifier Notifier { get; set; }



        //INDEXEUR
        public Media this[string Isbn]
        {
            get
            {
                Media media;
                Medias.TryGetValue(Isbn, out media);
                return media;
            }

            set
            {
                Medias[Isbn] = value;
            }
        }

        public void Add(Media media)
        {
            if(!medias.ContainsKey(media.Isbn))
            {
                media.BorrowedMediaEvent += BorrowedMediaAction;
                medias.Add(media.Isbn, media);
            }
        }


        public void Remove(string Isbn)
        {
            if(medias.ContainsKey(Isbn))
            {
                medias[Isbn].BorrowedMediaEvent -= BorrowedMediaAction;
                medias.Remove(Isbn);
            }
        }

        public void NotifySubscriber(string recipient, string message)
        { 
            Notifier.Send(recipient, message);
        }

        public void BorrowedMediaAction(Media media)
        {
            Console.WriteLine($"Le média {media.Title} vient d'être emprunté");
        }


        public static MediaLibrary operator +(MediaLibrary mediaLibrary1, MediaLibrary mediaLibrary2)
        {
            MediaLibrary finalMediaLibrary = new MediaLibrary();
            
            foreach (KeyValuePair<string, Media> keyValuePair in mediaLibrary1.Medias)
            {
                finalMediaLibrary.Medias.Add(keyValuePair.Key, keyValuePair.Value);
            }

            foreach (KeyValuePair<string, Media> keyValuePair in mediaLibrary2.Medias)
            {
                if(!finalMediaLibrary.Medias.ContainsKey(keyValuePair.Key))
                finalMediaLibrary.Medias.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return finalMediaLibrary;
        }
    }
}


    
