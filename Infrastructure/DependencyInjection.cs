using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDatabase(configuration);
        services.AddRepositories();
        services.AddServices();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) //this, le da una funcionalidad extra 
    {

        var connectionString = configuration.GetConnectionString("BookStore"); //se dispone la cadena de conexion 

        services.AddDbContext<DataBaseContext>(options =>
        {
            options.UseNpgsql(connectionString);  //se linkea el contexto con la bsssd 
        });
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services) //this, le da una funcionalidad extra 
    {
        services.AddScoped<IBookRepository, BookRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services) //this, le da una funcionalidad extra 
    {
        services.AddScoped<IBookService, BookService>();
        return services;
    }


}
