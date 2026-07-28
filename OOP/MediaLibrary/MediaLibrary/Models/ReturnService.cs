using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReturnService
    {
        //private void Scan(Media media)
        //{
        //    Console.WriteLine($"Je scanne le média : {media.Title}");
        //}

        //private void StatusControl(Media media)
        //{
        //    Console.WriteLine($"Je contrôle l'état de : {media.Title}");
        //}

        //private void Disinfect(Media media)
        //{
        //    Console.WriteLine($"Je désinfecte : {media.Title}");
        //}

        //private void MakeAvailable(Media media)
        //{
        //    try
        //    {
        //        media.Return();
        //    }

        //    catch (AlreadyAvailableMediaException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    Console.WriteLine($"Je remets en rayon : {media.Title}");
        //}

        //private void PutAway(Media media)
        //{
        //    Console.WriteLine($"Je range en rayon : {media.Title}");
        //}

        public void ProcessReturn(Media media)
        {
            //ReturnsHandlingDelegate processing = null; //On instancie le delegate 
            //processing += Scan;                        //On passe au delegate toutes les fonctions qu'il va devoir appeler 
            //processing += StatusControl;
            //processing -= Disinfect;
            //processing += MakeAvailable;
            //processing += PutAway;

            //processing?.Invoke(media);                 //Execute le delegate 



            ReturnsHandlingDelegate processing = delegate (Media media)
            {
                Console.WriteLine($"Je scanne le média : {media.Title}");
                Console.WriteLine($"Je contrôle l'état de : {media.Title}");
                Console.WriteLine($"Je désinfecte : {media.Title}");

                try
                {
                    media.Return();
                }
                catch (AlreadyAvailableMediaException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine($"Je remets en rayon : {media.Title}");

                Console.WriteLine($"Je range en rayon : {media.Title}");
            };

            processing(media);
        }
    }
}
