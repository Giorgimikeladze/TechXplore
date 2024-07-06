using API.Infrastructure.Middlewares;
using Application.Services;
using Forum.ItAcademy.Ge.Infrastructure.Configurations;
using Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();


        builder.Services.ConfigureAPI(builder.Configuration);
        builder.Services.InjectRepositories(builder.Configuration);
        builder.Services.InjectServices();



      
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization(); ;
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        app.MapControllers();

        app.Run();
    }
}

#region JWTTokenConfigurations

#endregion
