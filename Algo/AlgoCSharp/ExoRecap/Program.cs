using ExoRecap;
using System.Data;
using System.Reflection;

Console.CursorVisible = false;
ConsoleKeyInfo keyPressed;

int middleX = Console.WindowWidth / 2;
int middleY = Console.WindowHeight / 2;
int index = 0;

string selectedChoice = string.Empty;
string currentChoice = "Create";

List<Game> games = new List<Game>();

do
{
    ShowMainMenu();
    currentChoice = NavigateInMenu("Create", "Details", "All", "Update", "Delete", "Quit", currentChoice, out selectedChoice);

    switch (selectedChoice)
    {
        case "Create":

            Create();
            break;

        case "Details":

            Get();
            break;

        case "All":

            GetAll();
            break;

        case "Update":

            Update();
            break;

        case "Delete":

            Delete();
            break;

        case "Quit":
            break;
    }
} while (selectedChoice != "Quit");


void ShowMainMenu()
{
    selectedChoice = string.Empty;
    Console.ForegroundColor = ConsoleColor.White;

    Console.SetCursorPosition(middleX - 17, middleY - 5);
    Console.WriteLine("--------------------------------");

    Console.SetCursorPosition(middleX - 10, middleY - 3);
    Console.WriteLine("WELCOME IN GAMIFY !");

    if (currentChoice == "Create")
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
    }
    Console.SetCursorPosition(middleX - 16, middleY - 1);
    Console.WriteLine(" > Add a new object in your DB ");
    Console.BackgroundColor = ConsoleColor.Black;

    if (currentChoice == "Details")
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
    }
    Console.SetCursorPosition(middleX - 15, middleY + 1);
    Console.WriteLine(" > Show the details of a game ");
    Console.BackgroundColor = ConsoleColor.Black;

    if (currentChoice == "All")
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
    }
    Console.SetCursorPosition(middleX - 15, middleY + 3);
    Console.WriteLine(" > Show all games in your DB ");
    Console.BackgroundColor = ConsoleColor.Black;

    if (currentChoice == "Update")
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
    }
    Console.SetCursorPosition(middleX - 16, middleY + 5);
    Console.WriteLine(" > Update the details of a game ");
    Console.BackgroundColor = ConsoleColor.Black;

    if (currentChoice == "Delete")
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
    }
    Console.SetCursorPosition(middleX - 15, middleY + 7);
    Console.WriteLine(" > Delete a game from your DB ");
    Console.BackgroundColor = ConsoleColor.Black;

    if (currentChoice == "Quit")
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
    }
    Console.SetCursorPosition(middleX - 10, middleY + 9);
    Console.WriteLine(" > Quit Gamify");
    Console.BackgroundColor = ConsoleColor.Black;

    Console.SetCursorPosition(middleX - 17, middleY + 11);
    Console.WriteLine("--------------------------------");
}

string NavigateInMenu(string choix1, string choix2, string choix3, string choix4, string choix5, string choix6, string currentChoice, out string selectedChoice)
{
    keyPressed = Console.ReadKey();

    selectedChoice = "";

    switch (keyPressed.Key.ToString())
    {
        case "LeftArrow":
        case "UpArrow":
        case "Z":
        case "Q":
            if (currentChoice == choix1) { currentChoice = choix6; }
            else if (currentChoice == choix2) { currentChoice = choix1; }
            else if (currentChoice == choix3) { currentChoice = choix2; }
            else if (currentChoice == choix4) { currentChoice = choix3; }
            else if (currentChoice == choix5) { currentChoice = choix4; }
            else if (currentChoice == choix6) { currentChoice = choix5; }
            break;

        case "RightArrow":
        case "DownArrow":
        case "S":
        case "D":
            if (currentChoice == choix1) { currentChoice = choix2; }
            else if (currentChoice == choix2) { currentChoice = choix3; }
            else if (currentChoice == choix3) { currentChoice = choix4; }
            else if (currentChoice == choix4) { currentChoice = choix5; }
            else if (currentChoice == choix5) { currentChoice = choix6; }
            else if (currentChoice == choix6) { currentChoice = choix1; }
            break;

        case "Enter":
            selectedChoice = currentChoice;
            break;
    }

    return currentChoice;
}

