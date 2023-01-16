using Core.Plugin.Interface;
using Microsoft.AspNetCore.Builder;

namespace CorePlugin.Plugin;

public class Plugin : ICorePlugin
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        throw new NotImplementedException();
    }

    public void Configure(WebApplication app)
    {
        throw new NotImplementedException();
    }
}
