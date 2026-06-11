using System.Collections;
using System.ComponentModel.Design;

/////////////////////////////////////////////////////////////////   1
//int nbOfPlayers;
//int userScore;
//int usersScore = 0;

//Console.WriteLine("How many players are they ?");
//bool succeed = int.TryParse(Console.ReadLine(), out nbOfPlayers);

//while (nbOfPlayers > 10 || nbOfPlayers < 1)
//{
//    Console.WriteLine("The number of players can't be less than 0, or more than 10.\nPlease write a number between 1 and 10.");
//    succeed = int.TryParse(Console.ReadLine(), out nbOfPlayers);
//}

//Console.WriteLine("Please write the score of each player, one by one.");

//for (int i = 0; i < nbOfPlayers; i++)
//{
//    succeed = int.TryParse(Console.ReadLine(), out userScore);
//    usersScore = usersScore + userScore;
//}

//Console.WriteLine($"The average score is {usersScore / nbOfPlayers}");




/////////////////////////////////////////////////////////////////   2
//int[] array = new int[10];

//for (int i = 0; i < array.Length; i++)
//{
//    array[i] = i;
//}

//Console.WriteLine("Here is your array :");
//for (int i = 0;i < array.Length; i++)
//{
//    Console.WriteLine($"{array[i]}"); 
//}

//Console.WriteLine("Here is your inversed array :");
//for (int i = 9; i > -1; i--)
//{
//    Console.WriteLine($"{array[i]}"); 
//}

//Console.ReadKey();





/////////////////////////////////////////////////////////////////   3
//int[] array = new int[5];
//array[0] = 64;
//array[1] = 996;
//array[2] = -47;
//array[3] = -668;
//array[4] = 4;
//int value;

//Console.WriteLine("Array :");
//for (int i = 0; i < array.Length; i++)
//{
//    Console.WriteLine($"{array[i]}");
//}

//for (int i = 0; i < array.Length; i++)
//{
//    for (int j = 0; j < array.Length - 1; j++)
//    {
//        if (array[j] > array[j + 1])
//        {
//            value = array[j];
//            array[j] = array[j + 1];
//            array[j + 1] = value;
//        }
//    }
//}

//Console.WriteLine("Ordred array :");
//for (int i = 0; i < array.Length; i++)
//{
//    Console.WriteLine($"{array[i]}");
//}

//Console.ReadKey();




/////////////////////////////////////////////////////////////////   4
//int[] integers = new int[10];
//int minValue = 0;
//int maxValue = 0;

//Console.WriteLine("Please write 10 integers, one by one");

//for(int i = 0;  i < integers.Length; i++)
//{
//    bool succeed = int.TryParse(Console.ReadLine(), out integers[i]);
//}

//for (int i = 0; i < integers.Length; i++)
//{
//    for (int j = 0; j < integers.Length - 1; j++)
//    {
//        if (integers[j] > integers[j + 1] && integers[j] > maxValue)
//        {
//            maxValue = integers[j];
//        }
//    }
//}

//for (int i = 0; i < integers.Length; i++)
//{
//    for (int j = 0; j < integers.Length - 1; j++)
//    {
//        if (integers[j] < integers[j + 1] && integers[j] < minValue)
//        {
//            minValue = integers[j];
//        }
//    }
//}

//Console.WriteLine($"The minimum value is : {minValue}");
//Console.WriteLine($"The maximum value is : {maxValue}");




/////////////////////////////////////////////////////////////////   5
//string[] colors = ["blue", "yellow", "red", "green", "brown"];
//string pickedColor = "";
//int index = 0;
//bool suceed = false;

//Console.WriteLine("Which color are you looking for ?");
//pickedColor = Console.ReadLine();

//for (int i = 0;  i < colors.Length; i++)
//{
//    if (pickedColor == colors[i])
//    {
//        index = i;
//        suceed = true;
//    }
//}

//if (suceed)
//{
//    Console.WriteLine($"The color is in the list, at the index {index}");
//}
//else
//{
//    Console.WriteLine("The color is not in the list...");
//}





/////////////////////////////////////////////////////////////////   7
//List<int> array = new List<int> { 64, 996, -47, -668, 4 };
//int value;
//int numberToAdd;

//Console.WriteLine("Array :");
//for (int i = 0; i < array.Count; i++)
//{
//    Console.WriteLine($"{array[i]}");
//}
//Console.WriteLine("");

//for (int i = 0; i < array.Count; i++)
//{
//    for (int j = 0; j < array.Count - 1; j++)
//    {
//        if (array[j] > array[j + 1])
//        {
//            value = array[j];
//            array[j] = array[j + 1];
//            array[j + 1] = value;
//        }
//    }
//}

//Console.WriteLine("Ordred array :");
//for (int i = 0; i < array.Count; i++)
//{
//    Console.WriteLine($"{array[i]}");
//}
//Console.WriteLine("");


//Console.WriteLine("Which number do you want to add in the list ?");
//bool succeed = int.TryParse(Console.ReadLine(), out numberToAdd);

