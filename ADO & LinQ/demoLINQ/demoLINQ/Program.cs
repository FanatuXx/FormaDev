
using demoLINQ;

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
