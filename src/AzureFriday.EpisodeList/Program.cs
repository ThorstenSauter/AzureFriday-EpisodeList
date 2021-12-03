using AzureFriday.EpisodeList.Clients;
using AzureFriday.EpisodeList.Extensions;
using Refit;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services
    .AddRefitClient<IShowClient>()
    .ConfigureHttpClient(client => client.BaseAddress = new(IShowClient.BaseUri));

services
    .AddRefitClient<IVideoClient>()
    .ConfigureHttpClient(client => client.BaseAddress = new(IVideoClient.BaseUri));

var app = builder.Build();

app.MapGet("/", async (IShowClient showClient, IVideoClient episodeClient) =>
{
    var episodes = await showClient.GetAllEpisodesAsync();
    return await episodeClient.GetVideoDataForEpisodesAsync(episodes);
});

app.UseRouting();

app.Run();