//for (int i = 0; i < array.Count; i++)
//{
//    if (numberToAdd < array[i] && !array.Contains(numberToAdd))
//    {
//        array.Insert(i, numberToAdd);
//    }
//}
//Console.WriteLine("");

//Console.WriteLine("Ordered array with your number :");
//for (int i = 0; i < array.Count; i++)
//{
//    Console.WriteLine($"{array[i]}");
//}
//Console.WriteLine("");

//Console.ReadKey();






/////////////////////////////////////////////////////////////////   8
//List<int> integers = new List<int>{1,2, 3, 4, 5, 6, 7, 8, 9, 10};
//int pickedNumber;
//bool numberFound = false;

//Console.WriteLine("There is your list of integers :\n");
//for (int i = 0; i < integers.Count; i++)
//{
//    Console.WriteLine(integers[i]);
//}
//Console.WriteLine("");

//Console.WriteLine("Which color are you looking for ?");
//bool succeed = int.TryParse(Console.ReadLine(), out pickedNumber);

//for (int i = 0; i < integers.Count; i++)
//{
//    if (pickedNumber == integers[i])
//    {
//        integers.RemoveAt(i);
//        numberFound = true;
//    }
//}

//if (numberFound)
//{
//    Console.WriteLine($"Your number has been erased from the list :\n");
//    for (int i = 0; i < integers.Count; i++)
//    {
//        Console.WriteLine(integers[i]);
//    }
//    Console.WriteLine("");
//}
//else
//{
//    Console.WriteLine("The number was not on the list.");
//}





/////////////////////////////////////////////////////////////////   9
//int[] array1 = new int[5];
//int[] array2 = new int[5];
//int[] array3 = new int[10];
//int value;
//int pos;
//int lengthC;

//lengthC = 0;

//for (int i = 0; i < array1.Length; i++)
//{
//    Console.WriteLine("Valeur du premier tableau ", i + 1, " : ");
//    bool succeed = int.TryParse(Console.ReadLine(), out array1[i]);
//}

//for (int i = 0; i < array2.Length; i++)
//{
//    Console.WriteLine("Valeur du deuxième tableau ", i + 1, " : ");
//    bool succeed = int.TryParse(Console.ReadLine(), out array2[i]);
//}

//for (int i = 0; i < array3.Length; i++)
//{
//    if (i < 5)
//    {
//        value = array1[i];
//    }

//    else
//    {
//        value = array2[i - 5];
//    }

//    pos = lengthC;

//    for (int j = 0; j < lengthC - 1; j++)
//    {
//        if (value < array3[j] && pos == lengthC)
//        {
//            pos = j;
//        }
//    }

//    for (int j = lengthC; j > pos + 1; j--)
//    {
//        array3[j] = array3[j - 1];
//    }

//    array3[pos] = value;
//    lengthC++;
//}

//Console.WriteLine("Tableau fusionne et trie :");

//for (int i = 0; i < lengthC - 1; i++)
//{
//    Console.WriteLine(array3[i]);
//}





/////////////////////////////////////////////////////////////////   Bataille navale 
string[,] playerBoard = new string[10,10];
string[,] IABoard = new string[10,10];
string[,] positionBoard = new string[11, 11];
char[] coordinatesX = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'};
int[] coordinatesY = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
List<(int left, int top)> aircraftCarrierPos = new List<(int left, int top)>();
List<(int left, int top)> cruiserPos = new List<(int left, int top)>();
List<(int left, int top)> destroyer1Pos = new List<(int left, int top)>();
List<(int left, int top)> destroyer2Pos = new List<(int left, int top)>();
List<(int left, int top)> torpedoPos = new List<(int left, int top)>();
List<(int left, int top)> allBoatsPos = new List<(int left, int top)>();


int sizeMainTab = playerBoard.GetLength(0);
int sizeInnerTab = playerBoard.GetLength(1);

int aircraftCarrierSize = 5;
int cruiserSize = 4;
int destroyerSize = 3;
int torpedoSize = 2;

int indexX = 1;
int indexY = 1;

string boxPos = string.Empty;


SetBoardData();

DrawPositionBoard();

SetBoatPosition("aircraft carrier", aircraftCarrierSize, aircraftCarrierPos);
SetBoatPosition("cruiser", cruiserSize, cruiserPos);
SetBoatPosition("destroyer", destroyerSize, destroyer1Pos);
SetBoatPosition("destroyer", destroyerSize, destroyer2Pos);
SetBoatPosition("torpedo", torpedoSize, torpedoPos);







