using CorePlugin.Plugin.Hubs;
using CorePlugin.Plugin.Hubs.HubInterfaces.SampleHubInterfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace CorePlugin.Plugin.Services;

#warning This is just a sample. Replace it with your own.
public class RandomMessageBackgroundService : BackgroundService
{
    private readonly IHubContext<SampleHub, ISampleServerToClient> _sampleSignalRHub;

    public RandomMessageBackgroundService(IHubContext<SampleHub, ISampleServerToClient> sampleSignalRHub)
        => _sampleSignalRHub = sampleSignalRHub;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() =>
        {
            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = $"Random message {i++}";
                _sampleSignalRHub.Clients.All.SendRandomMessage(message);
                Thread.Sleep(1000);
            }
        }, stoppingToken);
    }
}
