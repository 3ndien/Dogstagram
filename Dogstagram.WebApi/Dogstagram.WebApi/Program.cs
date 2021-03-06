namespace Dogstagram.WebApi
{
    using Dogstagram.WebApi.Infrastructures.Extensions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddDatabaseService(builder.Configuration)
            .AddIdentityService()
            .AddApplicationServices(builder.Services.GetStorageConnectionString(builder.Configuration))
            .AddSwaggerGen()
            .AddCors()
            .AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration))
            .AddAutoMapper(typeof(Program))
            .AddApiControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerMidleware();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

            app.Run();
        }
    }

}