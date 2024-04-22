using Cadcorp.Utilities;

Console.WriteLine("Hello, please enter the file path of the CSV you'd like to import:");
var filePath = Console.ReadLine();

var addresses = FileUtility.ReadAddressCSV(filePath);
var insertCount = DatabaseUtility.InsertAddresses(addresses);

Console.WriteLine($"{insertCount} row(s) inserted");
