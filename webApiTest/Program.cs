using webApiTest.Controllers;


public class Program
{
    public static void Main(string[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddWebAPIDependencies()
            .AddCustomDI();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}

public static class ServiceCollectionExtensions 
{

    public static IServiceCollection AddWebAPIDependencies(this IServiceCollection service) 
    {
        // Add services to the container.

        service.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen();

        return service;
    }

    public static IServiceCollection AddCustomDI(this IServiceCollection service) 
    {
        
        // Singleton because for some reason, 
        // [Controller].[HttpPost] and [Controller].[HttpGet] are different instances; they have different hash codes on their dependencies
        service.AddSingleton<IJobDefinitionRepository, DefaultJobDefinitionRepository>();
        
        return service;
    }
}