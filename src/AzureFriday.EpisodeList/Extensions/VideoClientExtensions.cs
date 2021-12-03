using AzureFriday.EpisodeList.ApiResponses.Show;
using AzureFriday.EpisodeList.Clients;
using AzureFriday.EpisodeList.Models;

namespace AzureFriday.EpisodeList.Extensions;

public static class VideoClientExtensions
{
    public static async Task<IEnumerable<AzureFridayEpisode>> GetVideoDataForEpisodesAsync(this IVideoClient videoClient,
        IReadOnlyDictionary<Guid, Episode> episodes)
    {
        var result = new List<AzureFridayEpisode>();
        var getEntriesTasks = episodes.Keys
            .Chunk(IVideoClient.MaxBatchSize)
            .Select(videoClient.GetVideoData)
            .ToArray();

        var entries = await Task.WhenAll(getEntriesTasks);
        foreach (var videoEntries in entries)
        {
            result.AddRange(videoEntries.Select(entryData => new AzureFridayEpisode(episodes[entryData.Entry.Id], entryData)));
        }

        return result;
    }
}