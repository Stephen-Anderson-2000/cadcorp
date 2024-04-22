using Cadcorp.Utilities;

const string FILE_PATH = "data.csv";
var addresses = FileUtility.ReadAddressCSV(FILE_PATH);
var insertedRows = DatabaseUtility.InsertAddresses(addresses);
Console.WriteLine($"Inserted {insertedRows} into the database");
