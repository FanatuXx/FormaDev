//int a = 5;
//int b = 2;
//float c = 5f;

////Division entière
//int result = a / b;

////Modulo
//int result2 = a % b;

////Division flottante
//float result3 = a / (float)b;

//Console.WriteLine(result3);



//string BBANString = string.Empty;
//long BBANLong;
//bool correctEntry = false;
//bool correctBBAN = false;
//long BBANTenFirst;


//Console.WriteLine("Please enter your BBAN account number :");

//do
//{
//    bool succeed = long.TryParse(Console.ReadLine(), out BBANLong);

//    if (succeed)
//    {
//        correctEntry = true;
//        BBANString = BBANLong.ToString();
//    }
//} while (!correctEntry);

//string firstTenNumbers = BBANString.Substring(0, 10);

//BBANTenFirst = long.Parse(firstTenNumbers);

//if (BBANTenFirst % 97 == long.Parse(BBANString.Substring(10, 2)))
//{
//    correctBBAN = true;
//}

//else if (BBANTenFirst % 97 == 0 && long.Parse(BBANString.Substring(10, 2)) == 97)
//{
//    correctBBAN = true;
//}

//else
//{
//    correctBBAN = false;
//}

//if (correctBBAN)
//{
//    Console.WriteLine("Your BBAN is valid.");
//}

//else
//{
//    Console.WriteLine("Your BBAN is not valid.");
//}




//string BBANString = string.Empty;
//long BBANLong;
//bool correctEntry = false;
//bool correctBBAN = false;
//long BBANTenFirst;
//string temporaryIBAN = string.Empty;
//string realIBAN;
//string contryCode = "1114";
//short digit;


//Console.WriteLine("Please enter your BBAN account numbers (without the dashes) :");

//do
//{
//    bool succeed = long.TryParse(Console.ReadLine(), out BBANLong);

//    if (succeed)
//    {
//        correctEntry = true;
//        BBANString = BBANLong.ToString();
//    }

//    string firstTenNumbers = BBANString.Substring(0, 10);

//    BBANTenFirst = long.Parse(firstTenNumbers);

//    if (correctEntry && BBANTenFirst % 97 == long.Parse(BBANString.Substring(10, 2)))
//    {
//        correctBBAN = true;
//    }

//    else if (correctEntry && BBANTenFirst % 97 == 0 && long.Parse(BBANString.Substring(10, 2)) == 97)
//    {
//        correctBBAN = true;
//    }

//    else
//    {
//        correctBBAN = false;
//    }

//    if (correctBBAN)
//    {
//        Console.Clear();
//        Console.WriteLine("Your BBAN is valid.");
//        temporaryIBAN = BBANString + "00" + contryCode;
//        long IBAN = long.Parse(temporaryIBAN);
//        short remainder = (short)(IBAN % 97);
//        digit = (short)(98 - remainder);

//        if (digit > 9)
//        {
//            realIBAN = "BE" + digit.ToString() + BBANString;
//        }

//        else
//        {
//            realIBAN = "BE" + "0" + digit.ToString() + BBANString;
//        }

//        Console.WriteLine($"Based on your BBAN, your IBAN is :\n{realIBAN}");
//    }

//    else
//    {
//        Console.Clear();
//        Console.WriteLine("Your BBAN is not valid.\nPlease enter a valid BBAN.");
//    }

//} while (!correctBBAN);



////---------------------------------------------------------------------------------- Fibonacci 
//int[] numbers = new int[25];
//numbers[0] = 0;
//numbers[1] = 1;

//Console.WriteLine("Voici les 25 premiers nombres de la suite de Fibonacci :\n");

//for (int i = 2; i < 25; i++)
//{
//    numbers[i] = numbers[i - 1] + numbers[i - 2];
//}

//for (int i = 0; i < numbers.Length; i ++)
//{
//    Console.WriteLine(numbers[i]);
//}


