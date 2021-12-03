using AzureFriday.EpisodeList.ApiResponses.Show;
using AzureFriday.EpisodeList.Clients;

namespace AzureFriday.EpisodeList.Extensions;

public static class ShowClientExtensions
{
    public static async Task<IReadOnlyDictionary<Guid, Episode>> GetAllEpisodesAsync(this IShowClient showClient)
    {
        var totalEpisodeCount = await GetTotalEpisodeCount(showClient);
        var numberOfPages = GetNumberOfPages(totalEpisodeCount);
        var getEpisodePageTasks = Enumerable.Range(0, numberOfPages)
            .Select(pageNumber => showClient.GetEpisodesForPage(pageNumber))
            .ToArray();

        var pages = await Task.WhenAll(getEpisodePageTasks);
        return pages
            .SelectMany(x => x.Episodes)
            .ToDictionary(e => e.EntryId, e => e);
    }

    private static async Task<int> GetTotalEpisodeCount(IShowClient showClient) =>
        (await showClient.GetEpisodesForPage(0, 1)).TotalCount;

    private static int GetNumberOfPages(int totalEpisodeCount)
    {
        var pages = totalEpisodeCount / IShowClient.MaxPageSize;
        return totalEpisodeCount % IShowClient.MaxPageSize == 0 ? pages : pages + 1;
    }
}