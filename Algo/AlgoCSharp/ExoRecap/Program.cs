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
            BackToMain();
            break;

        case "Details":

            Get();
            BackToMain();
            break;

        case "All":

            Console.Clear();
            GetAll();
            BackToMain();
            break;

        case "Update":

            Update();
            BackToMain();
            break;

        case "Delete":

            Delete();
            BackToMain();
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
    Console.WriteLine(" > Quit Gamify ");
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

    while (!succeed)
    {
        succeed = int.TryParse(Console.ReadLine(), out newGame.Year);

        if (!succeed)
        {
            Console.Clear();
            Console.WriteLine("Enter a valid year of parution (ie: 1998)");
        }
    }

    Console.Clear();
    Console.WriteLine("Enter the game's studio :");
    newGame.Studio = Console.ReadLine();
    Console.Clear();

    games.Add(newGame);

    Console.WriteLine("Game added in your DB !");

    ShowInfo(newGame);
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
            game.Title.Contains(userInput) ||
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

    CheckIfDBEmpty();
}

void GetAll()
{
    foreach (Game game in games)
    {
        ShowInfo(game);
    }

    CheckIfDBEmpty();
}

void Update()
{
    Console.Clear();

    if (games.Count == 0)
    {
        CheckIfDBEmpty();
    }

    else
    {
        Console.WriteLine("Please enter the title of the game you want to update.");
        string userInput2 = Console.ReadLine();
        Console.Clear();

        bool gameFound = false;
        bool similarGameFound = false;
        bool isConverted = false;
        bool gameIDFound = false;
        int gameID = 0;

        for (int i = 0; i < games.Count; i++)
        {
            if (games[i].Title == userInput2)
            {
                gameFound = true;
                index = i;
                break;
            }
        }

        if (!gameFound)
        {
            Console.WriteLine("No game is fully matching what you're looking for...");
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].Title.Contains(userInput2))
                {
                    similarGameFound = true;
                    ShowInfo(games[i]);
                }
            }

            if (similarGameFound)
            {
                Console.WriteLine($"\nThere is a list that could contain the game you're looking for :");
            }

            else
            {
                GetAll();
                Console.WriteLine($"\nThere is the list of all games stored in this DB :");
            }

            Console.WriteLine("\nPlease write the ID of the game you want to modify.");

            do
            {
                isConverted = int.TryParse(Console.ReadLine(), out gameID);
                
                if(isConverted)
                {
                    for (int i = 0; i < games.Count; i++)
                    {
                        if (games[i].ID == gameID)
                        {
                            gameIDFound = true;
                            index = i;
                            break;
                        }
                    }

                    if (!gameIDFound)
                    {        
                        Console.WriteLine("\nThe ID you wrote doesn't match any game ID... Please try again.");
                    }
                }

            } while (!gameIDFound);
        }

        Console.WriteLine("\nWhich information do you want to update (Title, Genra, Year or Studio)?");
        string infoToUdpate = Console.ReadLine();

        Console.WriteLine("\nWrite the updated info:");
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
                bool succeed = false;
                succeed = int.TryParse(updatedInfo, out int yearOfParution);
                Console.Clear();

                if (succeed)
                {
                    jeu.Year = yearOfParution;
                }

                else
                {
                    while (!succeed)
                    {
                        Console.WriteLine("Please enter a valid year of parution (ie: 1998).");
                        succeed = int.TryParse(Console.ReadLine(), out yearOfParution);
                        Console.Clear();

                        if (succeed)
                        {
                            jeu.Year = yearOfParution;
                        }
                    }
                }


                break;

            case "Studio":
            case "studio":
                jeu.Studio = updatedInfo;
                break;
        }

        Console.WriteLine("Game successfuly updated!");
        ShowInfo(jeu);
    }
}

void Delete()
{
    Console.Clear();
    Console.WriteLine("Please enter the title of the game you want to delete.");
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
    Console.WriteLine("Game has been successfuly deleted!");

    //If I want to update IDs to match the indexes
    //for (int i = index; i < games.Count; i++)
    //{
    //    Game jeu = games[i];
    //    jeu.ID--;
    //}

    //Console.WriteLine("Games IDs updated!");


}

void CheckIfDBEmpty()
{
    if (games.Count == 0)
    {
        Console.WriteLine("There is no game in your DB yet...\nYou can add some by selecting the first option in the main menu.\n\n");
    }
}

void BackToMain()
{
    Console.WriteLine("\nPress any key to come back to main menu...");
    Console.ReadKey();
    Console.Clear();
}


public struct Game
{
    public int ID, Year;
    public string Title, Genra, Studio;
}

