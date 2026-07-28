using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReturnService
    {
        private void Scan(Media media)
        {
            Console.WriteLine($"Je scanne le média : {media.Title}");
        }

        private void StatusControl(Media media)
        {
            Console.WriteLine($"Je contrôle l'état de : {media.Title}");
        }

        private void Disinfect(Media media)
        {
            Console.WriteLine($"Je désinfecte : {media.Title}");
        }

        private void MakeAvailable(Media media)
        {
            try
            {
                media.Return();
            }

            catch (AlreadyAvailableMediaException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Je remets en rayon : {media.Title}");
        }

        private void PutAway(Media media)
        {
            Console.WriteLine($"Je range en rayon : {media.Title}");
        }

        public void ProcessReturn(Media media)
        {
            ReturnsHandlingDelegate processing = Scan; //On instancie le delegate avec une valeur de base           
            processing += StatusControl;               //On passe au delegate toutes les fonctions qu'il va devoir appeler 
            processing += Disinfect;
            processing += MakeAvailable;
            processing += PutAway;

            processing(media);
        }

        public void AnonymousProcessReturn(Media media)
        {
            ReturnsHandlingDelegate processing = (Media media) => Console.WriteLine($"[ANONYME] Je scanne le média : {media.Title}");
            processing += (Media media) => Console.WriteLine($"Je contrôle l'état de : {media.Title}");
            processing += (Media media) =>
            {
                media.Return();
                Console.WriteLine($"Je remets en rayon : {media.Title}");
            };
            processing += (Media media) => Console.WriteLine($"Je range en rayon : {media.Title}");
            
            processing(media);
        }
    }
}
