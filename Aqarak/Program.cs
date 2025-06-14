
using AqarakCore.IRepository;
using AqarakRepository.Data;
using AqarakRepository.Data.Repository;
using Microsoft.EntityFrameworkCore;

using AqarakCore.IRepository;
using AqarakRepository.Data;
using AqarakRepository.Data.Repository;
using Microsoft.EntityFrameworkCore;
using AqarakRepository.Identity;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;
using AqarakCore.IdentityEnities;
using AqarakCore.Iservice;
using AqarakService.Auth;
using Aqarak.Helper;
using Microsoft.Extensions.FileProviders;

namespace Aqarak
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<APPUserIdentityDbcontext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
            builder.Services.AddScoped(typeof(IGenericRepoitory<>), typeof(GenericRepository<>));
            builder.Services.AddIdentity<AppUserIdentity, IdentityRole>(optian =>
            {

            }
            ).AddEntityFrameworkStores<APPUserIdentityDbcontext>();
            builder.Services.AddScoped(typeof(ICreateToken), typeof(TokenService));
            builder.Services.AddControllers();

           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(profilesMaper).Assembly);


            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dbcontex = services.GetRequiredService<StoreContext>();
            var _dbcontexidentity = services.GetRequiredService<APPUserIdentityDbcontext>();


           // var logger = loggerFactory.CreateLogger<Program>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await _dbcontex.Database.MigrateAsync();
                await _dbcontexidentity.Database.MigrateAsync();
                
                await DataSeeding.DataSeed(_dbcontex);
                var user = services.GetRequiredService<UserManager<AppUserIdentity>>();
                await ApplicationUserSeeding.UserSeeding(user);


            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred during migration or data seeding.");

            }


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(); 
            }
            app.UseStaticFiles(); 

            
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/images",  
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(builder.Environment.WebRootPath, "images"))
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

