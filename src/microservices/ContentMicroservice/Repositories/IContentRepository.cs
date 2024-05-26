using ContentMicroservice.Dtos.Content;
using ContentMicroservice.Models;

namespace ContentMicroservice.Repositories;

public interface IContentRepository
{
    Task<IList<ContentDto>> GetContents();
    Task<ContentDto?> GetContent(Guid id);
    Task<ContentDto> CreateContent(CreateContentDto createContentDto);
    Task<ContentDto?> UpdateContent(Guid id, UpdateContentDto updateContentDto);
    Task<bool> DeleteContent(Guid id);
}