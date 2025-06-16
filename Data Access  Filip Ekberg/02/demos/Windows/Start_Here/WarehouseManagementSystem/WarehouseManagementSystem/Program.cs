using Microsoft.Data.Sqlite;
using System.Data.SqlClient;

/// TODO
/// CHANGE AttachDbFilename TO POINT TO THE DATABASE FILE (MDF)
using SqliteConnection connection
    = new SqliteConnection(@"data source=C:\Users\admin\Desktop\C-Sharp-Interview-Prep\Data Access  Filip Ekberg\02\demos\Windows\Start_Here\WarehouseManagementSystem\WarehouseManagementSystem\warehouse.db");

using SqliteCommand command
    = new SqliteCommand("SELECT * FROM [Orders]", connection);

connection.Open();

using SqliteDataReader reader =
    command.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader["Id"]);
}

Console.ReadLine();