using ADO_console.Model;
using ADO_console.Repository;
using Microsoft.Data.SqlClient;

string connectionString = "Data Source=GOS-VDI205\\TFTIC;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Command Timeout=0";

using (SqlConnection connection = new SqlConnection(connectionString))
{
	/*
	connection.Open();

	Console.WriteLine("Connexion ouverte");

	connection.Close();
	*/

	StudentRepository studentRepository = new StudentRepository(connection);

	List<Student> students = studentRepository.GetAll();

	foreach(Student student in students)
	{
        Console.WriteLine($"{student.Id} - {student.LastName}");
	}

		//command.CommandText = $"""
		//	SELECT AVG(CONVERT(FLOAT,YearResult))
		//	FROM Student;
		//	""";

	
}
	