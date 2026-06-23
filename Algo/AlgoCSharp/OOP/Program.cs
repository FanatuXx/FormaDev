//Que contiennent les différents types de variables ? 
//STRUCT : VALEUR
//CLASS : REFERENCE
//ENUM : CONSTANTES (INT)
//INTERFACE : CONTRAT
//DELEGATE = POINTEUR DE FONCTION

//.DLL = Assembly = résultat de la compilation du projet 



//En file system : 
// Disque -> Dossier -> Fichiers

//En C# :
// Assembly -> Namespace -> Type 


// Disque = Assembly     -> REFERENCEMENT
// Dossier = Namespace   -> USING
// Fichier = Type 


using MyLibrary.Toto;
using System.Runtime.CompilerServices;



MonEnum x = MonEnum.Val5;

//Possible grâce au using MyLibrary.Toto
TypeCarburant tc = TypeCarburant.Essence;


//ENUM : Fournit des valeurs par défaut ! Val1 = 0, Val2 = 1, Val 3 = 2, ...
enum MonEnum
{
    Val1 = 1,
    Val2,
    Val3,
    Val4,
    Val5
}

//STRUCT : Ne fournit PAS de valeur par défaut !
struct MesConstantes
{
    public const int Val1 = 1;
    public const int Val2 = 2;
    public const int Val3 = 3;
    public const int Val4 = 4;
    public const int Val5 = 5;
}



