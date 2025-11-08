using Microsoft.EntityFrameworkCore;
using Social_Media_Web_API.Data;
using Social_Media_Web_API.Repositories.Implementation;
using Social_Media_Web_API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// DB: SQLite عشان Render Free + Flutter
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=SocialMediaDB.db")
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

app.UseCors("AllowFlutter");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
