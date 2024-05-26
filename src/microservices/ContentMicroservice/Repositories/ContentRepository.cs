using ContentMicroservice.Data;
using ContentMicroservice.Dtos.Content;
using ContentMicroservice.Dtos.Episode;
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
            contentDtoList.Add(ContentDto.FromContent(content));
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

        return ContentDto.FromContent(content);
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

        return ContentDto.FromContent(content);
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
            dbContext.RemoveRange(await dbContext.CastMembers.Where(s => s.Content.Id == content.Id).ToListAsync());
            foreach (var castMember in updateContentDto.CastMembers)
            {
                await dbContext.CastMembers.AddAsync(new CastMember{
                    EmployeeFullName = castMember.EmployeeFullName,
                    RoleName = castMember.RoleName,
                    Content = content
                });
            }
        }

        await dbContext.SaveChangesAsync();

        return ContentDto.FromContent(content);
    }

    public async Task<bool> DeleteContent(Guid id)
    {
        var oldContent = await _contents.FirstOrDefaultAsync(c => c.Id == id);
        if (oldContent is not null)
        {
            dbContext.Remove(oldContent);
            await dbContext.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<IList<EpisodeDto>?> GetEpisodes(Guid id)
    {
        var content = await _contents.FirstOrDefaultAsync(c => c.Id == id);

        if (content is null)
        {
            return null;
        }
        
        var episodeList =  await dbContext.Episodes.Where(e => e.Content.Id == id).ToListAsync();
        var episodeDtoList = new List<EpisodeDto>();

        foreach (var episode in episodeList)
        {
            episodeDtoList.Add(EpisodeDto.FromEpisode(episode));
        }

        return episodeDtoList;
    }
}