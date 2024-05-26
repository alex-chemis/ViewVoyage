using ContentMicroservice.Data;
using ContentMicroservice.Dtos.Content;
using ContentMicroservice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ContentMicroservice.Repositories;

public class ContentRepository(ContentDbContext dbContext) : IContentRepository
{
    private readonly DbSet<Content> _contents = dbContext.Contents;
    
    public async Task<IList<ContentDto>> GetContents()
    {
        var contentList = await _contents.ToListAsync();
        var contentDtoList = new List<ContentDto>();

        foreach (var content in contentList)
        {
            contentDtoList.Add(ContentToContentDto(content));
        }

        return contentDtoList;
    }
        

    public async Task<ContentDto?> GetContent(Guid id)
    {
        var content = await _contents.FirstOrDefaultAsync(c => c.Id == id);

        if (content is null)
        {
            return null;
        }

        return ContentToContentDto(content);
    }
        

    public async Task<ContentDto> CreateContent(CreateContentDto createContentDto)
    {
        var content = new Content
        {
            Title = createContentDto.Title,
            Quality = createContentDto.Quality,
            Genre = createContentDto.Genre,
            Category = createContentDto.Category,
            AgeRestriction = createContentDto.AgeRestriction,
            Description = createContentDto.Description,
            Thumbnail = createContentDto.Thumbnail,
            CreatedDate = DateTime.Now,
            RemainingTime = createContentDto.RemainingTime
        };

        if (createContentDto.CastMembers is not null)
        {
            foreach (var castMember in createContentDto.CastMembers)
            {
                content.CastMembers.Add(new CastMember{
                    EmployeeFullName = castMember.EmployeeFullName,
                    RoleName = castMember.RoleName,
                    Content = content
                });
            }
        }
        

        await _contents.AddAsync(content);
        await dbContext.SaveChangesAsync();

        return ContentToContentDto(content);
    }

    public async Task<ContentDto?> UpdateContent(Guid id, UpdateContentDto updateContentDto)
    {
        var content = await _contents.FirstOrDefaultAsync(c => c.Id == id);
        
        if (content is null)
        {
            return null;
        }

        content.Title = updateContentDto.Title ?? content.Title;
        content.Quality = updateContentDto.Quality ?? content.Quality;
        content.Genre = updateContentDto.Genre ?? content.Genre;
        content.Category = updateContentDto.Category ?? content.Category;
        content.AgeRestriction = updateContentDto.AgeRestriction ?? content.AgeRestriction;
        content.Description = updateContentDto.Description ?? content.Description;
        content.Thumbnail = updateContentDto.Thumbnail ?? content.Thumbnail;
        content.RemainingTime = updateContentDto.RemainingTime ?? content.RemainingTime;

        if (updateContentDto.CastMembers is not null)
        {
            content.CastMembers.Clear();
            foreach (var castMember in updateContentDto.CastMembers)
            {
                content.CastMembers.Add(new CastMember{
                    EmployeeFullName = castMember.EmployeeFullName,
                    RoleName = castMember.RoleName,
                    Content = content
                });
            }
        }

        return ContentToContentDto(content);
    }

    public async Task<bool> DeleteContent(Guid id)
    {
        var oldContent = await _contents.FirstOrDefaultAsync(c => c.Id == id);
        if (oldContent is not null)
        {
            dbContext.Remove(oldContent);
            return true;
        }
        else
        {
            return false;
        }
    }

    ContentDto ContentToContentDto(Content content)
    {
        var contentDto = new ContentDto{
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