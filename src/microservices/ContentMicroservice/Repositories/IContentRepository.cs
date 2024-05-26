using ContentMicroservice.Models;

namespace ContentMicroservice.Repositories;

public interface IContentRepository
{
    Task<IList<Content>> GetContents();
    Task<Content?> GetContent(Guid id);
    Task<Content> CreateContent(Content content);
    Task<Content?> UpdateContent(Content content);
    Task<bool> DeleteContent(Guid id);
}