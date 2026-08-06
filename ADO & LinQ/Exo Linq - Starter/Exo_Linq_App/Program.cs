using Exo_Linq_Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Exercice Linq");
Console.WriteLine("*************");

DataContext context = new DataContext();

//foreach(Student stu in context.Students)
//{
//    Console.WriteLine(stu.First_Name);
//}

// SELECT

#region Exo 1.1
// Exercice 1.1 
// Ecrire une requête pour présenter, pour chaque étudiant, le nom de l’étudiant, la date de naissance, le login et le résultat pour l’année de l’ensemble des étudiants.

/*var students = context.Students
                .Select(student => new { 
                    Name = student.First_Name, 
                    student.BirthDate, 
                    student.Login, 
                    Result = student.Year_Result }
                );

foreach (var student in students)
{
    Console.WriteLine($"{student.Name} - {student.BirthDate} - {student.Login} - {student.Result}");
}*/
#endregion

#region Exo 1.2
//Exercice 1.2
//Ecrire une requête pour présenter, pour chaque étudiant, son nom complet (nom et prénom séparés par un espace), son id et sa date de naissance.

var students2 = context.Students
                .Select(student => new {
                    Name = $"{student.First_Name} {student.Last_Name}",
                    student.Student_ID,
                    student.BirthDate,
                }
                );

foreach (var student in students2)
{
    Console.WriteLine($"{student.Name} - {student.Student_ID} - {student.BirthDate}");
}
#endregion

#region Exo 1.3
//Exercice 1.3
//Ecrire une requête pour présenter, pour chaque étudiant, dans une seule chaine de caractère l’ensemble des données relatives à un étudiant séparées par le symbole |.

/*var students3 = context.Students
                .Select(student => new
                {
                    Info = $"{string.Join(" | ", student.Student_ID, student.First_Name, student.Last_Name, student.BirthDate, student.Login, student.Year_Result)}"
                }
                );

foreach (var student in students3)
{
    Console.WriteLine(student.Info);
}*/
#endregion


//WHERE & ORDER BY

#region Exo 2.1
//Exercice 2.1
//Pour chaque étudiant né avant 1955, donner le nom, le résultat annuel et le statut. Le statut prend la valeur « OK » si l’étudiant à obtenu au moins 12 comme résultat annuel et « KO » dans le cas contraire.

/*var students4 = from student in context.Students
                where student.BirthDate.Year < 1955
                select new {
                    Name = student.Last_Name,
                    Result = student.Year_Result,
                    Status = student.Year_Result >= 12 ? "OK" : "KO"
                };

foreach (var student in students4)
{
    Console.WriteLine($"{string.Join(" | ", student.Name, student.Result, student.Status)}");
}*/
#endregion

#region Exo 2.2
//Exercice 2.2
//Donner pour chaque étudiant entre 1955 et 1965 le nom, le résultat annuel et la catégorie à laquelle il appartient. La catégorie est fonction du résultat annuel obtenu ; un résultat inférieur à 10 appartient à la catégorie « inférieure », un résultat égal à 10 appartient à la catégorie « neutre », un résultat autre appartient à la catégorie « supérieure ».

/*var students5 = from student in context.Students
                where (1955 < student.BirthDate.Year && student.BirthDate.Year < 1965)
                select new {
                    Name = student.Last_Name,
                    Result = student.Year_Result,
                    Category = student.Year_Result < 10 ? "inférieure" :
                               student.Year_Result == 10 ? "neutre" : "supérieur"
                    };

foreach (var student in students5)
{
    Console.WriteLine($"{string.Join(" | ", student.Name, student.Result, student.Category)}");
}*/
#endregion

#region Exo 2.3
//Exercice 2.3
//Ecrire une requête pour présenter le nom, l’id de section et de tous les étudiants qui ont un nom de famille qui termine par r.

/*var students6 = context.Students
                .Select(student => new
                {
                    student.Last_Name,
                    student.Section_ID
                })
                //.Where(student => student.Last_Name[student.Last_Name.Length - 1] == 'r');
                .Where(student => student.Last_Name.EndsWith('r'));

foreach (var student in students6)
{
    Console.WriteLine($"{string.Join(" | ", student.Last_Name, student.Section_ID)}");
}*/
#endregion

#region Exo 2.4
//Exercice 2.4
//Ecrire une requête pour présenter le nom et le résultat annuel classé par résultats annuels décroissant de tous les étudiants qui ont obtenu un résultat annuel inférieur ou égal à 3.

var students7 = context.Students
                .Select(student => new
                {
                    student.Last_Name,
                    student.Year_Result
                })
                .OrderByDescending(student =>  student.Year_Result)
                .Where(student => student.Year_Result <= 3);

foreach (var student in students7)
{
    Console.WriteLine($"{string.Join(" | ", student.Last_Name, student.Year_Result)}");
}
#endregion

#region Exo 2.5
//Exercice 2.5
//Ecrire une requête pour présenter le nom complet (nom et prénom séparés par un espace) et le résultat annuel classé par nom croissant sur le nom de tous les étudiants appartenant à la section 1110.

/*var students8 =
                from student in context.Students
                where student.Section_ID == 1110
                orderby student.Last_Name
                select new
                {
                    student.Last_Name,
                    student.First_Name,
                    student.Year_Result
                };

foreach (var student in students8)
{
    Console.WriteLine($"{student.Last_Name} {student.First_Name} - {student.Year_Result}");
}*/
#endregion


#region Exo 2.6
//Exercice 2.6
//Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel classé par ordre croissant sur la section de tous les étudiants appartenant aux sections 1010 et 1020 ayant un résultat annuel qui n’est pas compris entre 12 et 18.

/*var students9 =
                from student in context.Students
                where (student.Section_ID == 1110 || student.Section_ID == 1020) && (student.Year_Result < 12 || student.Year_Result > 18)
                orderby student.Section_ID descending
                select new
                {
                    student.Last_Name,
                    student.Section_ID,
                    student.Year_Result
                };

foreach (var student in students9)
{
    Console.WriteLine($"{student.Last_Name} {student.Section_ID} - {student.Year_Result}");
}*/
#endregion


#region Exo 2.7
//Exercice 2.7
//Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel sur 100(nommer la colonne ‘result_100’) classé par ordre décroissant du résultat de tous les étudiants appartenant aux sections commençant par 13 et ayant un résultat annuel sur 100 inférieur ou égal à 60.

/*var students10 =
                from student in context.Students
                where student.Section_ID.ToString().Substring(0, 2) == "13" && student.Year_Result * 5 <= 60
                orderby student.Year_Result descending
                select new
                {
                    Name = student.Last_Name,
                    ID = student.Section_ID,
                    Result = student.Year_Result * 5
                };

foreach (var student in students10)
{
    Console.WriteLine($"{student.Name} {student.ID} - {student.Result}");
}*/
#endregion