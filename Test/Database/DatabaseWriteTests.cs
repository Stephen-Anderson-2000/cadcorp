namespace Test.Database;

public class DatabaseWriteTests
{
    // use a cache - allows a connection to be opened, the table to be initialised and then the tests to run
    private const string CONNECTION_STRING = "Data Source=:memory:;";

    [Fact]
    public void DatabaseConnects()
    {
        var connection = new SqliteConnection(CONNECTION_STRING);
        connection.Open();

        var options = new DbContextOptionsBuilder<AddressContext>().
            UseSqlite(CONNECTION_STRING)
            .Options;

        using var db = new AddressContext(options);
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        db.Add(new Address { Id = 1, Line1 = "11 Bramley Hill", Town = "Ipswich", PostCode = "IP4 2AE" });
        var result = db.SaveChanges();
        result.Should().Be(1);
    }

    [Fact]
    public void DatabaseInserts_Single()
    {
        var address = new Address[] { new() { Line1 = "11 Bramley Hill", Town = "Ipswich", PostCode = "IP4 2AE" } };
        var result = DatabaseUtility.InsertAddresses(address, CONNECTION_STRING);
        result.Should().Be(address.Length);
    }
}