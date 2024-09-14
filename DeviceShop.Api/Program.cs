
using DeviceShop.Application;
using DeviceShop.Persistance;
using Microsoft.AspNetCore.RateLimiting;

namespace DeviceShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddPersistence(builder.Configuration).AddApplication();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRateLimiter(RateLimiterOptions =>
            {
                RateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                RateLimiterOptions.AddSlidingWindowLimiter("sliding", options =>
                {
                    options.Window = TimeSpan.FromSeconds(30);
                    options.SegmentsPerWindow = 20;
                    options.PermitLimit = 20;
                });
            });
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRateLimiter();

            app.MapControllers();

            app.Run();
        }
    }
}
