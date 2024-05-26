using ContentMicroservice.Data;
using ContentMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace ContentMicroservice.Repositories;

public class ContentRepository(ContentDbContext dbContext) : IContentRepository
{
    private readonly DbSet<Content> _contents = dbContext.Contents;
    
    public async Task<IList<Content>> GetContents() =>
        await _contents.ToListAsync();

    public async Task<Content?> GetContent(Guid id) =>
        await _contents.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Content> CreateContent(Content content)
    {
        await _contents.AddAsync(content);
        await dbContext.SaveChangesAsync();
        return content;
    }

    public async Task<Content?> UpdateContent(Content content)
    {
        var oldContent = await GetContent(content.Id);
        if (oldContent is not null)
        {
            dbContext.Entry(oldContent).CurrentValues.SetValues(content);
            await dbContext.SaveChangesAsync();
        }
        return oldContent;
    }

    public async Task<bool> DeleteContent(Guid id)
    {
        var oldContent = await GetContent(id);
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

}