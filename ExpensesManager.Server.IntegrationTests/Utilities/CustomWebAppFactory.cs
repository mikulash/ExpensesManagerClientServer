using System.Data.Common;
using ExpensesManager.Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Server.IntegrationTests.Utilities;

// ReSharper disable once ClassNeverInstantiated.Global
public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    private DbConnection? _connection;

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            if (dbContextDescriptor != null) services.Remove(dbContextDescriptor);

            var dbConnectionDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbConnection));
            if (dbConnectionDescriptor != null) services.Remove(dbConnectionDescriptor);

            services.AddSingleton<DbConnection>(_ =>
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();
                return _connection;
            });

            services.AddDbContext<ApplicationDbContext>((container, options) =>
            {
                var connection = container.GetRequiredService<DbConnection>();
                options.UseSqlite(connection);
            });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();

            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();
            db.Database.EnsureCreated();

            var userManager = scopedServices.GetRequiredService<UserManager<IdentityUser>>();
            DbSeeder.Seed(db, userManager);
        });

        builder.UseEnvironment("Development");

        return base.CreateHost(builder);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing) _connection?.Dispose();
    }

    public async Task ResetDatabaseAsync()
    {
        using var scope = Services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var db = scopedServices.GetRequiredService<ApplicationDbContext>();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
    }
}
