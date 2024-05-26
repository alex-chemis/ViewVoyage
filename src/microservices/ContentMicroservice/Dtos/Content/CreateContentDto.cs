using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContentMicroservice.Dtos.Content;

public class CreateContentDto
{
    public string Title { get; set; } = null!;
    public string Quality { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string AgeRestriction { get; set; } = null!;
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public DateTime? RemainingTime { get; set; }
    public List<CastMemberDto>? CastMembers { get; set; }
}
