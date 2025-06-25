// See https://aka.ms/new-console-template for more information
using System;
using MySql.Data.MySqlClient;
using System.Data;
Console.WriteLine("Hello, World!");

var ConnectionString = "server=localhost;port=3306;user=root;password=password;database=tflmentoringdb";

string sql = "SELECT * FROM topics";
 MySqlConnection connection = new MySqlConnection(ConnectionString);
/*
try
{
    MySqlCommand cmd = new MySqlCommand(sql, connection);
    connection.Open();
    MySqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Id: {reader["Id"]}, Title: {reader["Title"]}, Url: {reader["Url"]}");
    }


}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
finally
{
    Console.WriteLine("Execution completed.");
    connection.Close();
    Console.WriteLine("Connection closed.");
}
*/

string getTopicByIdSql = "SELECT * FROM topics WHERE Id = @Id";
MySqlCommand getTopicByIdCmd = new MySqlCommand(getTopicByIdSql, connection);
getTopicByIdCmd.Parameters.AddWithValue("@Id", 1);
try
{
    connection.Open();
    MySqlDataReader reader = getTopicByIdCmd.ExecuteReader();
    if (reader.Read())
    {
        Console.WriteLine($"Id: {reader["Id"]}, Title: {reader["Title"]}, Url: {reader["Url"]}");
    }
    else
    {
        Console.WriteLine("No topic found with the specified Id.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
finally
{
    connection.Close();
}