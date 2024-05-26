using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace ContentMicroservice.Models;

[Index(nameof(FullName), IsUnique = true)]
public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public BigInteger Id { get; set; }
    public string FullName { get; set; } = null!;
    
    public virtual ICollection<CastMember> CastMembers { get; set; } = new HashSet<CastMember>();
}
