using Exo_Linq_Context;
using static System.Net.Mime.MediaTypeNames;
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

var students = context.Students
                .Select(student => new
                {
                    Name = student.First_Name,
                    student.BirthDate,
                    student.Login,
                    Result = student.Year_Result,
                    Section = student.Section_ID
                }
                );

foreach (var student in students)
{
    Console.WriteLine($"{student.Name} - {student.BirthDate} - {student.Login} - {student.Result}");
}
#endregion

#region Exo 1.2
//Exercice 1.2
//Ecrire une requête pour présenter, pour chaque étudiant, son nom complet (nom et prénom séparés par un espace), son id et sa date de naissance.

/*var students2 = context.Students
                .Select(student => new {
                    Name = $"{student.First_Name} {student.Last_Name}",
                    student.Student_ID,
                    student.BirthDate,
                }
                );

foreach (var student in students2)
{
    Console.WriteLine($"{student.Name} - {student.Student_ID} - {student.BirthDate}");
}*/
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

/*var students7 = context.Students
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
}*/
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

var students9 =
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
}
#endregion


#region Exo 2.7
//Exercice 2.7
//Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel sur 100(nommer la colonne ‘result_100’) classé par ordre décroissant du résultat de tous les étudiants appartenant aux sections commençant par 13 et ayant un résultat annuel sur 100 inférieur ou égal à 60.

/*var students10 =
                from student in context.Students
                where student.Section_ID.ToString().StartsWith("13") && student.Year_Result * 5 <= 60
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


#region Exo 3.1
//Exercice 3.1
//Donner le résultat annuel moyen pour l’ensemble des étudiants.

/*double averageScore = context.Students.Average(student => student.Year_Result);

Console.WriteLine(averageScore);*/
#endregion

#region Exo 3.2
//Exercice 3.1
//Donner le plus haut résultat annuel obtenu par un étudiant

/*int maxResult = context.Students.Max(student => student.Year_Result);
*/
#endregion

#region Exo 3.3
//Exercice 3.3
//Donner la somme des résultats annuels.

/*int sumResult = context.Students.Sum(student => student.Year_Result);
*/
#endregion

#region Exo 3.4
//Exercice 3.4
//Donner le résultat annuel le plus faible.

/*int minResult = context.Students.Min(student => student.Year_Result);
*/
#endregion

#region Exo 3.5
//Exercice 3.5
//Donner le résultat annDonner le nombre de lignes qui composent la séquence « Students » ayant obtenu un résultat annuel impair.

//Console.WriteLine(context.Students.Count(student => student.Year_Result % 2 != 0));

#endregion


//2 1ers => GroupBy
#region Exo 4.1
//Exercice 4.1
//Donner pour chaque section, le résultat maximum (« Max_Result ») obtenu par les étudiants.

var results = context.Students.GroupBy(student => student.Section_ID)
                    .Select(g => new
                    {
                        MaxResult = g.Max(student => student.Year_Result),
                        Section = g.Key
                    });
                    

foreach (var result in results)
{
    Console.WriteLine($"Section : {group.Key}");
    Console.WriteLine(group.Max(student => student.Result));
}
#endregion


#region Exo 4.2
//Exercice 4.2
//Donner pour toutes les sections commençant par 10, le résultat annuel moyen (« AVGResult ») obtenu par les étudiants

var studentGrouped2 = context.Students
                    .Where(student => student.Section_ID.ToString().StartsWith("10"))
                    .Select(student => new
                    {
                        Result = student.Year_Result,
                        Section = student.Section_ID
                    })
                    .GroupBy(students => students.Section);

foreach (var group in studentGrouped2)
{
    Console.WriteLine($"Section : {group.Key}");
    Console.WriteLine(group.Average(student => student.Result));
}
#endregion


#region Exo 4.3
//Exercice 4.3
//Donner le résultat moyen (« AVGResult ») et le mois en chiffre (« BirthMonth ») pour les étudiants né le même mois entre 1970 et 1985.

var studentGrouped3 = context.Students
                    .Where(student => student.BirthDate.Year > 1970 && student.BirthDate.Year < 1985)
                    .Select(student => new
                    {
                        Result = student.Year_Result,
                        Birth = student.BirthDate
                    })
                    .GroupBy(student => student.Birth.Month);

foreach (var group in studentGrouped3)
{
    Console.WriteLine($"Section : {group.Key}");
    Console.WriteLine(group.Average(student => student.Result));
}
#endregion


#region Exo 4.4
//Exercice 4.4
//Donner pour toutes les sections qui compte plus de 3 étudiants, la moyenne des résultats annuels(« AVGResult »)5.

var resultats4 = context.Students
                    .GroupBy(students => students.Section_ID)
                    .Where(group => group.Count() > 3)
                    .Select(group => new
                    {
                        Count = group.Count(),
                        Section = group.Key,
                        AVGResult = group.Average(student => student.Year_Result)
                    });
                    

foreach (var resultat in resultats4)
{
        Console.WriteLine($"Mois : {resultat.Key} : {resultat.Average(Student => )}");
}
#endregion


#region Exo 4.5
//Exercice 4.5
//Donner pour chaque cours, le nom du professeur responsable ainsi que la section dont le professeur fait parti

var resultats5 = context.Courses.Join(context.Professors,
                            course => course.Professor_ID,
                            professor => professor.Professor_ID,
                            (course, professor) => new
                            {
                                ProfessorName = professor.Professor_Name,
                                CourseName = course.Course_Name,
                                SectionId = professor.Section_ID,
                            })
                            .Join(context.Sections,

                            cp => cp.SectionId,
                            section => section.Section_ID,
                            (cp, section) =>
                            new
                            {
                                CourseName = cp.CourseName,
                                ProfessorName = cp.ProfessorName,
                                SectionName = section.Section_Name
                            });

foreach (var resultat in resultats5)
{
    Console.WriteLine($"{resultat.CourseName} {resultat.ProfessorName} {resultat.SectionName}");
}
#endregion


#region Exo 4.6
//Exercice 4.6

var resultats6 = context.Sections.Join(context.Students,
                            section => section.Delegate_ID,
                            student => student.Student_ID,
                            (section, student) => new
                            {
                                student.Last_Name,
                                section.Section_Name,
                                section.Section_ID,
                            })
                            .OrderBy

foreach (var resultat in resultats5)
{
    Console.WriteLine($"{resultat.CourseName} {resultat.ProfessorName} {resultat.SectionName}");
}
#endregion









