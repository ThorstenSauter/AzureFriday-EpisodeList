using AzureFriday.EpisodeList.ApiResponses.Show;
using Refit;

namespace AzureFriday.EpisodeList.Clients;

public interface IShowClient
{
    const string BaseUri = "https://docs.microsoft.com/api/hierarchy/shows/azure-friday";
    const int MaxPageSize = 30;

    [Get("/episodes?page={pageNumber}&pageSize={pageSize}&orderBy=uploaddate desc")]
    Task<EpisodePage> GetEpisodesForPage(int pageNumber, int pageSize = 30);
}