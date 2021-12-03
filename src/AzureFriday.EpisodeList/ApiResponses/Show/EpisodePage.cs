namespace AzureFriday.EpisodeList.ApiResponses.Show;

public class EpisodePage
{
    public int TotalCount { get; set; }
    public IEnumerable<Episode> Episodes { get; set; } = null!;
}