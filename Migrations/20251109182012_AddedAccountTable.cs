using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Social_Media_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Email", "Icon", "UserName" },
                values: new object[,]
                {
                    { 1, "idont care", "sewedy@example.com", "psychology", "Sewedy" },
                    { 2, "Flutter Eng wants an offer 😑", "aya@example.com", "emoji_events", "Aya" },
                    { 3, "Pretty, huh? 🎨", "asia@example.com", "brush", "Asia" },
                    { 4, "Backend dev, send help ☕", "ashraqat@example.com", "explore", "Ashraqat" },
                    { 5, "AI guy, robots > humans 🤖", "mostafa@example.com", "smart_toy", "Mostafa" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "يا جماعة حد فاهم async await ده بيستنى ولا بيزوّغ؟ 😂", new DateTime(2025, 11, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Just pushed to GitHub... and broke everything 💀", new DateTime(2025, 11, 1, 12, 45, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "النت وقع وقت الـ migration، حسّيت إني فقدت روحي 😭", new DateTime(2025, 11, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "Coffee ☕ + Code = Happiness 💻❤️", new DateTime(2025, 11, 2, 16, 20, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "النهارده قررت أكتب clean code... بعد أول bug رجعت عادي 😅", new DateTime(2025, 11, 3, 9, 5, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, "When you fix one bug and create three new ones 🤡", new DateTime(2025, 11, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, "مش عارف ليه كل ما أقول خلاص المشروع خلص، Visual Studio يضحك 😭", new DateTime(2025, 11, 4, 11, 10, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "Flutter build time be like: go make a sandwich 😂", new DateTime(2025, 11, 4, 14, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, "الـ API شغالة تمام، بس الكلاينت بيقول مش شغالة 🤨", new DateTime(2025, 11, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, "life update: still debugging 🐛", new DateTime(2025, 11, 6, 20, 15, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
