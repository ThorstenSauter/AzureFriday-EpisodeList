using System.Text.Json.Serialization;

namespace AzureFriday.EpisodeList.ApiResponses.Video;

public class Thumbnail
{
    [JsonPropertyName("w800Url")]
    public string SmallerThumbnailUri { get; set; } = null!;

    [JsonPropertyName("w1120Url")]
    public string LargerThumbnailUri { get; set; } = null!;
}