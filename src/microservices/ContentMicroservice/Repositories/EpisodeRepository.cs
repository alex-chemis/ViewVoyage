using ContentMicroservice.Data;
using ContentMicroservice.Dtos.Content;
using ContentMicroservice.Dtos.Episode;
using ContentMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace ContentMicroservice.Repositories;

public class EpisodeRepository(ContentDbContext dbContext) : IEpisodeRepository
{
    private readonly DbSet<Episode> _episodes = dbContext.Episodes;

    public async Task<IList<EpisodeDto>> GetEpisodes()
    {
        var episodeList = await _episodes.ToListAsync();
        var episodeDtoList = new List<EpisodeDto>();

        foreach (var episode in episodeList)
        {
            episodeDtoList.Add(EpisodeDto.FromEpisode(episode));
        }

        return episodeDtoList;
    }
    
    public async Task<EpisodeDto?> GetEpisode(Guid id)
    {
        var episode = await _episodes.FirstOrDefaultAsync(c => c.Id == id);

        if (episode is null)
        {
            return null;
        }

        return EpisodeDto.FromEpisode(episode);
    }

    public async Task<EpisodeDto?> CreateEpisode(CreateEpisodeDto createEpisodeDto)
    {
        var content = await dbContext.Contents.FirstAsync(c => c.Id == createEpisodeDto.ContentId);

        if (content is null)
        {
            return null;
        }

        var episode = new Episode{
            Number = createEpisodeDto.Number,
            Title = createEpisodeDto.Title,
            Description = createEpisodeDto.Description,
            S3BucketName = createEpisodeDto.S3BucketName,
            Content = content
        };
        
        await _episodes.AddAsync(episode);
        await dbContext.SaveChangesAsync();

        return EpisodeDto.FromEpisode(episode);
    }

    public async Task<EpisodeDto?> UpdateEpisode(Guid id, UpdateEpisodeDto updateEpisodeDto)
    {
        var episode = await _episodes.FirstOrDefaultAsync(c => c.Id == id);
        
        if (episode is null)
        {
            return null;
        }

        episode.Number = updateEpisodeDto.Number ?? episode.Number;
        episode.Title = updateEpisodeDto.Title ?? episode.Title;
        episode.Description = updateEpisodeDto.Description ?? episode.Description;
        episode.S3BucketName = updateEpisodeDto.S3BucketName ?? episode.S3BucketName;

        if (updateEpisodeDto.ContentId is not null)
        {
            episode.Content = await dbContext.Contents.FirstOrDefaultAsync(c => c.Id == updateEpisodeDto.ContentId) ?? episode.Content;
        }

        await dbContext.SaveChangesAsync();

        return EpisodeDto.FromEpisode(episode);
    }

    public async Task<bool> DeleteEpisode(Guid id)
    {
        var oldEpisode =  await _episodes.FirstOrDefaultAsync(c => c.Id == id);
        if (oldEpisode is not null)
        {
            dbContext.Remove(oldEpisode);
            await dbContext.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    
}