using Cadcorp.Database;
using Cadcorp.Utilities;
using FluentAssertions;

namespace Test.FileHandling;
public class FileUtilityTests
{
    public static IEnumerable<object[]> GetAddresses()
    {
        yield return new object[] { "", "", new Address() { Line1 = "", Town = "", PostCode = "" } };
        yield return new object[] { "30 Gilpins Gallop, Stanstead Abbotts", "SG12 8BD", new Address() { Line1 = "30 Gilpins Gallop", Town = "Stanstead Abbotts", PostCode = "SG12 8BD" } };
        yield return new object[] { "Mulberry House, Danebridge Road, Much Hadham", "SG10 6HY", new Address() { Line1 = "Mulberry House", Line2 = "Danebridge Road", Town = "Much Hadham", PostCode = "SG10 6HY" } };
        yield return new object[] { "Unit A, Mindenhall Court, High Street, Stevenage", "SG1 3UN", new Address() { Line1 = "Unit A", Line2 = "Mindenhall Court", Line3 = "High Street", Town = "Stevenage", PostCode = "SG1 3UN" } };
    }

    [Theory]
    [MemberData(nameof(GetAddresses))]
    public void ParseAdressTest(string addressString, string postCode, Address expected)
    {
        var result = FileUtility.ParseAddress(addressString, postCode);
        result.Line1.Should().Be(expected.Line1);
        result.Line2.Should().Be(expected.Line2);
        result.Line3.Should().Be(expected.Line3);
        result.Town.Should().Be(expected.Town);
        result.Line1.Should().Be(expected.Line1);
    }

    [Fact]
    public void ReadAddressFileTest()
    {
        var filePath = "FileHandling/testFile.csv";
        var expected = new List<Address>() {
            new() { Line1 = "30 Gilpins Gallop", Town = "Stanstead Abbotts", PostCode = "SG12 8BD" },
            new() { Line1 = "Mulberry House", Line2 = "Danebridge Road", Town = "Much Hadham", PostCode = "SG10 6HY" },
            new() { Line1 = "Unit A", Line2 = "Mindenhall Court", Line3 = "High Street", Town = "Stevenage", PostCode = "SG1 3UN" }
        };

        var result = FileUtility.ReadAddressCSV(filePath);

        result.Should().BeEquivalentTo(expected);
    }
}
