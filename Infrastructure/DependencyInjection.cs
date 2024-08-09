using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDatabase(configuration);
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

 
}
