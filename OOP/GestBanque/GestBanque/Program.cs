using Models;
using Models.Demo;

#region demo
Car mazda3 = new Car();
mazda3.FuelType = "Gasoil";
mazda3.WheelNumber = 4;
#endregion

#region test exo
Person person = new Person();
person.Firstname = "Bruce";
person.Surname = "Wayne";
person.BirthDate = new DateTime(1972, 2, 19);
#endregion

CheckingAccount checkAccount = new CheckingAccount();
checkAccount.Holder = new Person();
checkAccount.Deposit(20);

Console.WriteLine(checkAccount.Balance);
