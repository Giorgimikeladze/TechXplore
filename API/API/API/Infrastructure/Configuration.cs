


using System.Reflection;
using System.Text;
using Asp.Versioning;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.ItAcademy.Ge.Infrastructure.Configurations
{
    public static class Configuration
    {
        public static void ConfigureAPI(this IServiceCollection services,IConfiguration configuration) {


            #region Swagger

            services.AddSwaggerExamplesFromAssemblyOf<Program>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Forum",
                    Version = "v1",
                    Description = "Forum API",
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Forum",
                    Version = "v2",
                    Description = "Forum API",
                });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                ////upload picture
                //options.OperationFilter<AddFileUploadParamsOperationFilter>();
                ////
                options.IncludeXmlComments(xmlPath);
                options.ExampleFilters();
            });


            #endregion
            #region JWTTokenConfigurations

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                   .GetBytes(configuration.GetSection("JWTSecretKey:Key").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.Configure<JwtSettings>(
             configuration.GetSection(JwtSettings.Section)
            );
            #endregion

            


        }
    }
}
