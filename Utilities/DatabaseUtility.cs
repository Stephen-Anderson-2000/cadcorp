using Cadcorp.Database;
using System.Data.SQLite;
using System.Text.Json;

namespace Cadcorp.Utilities;

public class DatabaseUtility
{
    private SQLiteConnection sqlite;

    public DatabaseUtility()
    {
        sqlite = new("Data Source=/Database/cadcorp.db");
    }

    public int InsertAddresses(AddressModel[] addresses)
    {
        var insertedRows = 0;
        sqlite.Open();

        foreach (var address in addresses)
        {
            insertedRows += InsertAddress(address);
        }

        sqlite.Close();

        return insertedRows;
    }

    /// <summary>
    /// SQLite doesn't have very nice syntax to support inserting multiple rows 
    /// and there is minimal performance improvement by using it
    /// </summary>
    private int InsertAddress(AddressModel address)
    {
        var query = "INSERT INTO Address (Line1, Line2, Line3, Town, Postcode) VALUES (?,?,?,?,?)";
        var command = sqlite.CreateCommand();
        command.CommandText = query;
        command.Parameters.Add(address.Line1);
        command.Parameters.Add(address.Line2);
        command.Parameters.Add(address.Line3);
        command.Parameters.Add(address.Town);
        command.Parameters.Add(address.PostCode);
        try
        {
            command.ExecuteNonQuery();
        }
        catch (SQLiteException ex)
        {
            Console.WriteLine($"Failed to insert address {JsonSerializer.Serialize(address)} with exception {ex.Message}");
        }

        // Successfully inserted row count
        return 1;
    }
}
