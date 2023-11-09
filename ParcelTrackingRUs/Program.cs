
using ParcelTrackingRUs.Model;
using ParcelTrackingRUs.Repository;

namespace ParcelTrackingRUs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);    

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<RestDatabaseSettings>(builder.Configuration.GetSection(nameof(RestDatabaseSettings)));
            builder.Services.AddSingleton<IPackageRepository, PackageRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapPost("/package", (Package std, IPackageRepository sr) =>
            {
                sr.Add(std);
            });
            app.MapGet("/package/{id}", (Guid std, IPackageRepository sr) =>
            {

                return sr.Get(std);
            });

            app.Run();
        }
    }
}