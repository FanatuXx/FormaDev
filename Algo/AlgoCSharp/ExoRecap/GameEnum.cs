using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExoRecap
{
    public enum GameEnum
    {
        ID,
        Title,
        Genra,
        Year,
        Studio,
    }
}


//Une boucle de "jeu" = l'utilisateur doit spécifier la fin du programme
//L'utilisateur peut choisir parmi plusieurs options (soyez inventifs)
//Minimum : 
//-méthode de lecture GET permettant d'afficher les détails de l'objet
//- méthode de lecture GETALL permettant d'afficher tous les objets (pour aller plus loin : possibilité de rajouter des filtres de recherche)
//- méthode de création CREATE : création d'un objet spécifique (avec les détails) qui sera ajouté à la bibliothèque (pour aller plus loin : méthode de duplication, méthode de création multiple)
//- méthode de mise à jour UPDATE : besoin de l'ID d'un objet (get, modif, enregistrement : pas de création d'une nouvelle instance de l'objet)
//- méthode de suppression DELETE : suppression de l'objet (pour aller plus loin : suppression multiple