using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Models
{
    public class MediaLibrary
    {
        private Dictionary<string, Media> medias;

        public Dictionary<string, Media> Medias
        {
            get { return medias; }
            private set { medias = value; }
        }

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
            Medias.Add(media.Isbn, media);
        }

        public void Remove(string Isbn)
        {
            Medias.Remove(Isbn);
        }

        public void NotifySubscriber(string recipient, string message)
        { 
            Notifier.Send(recipient, message);
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


    
