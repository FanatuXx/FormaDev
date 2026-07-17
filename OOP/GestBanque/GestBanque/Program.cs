using Models;
using Models.Demo;


#region demo
//foreach (int value in ListeValeurPaire.getNombres())
//{
//    Console.WriteLine(value);
//}

//Voiture mazda3 = new Voiture(4);
//mazda3.Carburant = "Diesel";
//mazda3.Id = Voiture.dernierId++;
//Console.WriteLine(mazda3.NbRoue);

//mazda3.NbRoue = 1000;

////mazda3 => Voiture
//// Accelerer (override) => Voiture
//mazda3.Accelerer();
//// Decelerer (new) => Voiture
//mazda3.Decelerer();
//mazda3.Klaxonner();
//mazda3.Entretenir();

//Vehicule v = mazda3;
//// Accelerer (override) => Voiture
//v.Accelerer();
//// Decelerer (new) => Vehicule
//v.Decelerer();
//v.Entretenir();
//if (v is Voiture)
//{
//    Console.WriteLine("Klaxon de la mazda");
//    Console.WriteLine(((Voiture)v).Klaxonner());
//}
////Vehicule v2 = new Vehicule();
////if (v2 is Voiture)
////{
////	Console.WriteLine("Klaxon du véhicule");
////	Console.WriteLine(((Voiture)v2).Klaxonner());
////}

//switch (v)
//{
//    case Voiture voiture:
//        voiture.Klaxonner();
//        break;
//    case Velo velo:
//        // instruction pours le vélo
//        break;
//}

//((Vehicule)mazda3).Accelerer();
//((Vehicule)mazda3).Decelerer();


//Console.WriteLine(mazda3.NbRoue);

//Console.WriteLine(mazda3.Vitesse);

//Garage garage = new Garage();
//Console.WriteLine("---surchage garage + voiture---");
//Console.WriteLine(garage + mazda3);

//Console.WriteLine(garage + mazda3);

//Console.WriteLine("---indexeur---");
//Console.WriteLine(garage.Voitures[0].Vitesse);
//Console.WriteLine(garage[0].Vitesse);

//Voiture daciaSandero = new Voiture();
//daciaSandero.Id = Voiture.dernierId++;
//daciaSandero.Peindre("jaune poussin");

//Voiture astonMartin = new Voiture();
//astonMartin.Id = Voiture.dernierId++;

//Console.WriteLine($"mazda3 : id = {mazda3.Id}");
//Console.WriteLine($"dacia sandero : id = {daciaSandero.Id}");
//Console.WriteLine($"aston martin : id = {astonMartin.Id}");
//Console.WriteLine(Vehicule.dernierId);

//Personne bruce = new Personne();
//bruce.Prenom = "Bruce";
//bruce.Nom = "Wayne";
//bruce.DateNaiss = new DateTime(1972, 2, 19);

//garage[bruce.Prenom] = bruce;
//Console.WriteLine(garage[bruce.Prenom].Prenom);

//int diviseur = 0;
//Console.WriteLine(((float)10) / diviseur);

//Fahrenheit fahrenheit = new Fahrenheit();
//fahrenheit.Degre = 100;

//Console.WriteLine(((Celsius)fahrenheit).Degre);

#endregion

#region test d'exercice
Person bruce = new Person("Bruce", "Wayne", new DateTime(1972, 2, 19));

Console.WriteLine($"{bruce.Firstname} {bruce.Surname} {bruce.BirthDate}");

CheckingAccount courant = new CheckingAccount("1", bruce, 0, 200);
courant.Deposit(1000000);

CheckingAccount courant2 = new CheckingAccount("2", bruce, 0, 200);
courant2.Withdrawal(100);

Console.WriteLine($"{courant.AccountNumber} appartenant à {courant.Holder.Firstname} {courant.Holder.Surname} avec {courant.Balance}");

Bank banque = new Bank("Gotham City Bank");

banque.Add(courant);
banque.Add(courant2);
Console.WriteLine(banque["1"]?.Balance);
Console.WriteLine(banque.GetAccounts(bruce));

#endregion