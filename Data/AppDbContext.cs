using Microsoft.EntityFrameworkCore;
using Social_Media_Web_API.Models;

namespace Social_Media_Web_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Account>()
    .HasOne(a => a.User)
    .WithOne(u => u.Account)
    .HasForeignKey<User>(u => u.AccountId);


            modelBuilder.Entity<Account>().HasData(
    new Account { Id = 1, Email = "sewedy@example.com", Password = "123456" },
    new Account { Id = 2, Email = "aya@example.com", Password = "flutter123" },
    new Account { Id = 3, Email = "asia@example.com", Password = "artlover" },
    new Account { Id = 4, Email = "ashraqat@example.com", Password = "backendqueen" },
    new Account { Id = 5, Email = "mostafa@example.com", Password = "aiguy2025" }
);


            modelBuilder.Entity<User>().HasData(
      new User { Id = 1, UserName = "Sewedy", Email = "sewedy@example.com", Bio = "idont care", Icon = "psychology", AccountId = 1 },
      new User { Id = 2, UserName = "Aya", Email = "aya@example.com", Bio = "Flutter Eng wants an offer 😑", Icon = "emoji_events", AccountId = 2 },
      new User { Id = 3, UserName = "Asia", Email = "asia@example.com", Bio = "Pretty, huh? 🎨", Icon = "brush", AccountId = 3 },
      new User { Id = 4, UserName = "Ashraqat", Email = "ashraqat@example.com", Bio = "Backend dev, send help ☕", Icon = "explore", AccountId = 4 },
      new User { Id = 5, UserName = "Mostafa", Email = "mostafa@example.com", Bio = "AI guy, robots > humans 🤖", Icon = "smart_toy", AccountId = 5 }
  );



            modelBuilder.Entity<Post>().HasData(
       new Post { Id = 1, Content = "يا جماعة حد فاهم async await ده بيستنى ولا بيزوّغ؟ 😂", CreatedAt = new DateTime(2025, 11, 1, 10, 15, 0), UserId = 1 },
       new Post { Id = 2, Content = "Just pushed to GitHub... and broke everything 💀", CreatedAt = new DateTime(2025, 11, 1, 12, 45, 0), UserId = 2 },
       new Post { Id = 3, Content = "النت وقع وقت الـ migration، حسّيت إني فقدت روحي 😭", CreatedAt = new DateTime(2025, 11, 2, 8, 30, 0), UserId = 3 },
       new Post { Id = 4, Content = "Coffee ☕ + Code = Happiness 💻❤️", CreatedAt = new DateTime(2025, 11, 2, 16, 20, 0), UserId = 1 },
       new Post { Id = 5, Content = "النهارده قررت أكتب clean code... بعد أول bug رجعت عادي 😅", CreatedAt = new DateTime(2025, 11, 3, 9, 5, 0), UserId = 2 },
       new Post { Id = 6, Content = "When you fix one bug and create three new ones 🤡", CreatedAt = new DateTime(2025, 11, 3, 18, 45, 0), UserId = 3 },
       new Post { Id = 7, Content = "مش عارف ليه كل ما أقول خلاص المشروع خلص، Visual Studio يضحك 😭", CreatedAt = new DateTime(2025, 11, 4, 11, 10, 0), UserId = 1 },
       new Post { Id = 8, Content = "Flutter build time be like: go make a sandwich 😂", CreatedAt = new DateTime(2025, 11, 4, 14, 30, 0), UserId = 2 },
       new Post { Id = 9, Content = "الـ API شغالة تمام، بس الكلاينت بيقول مش شغالة 🤨", CreatedAt = new DateTime(2025, 11, 5, 19, 0, 0), UserId = 3 },
       new Post { Id = 10, Content = "life update: still debugging 🐛", CreatedAt = new DateTime(2025, 11, 6, 20, 15, 0), UserId = 1 }
   );








        }
    }


}
