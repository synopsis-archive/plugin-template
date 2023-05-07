using CorePlugin.Plugin.Hubs.HubInterfaces.SampleHubInterfaces;
using Microsoft.AspNetCore.SignalR;

namespace CorePlugin.Plugin.Hubs;

#warning This is just a sample. Replace it with your own.
public class SampleHub : Hub<ISampleServerToClient>, ISampleClientToServer
{
    public Task<string> Ping() => Task.FromResult("Pong!");
}
