using AzureFriday.EpisodeList.ApiResponses.Show;
using AzureFriday.EpisodeList.ApiResponses.Video;

namespace AzureFriday.EpisodeList.Models;

public class AzureFridayEpisode
{
    public AzureFridayEpisode(Episode episode, VideoEntry videoEntry)
    {
        Id = episode.EntryId;
        Title = episode.Title;
        Description = episode.Description;
        ShowUri = episode.Url;
        ThumbNailUri = videoEntry.Entry.PublicVideo.ThumbNail.LargerThumbnailUri;
        YoutubeUri = videoEntry.Entry.YoutubeUri;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ShowUri { get; set; }
    public string ThumbNailUri { get; set; }
    public string YoutubeUri { get; set; }
}