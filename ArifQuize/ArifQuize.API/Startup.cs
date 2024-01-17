using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using ArifQuize.API.Repositories; // Add this line


public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

  public void ConfigureServices(IServiceCollection services)
{
    var connectionString = Configuration.GetConnectionString("MongoDB:ConnectionString");
    var client = new MongoClient(connectionString);
    var databaseName = Configuration["MongoDB:DatabaseName"];
    var database = client.GetDatabase(databaseName);

    services.AddSingleton<IMongoClient>(client);
    services.AddSingleton<IMongoDatabase>(database);

    services.AddTransient<QuizRepository>();

    services.AddControllers();
}

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
