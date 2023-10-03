using Application;
using Persistence;
using Shared;
using SysacadWebAPI.Extensions;

namespace SysacadWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            ApplicationServiceExtensions.AddApplicationLayer(builder.Services);
            PersistenceServiceExtensions.AddPersistenceInfrastructure(builder.Services, builder.Configuration);
            SharedServiceExtensions.AddSharedInfraestructure(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            AppExtensions.UseErrorHandlerMiddleware(app);


            app.MapControllers();

            app.Run();
        }
    }
}