//---------------------------------------------------------------------------------- Factoriel 
//int number;
//int result = 1;
//bool succeed = false;
//int i = 1;


//Console.WriteLine("Enter a number to know its factorial.");

//do
//{
//    succeed = int.TryParse(Console.ReadLine(), out number);

//    if (!succeed)
//    {
//        Console.Clear();
//        Console.WriteLine("Please enter a valid number.");
//    }

//} while (!succeed);


//while (i < number)
//{
//    i++;
//    result *= i;
//}

//Console.WriteLine($"The factorial of {number} is {result}.");




////---------------------------------------------------------------------------------- Prime number 
//int number = 2;
//List<int> numbers = new List<int>();
//bool isPrime;


//for (int i = 0; numbers.Count < 20; i++)
//{
//    isPrime = true;

//    for (int j = 1; j < number; j++)
//    {
//        int div = j;

//        if (div != 1 && number % div == 0)
//        {
//            isPrime = false;
//        }
//    }

//    if (isPrime)
//    {
//        numbers.Add(number);
//    }

//    number++;
//}

//for (int i = 0; i < numbers.Count; i++)
//{
//    Console.WriteLine(numbers[i]);
//}



////---------------------------------------------------------------------------------- Mult. Tables
//for (int i = 1; i <= 5; i++)
//{
//    Console.WriteLine($"Table of {i} :");
//    for (int j = 1; j <= 20; j++)
//    {
//        Console.WriteLine($"{i} x {j} = {i * j}");
//    }
//    Console.WriteLine("");
//}



////---------------------------------------------------------------------------------- 0,0 to 20,0
//double number = 0.0;
//const double TOADD = 0.1;

//for (int i = 0; number <= 20.0; i++)
//{
//    number += TOADD;
//    Console.WriteLine(number);
//}

//----------------------------> Pour ne plus avoir de problème d'arrondi !
//decimal number = 0.0m;
//const decimal TOADD = 0.1m;

//for (int i = 0; number <= 20.0m; i++)
//{
//    number += TOADD;
//    Console.WriteLine(number);
//}



////---------------------------------------------------------------------------------- Squared racine
//int number;


//bool succeed = false;
//bool squaredFound = false;
//bool stop = false;


//Console.WriteLine("Enter a number to know its squared racine.");

//do
//{
//    succeed = int.TryParse(Console.ReadLine(), out number);

//    if (!succeed)
//    {
//        Console.Clear();
//        Console.WriteLine("Please enter a valid number.");
//    }

//} while (!succeed);


//for (int i = 1; !squaredFound && !stop ; i++)
//{
//    if (i * i == number)
//    {
//        squaredFound = true;
//        Console.WriteLine($"The squared racine of {number} is {i}.");
//    }

//    else if (i * i >  number)
//    {
//        stop = true;
//        Console.WriteLine("This number has no squared racine...");
//    }
//}



//---------------------------------------------------------------------------------- First prime numbers based on a given number
//int number;
//List<int> primeNumbers = new List<int>();
//bool isPrime;
//bool succeed = false;
//int i = 2;

//Console.WriteLine("How many prime numbers do you want ?");

//do
//{
//    succeed = int.TryParse(Console.ReadLine(), out number);

//    if (!succeed)
//    {
//        Console.Clear();
//        Console.WriteLine("Please enter a valid number.");
//    }

//} while (!succeed);


//for (int count = 0; count < number; i++)
//{
//    isPrime = true;

//    foreach (int p in primeNumbers)
//    { 
//        if (i % p == 0)
//        {
//            isPrime = false;
//        }
//    }

//    if (isPrime)
//    {
//        primeNumbers.Add(i);
//        count++;
//    }
//}

//Console.Clear();
//Console.WriteLine($"There are the {number} first prime numbers:\n");
//foreach (int numb in primeNumbers)
//{
//    Console.Write($"{numb} ");
//}



