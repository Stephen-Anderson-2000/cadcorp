namespace Cadcorp.Database;

public partial class Address
{
    public string Uid { get; set; } = Guid.NewGuid().ToString();

    public string Line1 { get; set; } = null!;

    public string? Line2 { get; set; }

    public string? Line3 { get; set; }

    public string Town { get; set; } = null!;

    public string PostCode { get; set; } = null!;
}