void SetBoardData()
{
    for (int i = 0; i < sizeMainTab; i++)
    {
        for (int j = 0; j < sizeInnerTab; j++)
        {
            playerBoard[i, j] = "_";
        }
    }

    for (int i = 0; i < sizeMainTab; i++)
    {
        for (int j = 0; j < sizeInnerTab; j++)
        {
            IABoard[i, j] = "_";
        }
    }

    for (int i = 0; i < positionBoard.GetLength(0); i++)
    {
        for (int j = 0; j < positionBoard.GetLength(1); j++)
        {
            if (i == 0 && j == 0)
            {
                positionBoard[i, j] = "";
            }

            else if (i == 0)
            {
                positionBoard[i, j] = coordinatesX[indexX - 1].ToString();
                indexX++;
            }

            else if (j == 0)
            {
                positionBoard[i, j] = coordinatesY[indexY - 1].ToString();
                indexY++;
            }

            else
            {
                positionBoard[i, j] = "_";
            }
        }
    }
}

void DrawPositionBoard()
{
    Console.Clear();
    for (int i = 0; i < positionBoard.GetLength(0); i++)
    {
        for (int j = 0; j < positionBoard.GetLength(1); j++)
        {
            if (i == 0 && j == 1)
            {
                Console.Write($"   {positionBoard[i, j]}");
            }

            else if (i == 0)
            {
                Console.Write($"  {positionBoard[i, j]}");
            }

            else if (i == 10 && j == 1)
            {
                Console.Write($" {positionBoard[i, j]}");
            }

            else
            {
                Console.Write($"  {positionBoard[i, j]}");
            }
        }
        Console.WriteLine("");
    }

    Console.WriteLine("");
}

void SetBoatPosition(string name, int boatSize, List<(int, int)> boatPos)
{
    int iteration = 0;
    bool boxFound = false;
    bool caseTaken = false;

    int boxY;
    int boxX = 0;
    bool canBeVertical = true;
    bool canBeHorizontal = true;

    Console.WriteLine($"Where do you want you want to put your {name} ({boatSize} boxes)?\nPlease write down the coordinates the first box of your boat.\nEx: a1\n\n");

    do
    {
        boxPos = Console.ReadLine();
        boxY = int.Parse(boxPos.Substring(1)) - 1;

        for (int i = 0; i < coordinatesX.Length; i++)
        {
            if (boxPos[0] == coordinatesX[i] && 0 < boxY && boxY < 11)
            {
                boxX = i;
                boatPos.Add((boxX, boxY));
                allBoatsPos.Add((boxX, boxY));
                boxFound = true;
            }
        }

    Console.WriteLine("Do you want to place your boat horizontally or vertically ?\nPress 'h' to place it horizontally, or 'v' to place it vertically.");

        do
        {
            bool succeed = char.TryParse(Console.ReadLine(), out char orientation);


            if (orientation != 'v' && orientation != 'h')
            {
                Console.WriteLine("Please write 'v' to place it vertically, or 'h' to place it horizontally");
            }

            else if (orientation == 'v')
            {
                for (int i = 0; i < allBoatsPos.Count; i++)
                {
                    for (int j = 1; j < boatSize; j++)
                    {
                        if (allBoatsPos[i] == (boxX, boxY + j))
                        {
                            canBeVertical = false;
                        }

                        else
                        {

                        }
                    }
                }
            }

            else if 
        } while (canBeHorizontal || canBeHorizontal && !caseTaken);
    } while (boxFound == false);




}













                //for (int i = 0; i < coordinatesX.Length; i++)
                //{
                //    if (boxPos[0] == coordinatesX[i])
                //    {
                //        if (boatPos.Count > 0)
                //        {
                //            if (coordinatesX[i] == boatPos[0].Item1 && boxY == boatPos[0].Item2 + 1 || coordinatesX[i] == boatPos[0].Item1 && boxY == boatPos[0].Item2 - 1)
                //            {

//            }

//            else if (coordinatesX[i] == boatPos[0].Item1 + 1 && boxY == boatPos[0].Item2 || coordinatesX[i] == boatPos[0].Item1 - 1 && boxY == boatPos[0].Item2)
//            {

//            }
//        }

//        else
//        {
//            boatPos.Add((i, boxY - 1));
//            iteration++;
//            Console.WriteLine("case 3");
//        }






//    for (int i = 0; i < coordinatesX.Length; i++)
//    {
//        if (boatPos.Count > 0)
//        {
//            if (boxPos[0] == coordinatesX[i])
//            {
//                if (coordinatesX[i] == boatPos[0].Item1 && boxY == boatPos[0].Item2 + 1 || coordinatesX[i] == boatPos[0].Item1 && boxY == boatPos[0].Item2 - 1)
//                {
//                    boatPos.Add((i, boxY - 1));
//                    iteration++;
//                    Console.WriteLine("case 1");
//                }

//                else if (coordinatesX[i] == boatPos[0].Item1 + 1 && boxY == boatPos[0].Item2 || coordinatesX[i] == boatPos[0].Item1 - 1 && boxY == boatPos[0].Item2)
//                {
//                    boatPos.Add((i, boxY - 1));
//                    iteration++;
//                    Console.WriteLine("case 2");
//                }
//            }
//        }

//        else
//        {
//            if (boxPos[0] == coordinatesX[i])
//            {
//                boatPos.Add((i, boxY - 1));
//                iteration++;
//                Console.WriteLine("case 3");
//            }
//        }
//    }