////---------------------------------------------------------------------------------- Prime number V2 (while)
//int number;
//List<int> primeNumbers = new List<int>();
//bool isPrime;
//bool succeed = false;

//Console.WriteLine("Enter a number to know the prime numbers inferior to it.");

//do
//{
//    succeed = int.TryParse(Console.ReadLine(), out number);

//    if (!succeed)
//    {
//        Console.Clear();
//        Console.WriteLine("Please enter a valid number.");
//    }

//} while (!succeed);

//int i = 2;

//while (i < number)
//{
//    isPrime = true;
//    int j = 2;

//    while (j * j <= i)
//    {
//        if (i % j == 0)
//        {
//            isPrime = false;
//            break;
//        }
//        j++;
//    }

//    if (isPrime)
//    {
//        primeNumbers.Add(i);
//    }
//    i++;
//}

//Console.Clear();
//Console.WriteLine($"There are the prime numbers inferior to {number}:\n");
//foreach (int numb in primeNumbers)
//{
//    Console.WriteLine(numb);
//}






////---------------------------------------------------------------------------------- ToCharArray
//string entry1 = string.Empty;
//string entry2 = string.Empty;

//int checkValid;

//bool succeed = false;


//Console.WriteLine("Enter a first number.");

//do
//{
//    succeed = int.TryParse(Console.ReadLine(), out checkValid);

//    if (!succeed)
//    {
//        Console.Clear();
//        Console.WriteLine("Please enter a valid number.");
//    }

//    else
//    {
//        entry1 = checkValid.ToString();
//    }

//} while (!succeed);

//Console.WriteLine("Enter a second number.");

//do
//{
//    succeed = int.TryParse(Console.ReadLine(), out checkValid);

//    if (!succeed)
//    {
//        Console.Clear();
//        Console.WriteLine("Please enter a valid number.");
//    }

//    else
//    {
//        entry2 = checkValid.ToString();
//    }

//} while (!succeed);


//char[] chars1 = entry1.ToCharArray();
//char[] chars2 = entry2.ToCharArray();

//int nb1 = 0;
//foreach (char c in chars1)
//    nb1 = nb1 * 10 + (c - '0');

//int nb2 = 0;
//foreach (char c in chars2)
//    nb2 = nb2 * 10 + (c - '0');

//int somme = nb1 + nb2;

//Console.WriteLine($"La somme est de {somme}");




//------------------------------------------------------------------------- Structures

//using System.Drawing;

//Point[,] points = new Point [5,5];

//for (int i = 0; i < 5; i++)
//{
//	points[i, i].X = i + 1;
//    points[i, i].Y = i + 1;
//}

//for (int i = 0; i < 5; i++)
//{
//	Console.WriteLine($"X : {points[i, i].X} - Y : {points[i, i].Y}");
//}

//struct Point
//{
//	public int X, Y;
//}



//------------------------------------------------------------------------- Structures 2
//Celsius c;
//c.Temperature = 32;


//Console.WriteLine(c.CelToFar());


//public struct Celsius
//{
//    public double Temperature;

//    public double CelToFar()
//    {
//        return (Temperature * 9 / 5) + 32;
//    }
//}

//public struct Fahrenheit
//{
//    public double Temperature;

//    public double FarToCell()
//    {
//        return (Temperature - 32) * 5 / 9;
//    }
//}


//------------------------------------------------------------------------- 2nd degree equations
//public struct EqSecDeg
//{
//    public double A, B, C;

//    public bool Resolve(out double? X1, out double? X2)
//    {
//        double delta = B * B - 4 * A * C;

//        if (delta < 0)
//        {
//            X1 = null;
//            X2 = null;
//            return false;
//        }

//        else if (delta == 0)
//        {
//            X1 = -B / (2 * A);
//            X2 = X1;
//            return true;
//        }

//        X1 = (-B - Math.Sqrt(delta)) / (2 * A);
//        X2 = (-B + Math.Sqrt(delta)) / (2 * A);
//        return true;
//    }
//}



