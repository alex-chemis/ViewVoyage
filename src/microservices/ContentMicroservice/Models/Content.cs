using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContentMicroservice.Models;

public class Content
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Quality { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string AgeRestriction { get; set; } = null!;
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? RemainingTime { get; set; }

    public virtual ICollection<CastMember> CastMembers { get; set; } = new HashSet<CastMember>();
    public virtual ICollection<Episode> Episodes { get; set; } = new HashSet<Episode>();
}
