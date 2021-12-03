using System.Text.Json.Serialization;

namespace AzureFriday.EpisodeList.ApiResponses.Video;

public class Entry
{
    public Guid Id { get; set; }

    public Video PublicVideo { get; set; } = null!;

    [JsonPropertyName("youTubeUrl")]
    public string YoutubeUri { get; set; } = null!;
}