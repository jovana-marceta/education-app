
using EducationApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region ServiceConfiguration
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // DB configuration
            builder.Services.AddDbContextPool<EducationAppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DbContext"),
                    provideroptons => provideroptons.EnableRetryOnFailure());
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #endregion

            #region Middlewares
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion Middlewares
        }
    }
}
