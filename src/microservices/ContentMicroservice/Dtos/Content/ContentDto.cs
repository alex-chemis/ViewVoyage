using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContentMicroservice.Dtos.Content;

public class ContentDto
{
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
    public List<CastMemberDto> CastMembers { get; set; } = new List<CastMemberDto>();

    public static ContentDto FromContent(Models.Content content)
    {
        var contentDto = new ContentDto{
            Id = content.Id,
            Title = content.Title,
            Quality = content.Quality,
            Genre = content.Genre,
            Category = content.Category,
            AgeRestriction = content.AgeRestriction,
            Description = content.Description,
            Thumbnail = content.Thumbnail,
            CreatedDate = content.CreatedDate,
            RemainingTime = content.RemainingTime
        };

        foreach (var castMember in content.CastMembers)
        {
            contentDto.CastMembers.Add(new CastMemberDto{
                EmployeeFullName = castMember.EmployeeFullName,
                RoleName = castMember.RoleName
            });
        }

        return contentDto;
    }
}
