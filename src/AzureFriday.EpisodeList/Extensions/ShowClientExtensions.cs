using AzureFriday.EpisodeList.ApiResponses.Show;
using AzureFriday.EpisodeList.Clients;
using Refit;

namespace AzureFriday.EpisodeList.Extensions;

public static class ShowClientExtensions
{
    public static async Task<IReadOnlyDictionary<Guid, Episode>> GetAllEpisodesAsync(this IShowClient showClient)
    {
        var totalEpisodeCount = (await showClient.GetEpisodesForPage(0, 1)).Content?.TotalCount ?? throw new("Could not retrieve episode count");
        var episodes = new Dictionary<Guid, Episode>();
        var maxPageNumber = GetMaxPageNumber(totalEpisodeCount);

        var getEpisodePageTasks = new List<Task<ApiResponse<EpisodePage>>>();

        for (var i = 0; i <= maxPageNumber; i++)
        {
            getEpisodePageTasks.Add(showClient.GetEpisodesForPage(i));
        }

        var pages = await Task.WhenAll(getEpisodePageTasks);
        foreach (var page in pages)
        {
            foreach (var episode in page.Content!.Episodes)
            {
                episodes[episode.EntryId] = episode;
            }
        }

        return episodes;
    }

    private static int GetMaxPageNumber(int totalEpisodeCount)
    {
        var pages = totalEpisodeCount / IShowClient.MaxPageSize;
        return totalEpisodeCount % IShowClient.MaxPageSize == 0 ? pages - 1 : pages;
    }
}