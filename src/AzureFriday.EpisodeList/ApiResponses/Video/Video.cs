using System.Text.Json.Serialization;

namespace AzureFriday.EpisodeList.ApiResponses.Video;

public class Video
{
    [JsonPropertyName("thumbnailOtherSizes")]
    public Thumbnail ThumbNail { get; set; } = null!;
}