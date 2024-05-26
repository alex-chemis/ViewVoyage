using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContentMicroservice.Dtos.Content;

public class UpdateContentDto
{
    public string? Title { get; set; }
    public string? Quality { get; set; }
    public string? Genre { get; set; }
    public string? Category { get; set; }
    public string? AgeRestriction { get; set; }
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public DateTime? RemainingTime { get; set; }
    public List<CastMemberDto>? CastMembers { get; set; }
}
