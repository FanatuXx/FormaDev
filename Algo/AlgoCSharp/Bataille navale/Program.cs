/////////////////////////////////////////////////////////////////   Bataille navale 
string[,] playerBoard = new string[10, 10];
string[,] IABoard = new string[10, 10];
string[,] positionBoard = new string[11, 11];
char[] coordinatesX = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
int[] coordinatesY = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
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
                    }
                }
            }

            else if (orientation == 'h')
            {
                for (int i = 0; i < allBoatsPos.Count; i++)
                {
                    for (int j = 1; j < boatSize; j++)
                    {
                        if (allBoatsPos[i] == (boxX + j, boxY))
                        {
                            canBeHorizontal = false;
                        }
                    }
                }
            }

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