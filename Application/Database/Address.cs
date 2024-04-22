using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadcorp.Database;

[Table("Address")]
public class Address
{
    [Column("id")]
    [Key]
    public int Id { get; set; }
    [Column("line1")]
    public required string Line1 { get; set; }
    [Column("line2")]
    public string? Line2 { get; set; }
    [Column("line3")]
    public string? Line3 { get; set; }
    [Column("town")]
    public required string Town { get; set; }
    [Column("postcode")]
    public required string PostCode { get; set; }
}