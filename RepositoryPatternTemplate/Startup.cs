using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NReco.Logging.File;
using RepositoryPatternTemplate.Context;
using RepositoryPatternTemplate.Repository;
using RepositoryPatternTemplate.Services;

namespace RepositoryPatternTemplate;

/// <summary>
///     The Startup class is responsible for configuring the application's services.
/// </summary>
internal class Startup
{
    /// <summary>
    ///     This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    public IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        // Add logging services to the ServiceCollection
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddFile("app.log");
        });

        // Register interfaces and their concrete implementations
        services.AddTransient<IMainService, MainService>();
        services.AddTransient<IMovieContext, MovieContext>();

        // Alternative way to register FileMovieRepository with a specific file path
        //services.AddTransient<IMovieRepository, FileMovieRepository>();
        services.AddTransient<IMovieRepository>(serviceProvider => new FileMovieRepository("Files/movies.json"));


        return services.BuildServiceProvider();
    }
}
