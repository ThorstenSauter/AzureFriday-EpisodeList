using AzureFriday.EpisodeList.ApiResponses.Video;
using Refit;

namespace AzureFriday.EpisodeList.Clients;

public interface IVideoClient
{
    const string BaseUri = "https://docs.microsoft.com/api/video/public/v1";
    const int MaxBatchSize = 52;

    [Get("/entries/batch")]
    Task<ApiResponse<IEnumerable<VideoEntry>>> GetVideoData([Query(CollectionFormat.Csv)] IEnumerable<Guid> ids);
}