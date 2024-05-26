namespace ContentMicroservice.Dtos.Episode;

public class EpisodeDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? S3BucketName { get; set; }
    public Guid ContentId { get; set; }

    public static EpisodeDto FromEpisode(Models.Episode episode)
    {
        return new EpisodeDto{
            Id = episode.Id,
            Number = episode.Number,
            Title = episode.Title,
            Description = episode.Description,
            S3BucketName = episode.S3BucketName,
            ContentId = episode.Content.Id
        };
    }
}
