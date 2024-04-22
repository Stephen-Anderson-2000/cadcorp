using Cadcorp.Database;
using Microsoft.VisualBasic.FileIO;

namespace Cadcorp.Utilities;
public class FileUtility
{
    public static List<Address> ReadAddressCSV(string filePath)
    {
        using var csvReader = new TextFieldParser(filePath);
        csvReader.SetDelimiters([","]);
        csvReader.HasFieldsEnclosedInQuotes = true;

        // Ignore the column names
        csvReader.ReadLine();

        var addressList = new List<Address>();
        while (!csvReader.EndOfData)
        {
            // Read current line fields, pointer moves to the next line.
            var fields = csvReader.ReadFields();
            if (fields?.Length > 0)
            {
                addressList.Add(ParseAddress(fields[0], fields[1]));
            }
        }

        return addressList;
    }

    public static Address ParseAddress(string addressString, string postCode)
    {
        var addressFields = addressString.Split(", ");
        var address = new Address() { Line1 = addressFields[0], Town = addressFields[^1], PostCode = postCode };

        if (addressFields.Length >= 3)
        {
            address.Line2 = addressFields[1];
        }

        if (addressFields.Length == 4)
        {
            address.Line3 = addressFields[2];
        }

        return address;
    }
}
