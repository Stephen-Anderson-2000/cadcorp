using Cadcorp.Database;
using Microsoft.EntityFrameworkCore;

namespace Cadcorp.Utilities;

public class DatabaseUtility
{
    public static int InsertAddresses(List<Address> addressList, string connectionString = "Data Source=/Database/cadcorp.db")
    {
        var insertedRows = 0;

        var options = new DbContextOptionsBuilder<AddressContext>().
            UseSqlite(connectionString)
            .Options;

        using (var db = new AddressContext(options))
        {
            var addressSet = db.Set<Address>();
            foreach (var address in addressList)
            {
                addressSet.Add(address);
            }

            insertedRows = db.SaveChanges();
        }

        return insertedRows;
    }
}
