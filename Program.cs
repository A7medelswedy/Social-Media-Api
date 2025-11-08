using Microsoft.EntityFrameworkCore;
using Social_Media_Web_API.Data;
using Social_Media_Web_API.Repositories.Implementation;
using Social_Media_Web_API.Repositories.Interfaces;

namespace Social_Media_Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Use connection string from environment variable "con"
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("con"))
            );

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFlutter",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });

            var app = builder.Build();

            // Use CORS
            app.UseCors("AllowFlutter");

            // Swagger visible to everyone
            app.UseSwagger();
            app.UseSwaggerUI();

            // Optional: comment this line if HTTPS causes issues on Render
            // app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
