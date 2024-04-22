using Cadcorp.Utilities;

const string FILE_PATH = "data.csv";
var addresses = FileUtility.ReadAddressCSV(FILE_PATH);
var insertCount = DatabaseUtility.InsertAddresses(addresses);

Console.WriteLine($"{insertCount} row(s) inserted");
