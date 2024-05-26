using ContentMicroservice.Dtos.Content;
using ContentMicroservice.Dtos.Episode;
using ContentMicroservice.Models;

namespace ContentMicroservice.Repositories;

public interface IEpisodeRepository
{
    Task<IList<EpisodeDto>> GetEpisodes();
    Task<EpisodeDto?> GetEpisode(Guid id);
    Task<EpisodeDto?> CreateEpisode(CreateEpisodeDto createContentDto);
    Task<EpisodeDto?> UpdateEpisode(Guid id, UpdateEpisodeDto updateContentDto);
    Task<bool> DeleteEpisode(Guid id);
}