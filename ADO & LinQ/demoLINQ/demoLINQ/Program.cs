
using demoLINQ;
using System.Text.RegularExpressions;

bool monPredicate(int nombre)
{
    return nombre % 2 == 0;
}

List<int> nombres = [1, 2, 3, 5, 40, 20, 81];



Console.WriteLine(nombres.Count());
Console.WriteLine(nombres.Count(nombre => nombre % 2 == 0)); //Permet d'ajouter un "prédicate" => Choisir les nombres concernés par la demande
Console.WriteLine(nombres.Count(monPredicate));

List<int> nombrePaires = nombres.Where(nombre => nombre % 2 == 0).ToList(); //ToList() est nécessaire car un WHERE va TOUJOURS retourner un IEnumerable, qu'il faut convertir en liste

foreach(int value in nombrePaires)
{
    Console.WriteLine(value + "\t");
}
Console.WriteLine();

List<Animal> animals = [
    new Animal (1, "Koala", 4),
    new Animal (2, "Panda Roux", 4),
    new Animal (3, "Renard", 4),
    new Animal (4, "Serpent", 0),
    ];

var animals2 = animals                                      //Tant que la fonction renvoie un IEnumerable, je peux enchainer les fonctions (ex : Where -> Select)
                .Where(animal => animal.NbPatte > 0)        //Le Where mobilise une fonction fléchée
                .Select(animal =>
                    {
                        return new
                        {
                            Id = animal.Id,
                            Name = animal.Name
                        };
                    });

foreach (var animal in animals2)
{
    Console.WriteLine($"{animal.Id} - {animal.Name}");
}


List<object> inventory = [1, 2, "Chat", true];

//Conversion active vers le type demandé (avec erreur possible)
IEnumerable<int> numbers = inventory.Cast<int>();
numbers = from int value in inventory
          select value;

//foreach (int value in numbers)    //Erreur car tentative de Cast
//{
//    Console.WriteLine(value);
//}

inventory = ["chat", true, 40];

//Filtre les éléments du type demandé
IEnumerable<string> words = inventory.OfType<string>();
words = from string word in inventory.OfType<string>()
        select word;

foreach (string value in words)
{
    Console.WriteLine(value);
}


//Single

Animal myAnimal = animals
                    .Where(animal => animal.Id == 1)
                    .SingleOrDefault();

if (myAnimal is not null)
{
    Console.WriteLine($"{myAnimal.Id} - {myAnimal.Name}");
}

//First 
myAnimal = animals
           .Where(animal => animal.NbPatte > 0)
           .FirstOrDefault();

if (myAnimal is not null)
{
    Console.WriteLine($"{myAnimal.Id} - {myAnimal.Name}");
}

//Order by
IEnumerable<Animal> animals3 = animals
                                .OrderBy(animal => animal.Name.Length); // Le "animal =>" désigne à la fonction l'élément sur lequel il va devoir trier selon la condition "animal.Name.Length"
foreach (var animal in animals3)
{
    Console.WriteLine($"{animal.Id} - {animal.Name}");
}

//Then by                                                               //Pour trier par ordre décroissant : OrderByDescending ou ThenByDescending
animals3 = animals
           .OrderBy(animal => animal.NbPatte)
           .ThenBy(animal => animal.Name);
foreach (var animal in animals3)
{
    Console.WriteLine($"{animal.Id} - {animal.Name}");
}   

//MAX-MIN

//SUM-AVERAGE

//Group By
IEnumerable<IGrouping<int, Animal>> animalGrouped = animals.GroupBy(animals => animals.NbPatte);

foreach(IGrouping<int, Animal> group in animalGrouped)
{
    Console.WriteLine($"Nombre de pattes {group.Key}");
    foreach (Animal animal in group.OrderByDescending(animal => animal.Name))
    {
        Console.WriteLine($"{animal.Name}");
    }
}


List<VeterinaryAppointment> rdvs = [
        new VeterinaryAppointment(new DateTime(2026, 8, 7, 12, 0, 0), 2),
        new VeterinaryAppointment(new DateTime(2026, 8, 7, 14, 0, 0), 1),
        new VeterinaryAppointment(new DateTime(2026, 8, 7, 16, 0, 0), 4),
        new VeterinaryAppointment(new DateTime(2026, 8, 14, 12, 0, 0), 1),
    ];

var animalRDVs = animals.Join(rdvs,
                            animal => animal.Id,
                            rdv => rdv.AnimalID,
                            (animal, rdv) => new
                            {
                                AnimalID = animal.Id,
                                AnimalName = animal.Name,
                                rdv.Date
                            });

foreach(var animalRDV in animalRDVs)
{
    Console.WriteLine($"{animalRDV.AnimalID} {animalRDV.AnimalName} {animalRDV.Date}");
}

var animalRDVs2 = animals.GroupJoin(rdvs,
                            animal => animal.Id,
                            rdv => rdv.AnimalID,
                            (animal, rdvsToThisAnimal) => new
                            {
                                AnimalID = animal.Id,
                                AnimalName = animal.Name,
                                rdvs = rdvsToThisAnimal
                            });

foreach (var animalRDV in animalRDVs2)
{
    Console.WriteLine($"{animalRDV.AnimalID} {animalRDV.AnimalName}");
    foreach (VeterinaryAppointment rdv in animalRDV.rdvs)
    {
        Console.WriteLine($"\t{rdv.Date}");
    }
}

List<Person> persons = [
        new Person(1, "Antoine"),
        new Person(2, "Caroline")
    ];

List<Car> cars = [
    new Car(1, "Bleu électrique", "Lamborghini", 2),
    new Car(2, "Jaune", "Bonne vieille Polo", 1),
    new Car(1, "Noir", "Bat-Mobile", 2),
    ];

//join => 1pers <=> 1 voiture

var personsJoinCars = persons.Join(cars, //la collection à associer
                                person => person.PersonID, //la clé depuis la première collection
                                car => car.OwnerID, // la clé depuis la deuxieme collection
                                (person, car) => new //Création de l'objet en sortie en se basant sur 1 objet de la premiere collection et sur 1 autre objet associé venant de l'autre collection
                                {
                                    OwnerID = person.PersonID,
                                    OwnerName = person.Name,
                                    CarID = car.CarID,
                                    CarName = car.Name,
                                    CarColor = car.Color
                                });

Console.WriteLine("---JOIN entre Person et Car");
foreach(var personJoinCar in personsJoinCars)
{
    Console.WriteLine($"{personJoinCar.OwnerID} :  {personJoinCar.OwnerName} : {personJoinCar.CarName} : {personJoinCar.CarColor}");
}


var personsGroupJoinCars = persons.GroupJoin(cars, //la collection à associer
                                person => person.PersonID, //la clé depuis la première collection
                                car => car.OwnerID, // la clé depuis la deuxieme collection
                                (person, carsOwnedByPerson) => new //Création de l'objet en sortie en se basant sur 1 objet de la premiere collection et sur tous les autres objets associés venant de l'autre collection
                                {
                                    OwnerID = person.PersonID,
                                    OwnerName = person.Name,
                                    Cars = carsOwnedByPerson
                                });

Console.WriteLine("---GROUP JOIN entre Person et Car");
foreach (var personGroupJoinCar in personsGroupJoinCars)
{
    Console.WriteLine($"{personGroupJoinCar.OwnerID} :  {personGroupJoinCar.OwnerName}");
    foreach(Car car in personGroupJoinCar.Cars)
    {
        Console.WriteLine($"{car.CarID} : {car.CarID} : {car.Name} : {car.Color}");
    }
}