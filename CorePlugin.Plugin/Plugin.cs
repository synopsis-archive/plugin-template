using Core.Plugin.Interface;
using CorePlugin.Plugin.Hubs;
using CorePlugin.Plugin.Services;
using CorePlugin.SampleDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CorePlugin.Plugin;

public class Plugin : ICorePlugin
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        //TODO: Add your own services here (e.g. database context, services, etc.)
        builder.Services.AddControllers();
        //TODO: The lines below are sample SignalR services. You can remove them if you want.
        builder.Services.AddSignalR();
        builder.Services.AddHostedService<RandomMessageBackgroundService>();

        // TODO: If you're using a database context, it should be added like this:
        // TODO: Change "SampleConnectionString" to the your preferred connection string in appsettings.json
        // TODO: It can be found at CorePlugin.BackendDevServer\appsettings.json
        builder.Services.AddDbContext<SampleDbContext>(db =>
        {
            var connectionString = builder.Configuration.GetConnectionStringThatAlsoWorksInProduction("SampleConnectionString", builder.Environment.IsDevelopment());
            if (builder.Environment.IsDevelopment())
            {
                db.UseSqlite(connectionString);
            }
            else
            {
                db.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        });
        builder.Services.AddTransient<SampleDbService>();
    }

    public void Configure(WebApplication app)
    {
        //TODO: Add your own middleware here (e.g. SignalR, etc.)
        //TODO: If you're not using SignalR, you can remove the line below
        app.MapHub<SampleHub>("hubs/sample");
        app.MapControllers();
    }
}
