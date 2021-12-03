namespace AzureFriday.EpisodeList.ApiResponses.Show;

public class EpisodePage
{
    public int TotalCount { get; set; }
    public List<Episode> Episodes { get; set; } = null!;
}