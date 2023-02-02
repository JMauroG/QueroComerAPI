using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using QueroComer.Data;
using QueroComer.Mock;
using QueroComer.Mock.Entidades;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;

namespace QueroComer.IntegrationTest
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(x => 
                    x.ServiceType == typeof(DbContextOptions<AppDbContext>)
                );

                services.Remove(dbContextDescriptor!);

                var dbConnectionDescriptor = services.SingleOrDefault(x =>
                    x.ServiceType == typeof(DbConnection)
                );

                services.Remove(dbConnectionDescriptor!);

                var swaggerDescriptor = services.SingleOrDefault(x =>
                    x.ServiceType == typeof(SwaggerGenOptions)
                );

                services.Remove(swaggerDescriptor!);

                services.AddSingleton<DbConnection>(container =>
                {
                    var connection = new SqliteConnection($"DataSource=file::memory:?cache=shared");
                    connection.Open();
                    return connection;
                });

                services.AddDbContext<AppDbContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection);
                });

                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var appDb = scopedServices.GetRequiredService<AppDbContext>();
                    // Ensure the database is created.
                    appDb.Database.EnsureCreated();

                    try
                    {
                        DataSeed.Seed(appDb);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                };
            });
        }
    }
}
