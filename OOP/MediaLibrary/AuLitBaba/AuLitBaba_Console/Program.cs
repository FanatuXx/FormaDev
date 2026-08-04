using Microsoft.Data.SqlClient;

string connectionString = "";

//SqlConnection connection = new SqlConnection();
//connection.ConnectionString = connectionString;

SqlConnection connection = new SqlConnection(connectionString);

Console.WriteLine(connection.State);
connection.Open();
Console.WriteLine(connection.State);
connection.Close();

using (SqlConnection connection2 = new SqlConnection(connectionString))
{
    Console.WriteLine("Dans le using");
    Console.WriteLine(connection2.State);
}
