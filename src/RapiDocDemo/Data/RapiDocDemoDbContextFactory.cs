using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RapiDocDemo.Data;

public class RapiDocDemoDbContextFactory : IDesignTimeDbContextFactory<RapiDocDemoDbContext>
{
    public RapiDocDemoDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<RapiDocDemoDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new RapiDocDemoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
