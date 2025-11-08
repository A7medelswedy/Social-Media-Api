using Microsoft.EntityFrameworkCore;
using Social_Media_Web_API.Data;
using Social_Media_Web_API.Repositories.Implementation;
using Social_Media_Web_API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// SQLite Database
var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "SocialMediaDB.db");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}")
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

// اعمل Database تلقائي
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseCors("AllowFlutter");

// Swagger في Production كمان
app.UseSwagger();
app.UseSwaggerUI();

// اقرأ الـ Port من Railway
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Clear();
app.Urls.Add($"http://0.0.0.0:{port}");

app.UseAuthorization();
app.MapControllers();

app.Run();
