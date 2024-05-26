namespace ContentMicroservice.Models;

public class Episode
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? S3BucketName { get; set; }
    public virtual Content Content { get; set; } = null!;
}