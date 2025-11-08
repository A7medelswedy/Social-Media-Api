using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Social_Media_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    { 1, "Backend Wizard 🧙‍♂️", "ahmed@example.com", "🐱", "Ahmed" },
                    { 2, "Flutter Queen 👑", "mona@example.com", "🦋", "Mona" },
                    { 3, "UI/UX Artist 🎨", "omar@example.com", "🦸‍♂️", "Omar" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "يا جماعة حد فاهم async await ده بيستنى ولا بيزوّغ؟ 😂", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(7733), 1 },
                    { 2, "Just pushed to GitHub... and broke everything 💀", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(8216), 2 },
                    { 3, "النت وقع وقت الـ migration، حسّيت إني فقدت روحي 😭", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(8218), 3 },
                    { 4, "Coffee ☕ + Code = Happiness 💻❤️", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(8221), 1 },
                    { 5, "النهارده قررت أكتب clean code... بعد أول bug رجعت عادي 😅", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(8224), 2 },
                    { 6, "When you fix one bug and create three new ones 🤡", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(8226), 3 },
                    { 7, "مش عارف ليه كل ما أقول خلاص المشروع خلص، Visual Studio يضحك 😭", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(8229), 1 },
                    { 8, "Flutter build time be like: go make a sandwich 😂", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(8231), 2 },
                    { 9, "الـ API شغالة تمام، بس الكلاينت بيقول مش شغالة 🤨", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(8234), 3 },
                    { 10, "life update: still debugging 🐛", new DateTime(2025, 11, 7, 8, 38, 56, 166, DateTimeKind.Local).AddTicks(8237), 1 }
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
