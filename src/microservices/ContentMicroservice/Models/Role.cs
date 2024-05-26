using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ContentMicroservice.Models;

[Index(nameof(Name), IsUnique = true)]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<CastMember> CastMembers { get; set; } = new HashSet<CastMember>();
}
