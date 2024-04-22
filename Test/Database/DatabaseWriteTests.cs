using Cadcorp.Database;
using Cadcorp.Utilities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Test.Database;

public class DatabaseWriteTests
{
    [Fact(Skip = "Doesn't run properly in memory")]
    public void DatabaseConnects()
    {
        var options = new DbContextOptionsBuilder<AddressContext>().
            UseSqlite("Data Source=:memory:;")
            .Options;

        using var db = new AddressContext(options);
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        db.Add(new Address { Line1 = "11 Bramley Hill", Town = "Ipswich", PostCode = "IP4 2AE" });
        var result = db.SaveChanges();
        result.Should().Be(1);
    }

    [Fact(Skip = "Doesn't run in memory")]
    public void DatabaseInserts_Single()
    {
        var address = new List<Address> { new() { Line1 = "11 Bramley Hill", Town = "Ipswich", PostCode = "IP4 2AE" } };
        var result = DatabaseUtility.InsertAddresses(address);
        result.Should().Be(address.Count);
    }

    [Fact(Skip = "Doesn't run in memory")]
    public void DatabaseInserts_Multiple()
    {
        var addresses = new List<Address>() {
            new() { Line1 = "30 Gilpins Gallop", Town = "Stanstead Abbotts", PostCode = "SG12 8BD" },
            new() { Line1 = "Mulberry House", Line2 = "Danebridge Road", Town = "Much Hadham", PostCode = "SG10 6HY" },
            new() { Line1 = "Unit A", Line2 = "Mindenhall Court", Line3 = "High Street", Town = "Stevenage", PostCode = "SG1 3UN" }
        };
        var result = DatabaseUtility.InsertAddresses(addresses);
        result.Should().Be(addresses.Count);
    }
}