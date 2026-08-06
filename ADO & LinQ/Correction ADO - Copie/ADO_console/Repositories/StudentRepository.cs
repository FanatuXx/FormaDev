using ADO_console.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

//Principe du repository : CLASSE POUR NOS DEMANDES DB !

namespace ADO_console.Repository
{
    public class StudentRepository
    {
        private readonly SqlConnection _connection;

        public StudentRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public Student Mapper (IDataReader record)
        {
            return new Student(
                (int)record["Id"],
                (string)record["FirstName"],
                (string)record["LastName"],
                (DateTime)record["BirthDate"],
                (int)record["YearResult"],
                (int)record["SectionID"],
                (bool)record["Active"]
                );
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            _connection.Open();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = $"""
			    SELECT Id, FirstName, LastName
			    FROM V_Student;
			    """;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(Mapper(reader));
                    }
                }
            }

            _connection.Close();
            return students;
        }

        public Student? GetOneById()
        {
            Student student = new Student;
            _connection.Open();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = $"""
			    SELECT Id, FirstName, LastName
			    FROM V_Student;
                WHERE 
			    """;

                command.Parameters.AddWithValue("id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        student = Mapper(reader);
                    }
                }
            }

            _connection.Close();
            return student;
        }


        public int Create(Student student)
        {

            return Create1(student);
        }

        private int Create1(Student student)
        {
            int id = -1;
            _connection.Open();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = $"""
                    exec dbo.Student
                        @firstName
                        @lastName
                        @birthDate
                        @yearResult
                        @sectionId;
                    """;

                command.Parameters.AddWithValue("firstName", student.FirstName);
                command.Parameters.AddWithValue("lastName", student.LastName);
                command.Parameters.AddWithValue("birthDate", student.BirthDate);
                command.Parameters.AddWithValue("sectionID", student.SectionID);
                command.Parameters.AddWithValue("yearResult", student.YearResult);

                command.ExecuteNonQuery();

                command.CommandText = "SELECT @@IDENTITY;";

                id = decimal.ToInt32((decimal)command.ExecuteScalar());
            }

            _connection.Close();
            return id;

        }

        private int Create2(Student student)
        {
            int id = -1;
            _connection.Open();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = $"""
                    INSERT INTO Student (
                        FirstName, 
                        LastName, 
                        BirthDate, 
                        YearResult, 
                        SectionID)		
                    OUTPUT inserted.Id
                    VALUES(
                        @firstName,
                        @lastName,
                        @birthDate,
                        @yearResult,
                        @sectionID
                    );
                    """;

                command.Parameters.AddWithValue("firstName", student.FirstName);
                command.Parameters.AddWithValue("lastName", student.LastName);
                command.Parameters.AddWithValue("birthDate", student.BirthDate);
                command.Parameters.AddWithValue("sectionID", student.SectionID);
                command.Parameters.AddWithValue("yearResult", student.YearResult);

                command.ExecuteNonQuery();

                command.CommandText = "SELECT @@IDENTITY;";

                id = decimal.ToInt32((decimal)command.ExecuteScalar());
            }

            _connection.Close();
            return id;

        }
    }
}
