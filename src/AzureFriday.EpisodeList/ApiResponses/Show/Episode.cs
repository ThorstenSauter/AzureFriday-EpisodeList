namespace AzureFriday.EpisodeList.ApiResponses.Show;

public class Episode
{
    public Guid EntryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Url { get; set; } = null!;
}