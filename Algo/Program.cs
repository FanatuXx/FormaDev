using System.Collections;

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
int[] array1 = new array[5];
int[] array2 = new array[5];
int[] array3 = new array[10];
int i;
int j;
int value;
int pos;
int lengthC;

lengthC = 0;

for (int i = 0; i < array1.Length; i++)
{
    Console.WriteLine("Valeur du premier tableau ", i + 1, " : ");
    Console.ReadLine(array1[i])
}

for (int i = 0; i < array2.Length; i++)
{
    Console.WriteLine("Valeur du deuxième tableau ", i + 1, " : ");
    Console.ReadLine(array2[i])
}

for (int i = 0; i < array3.Length; i++)
{
    if (i < 5)
    {
        value = array1[i];
    }

    else
    {
        value = array2[i - 5];
    }

    pos = lengthC;

    for (int j = 0; j < lengthC - 1;  j++)
    {
        if (value < array3[j] && pos = lengthC)
        {
            pos = j;
        }
    }

    for (int j = lengthC; j < pos + 1; j--)
    {
        array3[j] = array3[j - 1];
    }

    array3[pos] = value;
    lengthC++
}

Console.WriteLine("Tableau fusionne et trie :");

for (int i = 0; i < lengthC - 1; i++)
{
    Console.WriteLine(array3[i]);
}




















