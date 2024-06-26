namespace ContentMicroservice.Dtos.Episode;

public class CreateEpisodeDto
{
    public int Number { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? S3BucketName { get; set; }
    public Guid ContentId { get; set; }
}
