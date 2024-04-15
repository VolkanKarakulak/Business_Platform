using Business_Platform.Data;
using Business_Platform.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Business_PlatformContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Business_PlatformContext") ?? throw new InvalidOperationException("Connection string 'Business_PlatformContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<Business_PlatformContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("WatchMeContext") ?? throw new InvalidOperationException("Connection string 'WatchMeContext' not found.")));

            builder.Services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false).AddDefaultTokenProviders()
                .AddEntityFrameworkStores<Business_PlatformContext>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
