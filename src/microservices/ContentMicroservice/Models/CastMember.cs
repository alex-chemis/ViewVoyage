using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ContentMicroservice.Models;

public class CastMember
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public BigInteger Id { get; set; }
    public Content Content { get; set; } = null!;
    public Employee employee { get; set; } = null!;
    public Role Role { get; set; } = null!;
}