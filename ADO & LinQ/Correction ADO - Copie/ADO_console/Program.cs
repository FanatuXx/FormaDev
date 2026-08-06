using Microsoft.Data.SqlClient;

string connectionString = "votreConnexionString";

using (SqlConnection connection = new SqlConnection(connectionString))
{
	/*
	connection.Open();

	Console.WriteLine("Connexion ouverte");

	connection.Close();
	*/

	using (SqlCommand command = connection.CreateCommand())
	{
		connection.Open();
		command.CommandText = $"""
			SELECT Id, FirstName, LastName
			FROM V_Student;
			""";

		using (SqlDataReader reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				Console.WriteLine($"{reader["Id"]}: {reader["FirstName"]} {reader["LastName"]}");
			}
		}

		command.CommandText = $"""
			SELECT AVG(CONVERT(FLOAT,YearResult))
			FROM Student;
			""";

		Console.WriteLine(command.ExecuteScalar());
	}
}
	