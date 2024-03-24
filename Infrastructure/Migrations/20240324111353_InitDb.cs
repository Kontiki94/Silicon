using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsBestSeller = table.Column<bool>(type: "bit", nullable: false),
                    CourseImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseImageAltText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reviews = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Views = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikesInPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikesInNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutherBio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutherImageAltText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTubeSubscribers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceBookFollowers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Articles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearnPoints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSubscribed = table.Column<bool>(type: "bit", nullable: false),
                    DailyNewsLetter = table.Column<bool>(type: "bit", nullable: false),
                    AdvertisingUpdates = table.Column<bool>(type: "bit", nullable: false),
                    WeekInReviews = table.Column<bool>(type: "bit", nullable: false),
                    EventUpdates = table.Column<bool>(type: "bit", nullable: false),
                    StartupsWeekly = table.Column<bool>(type: "bit", nullable: false),
                    Podcasts = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribe", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Subscribe");
        }
    }
}
