using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

string connectionString = "Data Source=DESKTOP-O5VLMCD;"
                           + "Integrated Security = True;"
                           + "Connect Timeout = 60;"
                           + "Encrypt = True;"
                           + "Trust Server Certificate=True;"
                           + "Application Intent = ReadWrite;"
                           + "Multi Subnet Failover=False;"
                           + "Command Timeout = 30;";

//SqlConnection connection = new SqlConnection(connectionString);

//connection.Open();
//Console.WriteLine("Connexion ouverte");
//connection.Close();

using (SqlConnection connection = new SqlConnection(connectionString))
{

}

using (SqlCommand command1 = new SqlCommand())
{
    command1.Connection = connection;
}



//ExecutScalar -> Pour un résultat simple, 1 seule valeur
//SqlDataReader -> Pour donner une résultat ligne par ligne 