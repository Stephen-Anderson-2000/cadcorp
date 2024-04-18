namespace Cadcorp.Database;

public class AddressModel
{
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    public required string Town { get; set; }
    public required string PostCode { get; set; }
}
