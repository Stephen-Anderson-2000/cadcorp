using Cadcorp.Database;

namespace Cadcorp.Utilities;

public class DatabaseUtility
{
    public static int InsertAddresses(List<Address> addressList)
    {
        var insertedRows = 0;

        using (var db = new AddressContext())
        {
            foreach (var address in addressList)
            {
                db.Addresses.Add(address);
            }

            insertedRows = db.SaveChanges();
        }

        return insertedRows;
    }
}
