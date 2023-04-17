using Core.Plugin.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CorePlugin.Plugin;

public class Plugin : ICorePlugin
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        //TODO: Add your own services here (e.g. database context, services, etc.)
        builder.Services.AddControllers();
    }

    public void Configure(WebApplication app)
    {
        //TODO: Eventually add your own middleware here (e.g. SignalR, etc.)
        app.MapControllers();
    }
}
