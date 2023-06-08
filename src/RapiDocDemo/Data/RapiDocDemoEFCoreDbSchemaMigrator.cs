using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace RapiDocDemo.Data;

public class RapiDocDemoEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public RapiDocDemoEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the RapiDocDemoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<RapiDocDemoDbContext>()
            .Database
            .MigrateAsync();
    }
}
