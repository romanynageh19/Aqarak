
using AqarakCore.IRepository;
using AqarakRepository.Data;
using AqarakRepository.Data.Repository;
using Microsoft.EntityFrameworkCore;

using AqarakCore.IRepository;
using AqarakRepository.Data;
using AqarakRepository.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Aqarak
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IGenericRepoitory<>), typeof(GenericRepository<>));

            builder.Services.AddControllers();

           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
}