void ShowInfo(Game newGame)
{
    Console.WriteLine("\n---------------------------------");
    Console.WriteLine($"ID               : {newGame.ID}");
    Console.WriteLine($"Title            : {newGame.Title}");
    Console.WriteLine($"Genra            : {newGame.Genra}");
    Console.WriteLine($"Year of parution : {newGame.Year}");
    Console.WriteLine($"Studio           : {newGame.Studio}");
    Console.WriteLine("---------------------------------");
}

void Create()
{
    bool succeed = false;
    Game newGame = new Game();
    Console.Clear();
    newGame.ID = games.Count + 1;
    Console.WriteLine("Enter the game's name :");
    newGame.Title = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Enter the game's genra :");
    newGame.Genra = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Enter the game's year of parution :");

    do
    {
        succeed = int.TryParse(Console.ReadLine(), out newGame.Year);

        if (!succeed)
        {
            Console.WriteLine("Enter a valid year of parution (ie: 1998)");
        }
    } while (!succeed);

    Console.Clear();
    Console.WriteLine("Enter the game's studio :");
    newGame.Studio = Console.ReadLine();
    Console.Clear();

    games.Add(newGame);

    Console.WriteLine("Game added in your DB !");

    ShowInfo(newGame);

    Console.WriteLine("\nPress any key to come back to main menu...");
    Console.Clear();
}

void Get()
{
    Console.Clear();
    Console.WriteLine("Please enter either a title, a year of parution, a genra or a studio to have the details of all games linked to it.");
    string userInput = Console.ReadLine();
    Console.Clear();

    foreach (Game game in games)
    {
        bool succeed = false;

        if (
            game.Title == userInput ||
            game.Year.ToString() == userInput ||
            game.Genra == userInput ||
            game.Studio == userInput
            )

        {
            succeed = true;
        }

        if (succeed)
        {
            ShowInfo(game);
        }
    }

    Console.WriteLine("\nPress any key to come back to the main menu.");
    Console.ReadKey();
    Console.Clear();
}

void GetAll()
{
    Console.Clear();

    foreach (Game game in games)
    {
        ShowInfo(game);
    }

    Console.WriteLine("\nPress any key to come back to main menu...");
    Console.ReadKey();
    Console.Clear();
}

void Update()
{
    Console.Clear();
    Console.WriteLine("Please enter the title of the game you want to update");
    string userInput2 = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("");

    for (int i = 0; i < games.Count; i++)
    {
        if (games[i].Title == userInput2)
        {
            index = i;
            break;
        }
    }

    Console.WriteLine("Which information do you want to update ?");
    string infoToUdpate = Console.ReadLine();
    Console.Clear();

    Console.Clear();
    Console.WriteLine("Write the updated info :");
    string updatedInfo = Console.ReadLine();
    Console.Clear();

    Game jeu = games[index];

    switch (infoToUdpate)
    {
        case "Title":
        case "title":
            jeu.Title = updatedInfo;
            break;

        case "Genra":
        case "genra":
            jeu.Genra = updatedInfo;
            break;

        case "Year":
        case "year":
            jeu.Year = int.Parse(updatedInfo);
            break;

        case "Studio":
        case "studio":
            jeu.Studio = updatedInfo;
            break;
    }

    ShowInfo(jeu);
    Console.WriteLine("\nPress any key to come back to main menu...");
    Console.ReadKey();
    Console.Clear();
}

void Delete()
{
    Console.Clear();
    Console.WriteLine("Please enter the title of the game you want to delete");
    string userInput3 = Console.ReadLine();
    Console.Clear();

    for (int i = 0; i < games.Count; i++)
    {
        if (games[i].Title == userInput3)
        {
            index = i;
            break;
        }
    }

    games.RemoveAt(index);
    Console.WriteLine("Game has been successfuly deleted !");
    Console.WriteLine("\nPress any key to come back to main menu...");
    Console.ReadKey();
    Console.Clear();
}


public struct Game
{
    public int ID, Year;
    public string Title, Genra, Studio;
}

