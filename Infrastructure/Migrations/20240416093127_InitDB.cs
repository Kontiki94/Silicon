using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutherBio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutherImageAltText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTubeSubscribers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceBookFollowers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowcaseImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Articles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramDetailsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramDetailsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearnPoints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Web Development" },
                    { 2, "HTML & CSS" },
                    { 3, "Python" },
                    { 4, "Game Development" },
                    { 5, "App Development" },
                    { 6, "Frontend Development" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AccessTime", "Articles", "AutherBio", "AutherImageAltText", "AuthorImage", "AuthorName", "CategoryId", "CourseDescription", "CourseImage", "CourseImageAltText", "Created", "DiscountPrice", "FaceBookFollowers", "IsBestSeller", "LearnPoints", "LikesInNumbers", "LikesInPercent", "Price", "ProgramDetailsText", "ProgramDetailsTitle", "Rating", "Resources", "Reviews", "ShowcaseImage", "Title", "Updated", "ViewHours", "Views", "YouTubeSubscribers" },
                values: new object[,]
                {
                    { 1, "Full lifetime access", "18", "Dolor ipsum amet cursus quisque porta adipiscing. Lorem convallis malesuada sed maecenas. Ac dui at vitae mauris cursus in nullam porta sem. Quis pellentesque elementum ac bibendum. Nunc aliquam in tortor facilisis. Vulputate eget risus, metus phasellus. Pellentesque faucibus amet, eleifend diam quam condimentum convallis ultricies placerat. Duis habitasse placerat amet, odio pellentesque rhoncus, feugiat at. Eget pellentesque tristique felis magna fringilla.", "Albert Flores image", "albert-flores.svg", "Robert Fox", 1, "Suspendisse natoque sagittis, consequat turpis. Sed tristique tellus morbi magna. At vel senectus accumsan, arcu mattis id tempor. Tellus sagittis, euismod porttitor sed tortor est id. Feugiat velit velit, tortor ut. Ut libero cursus nibh lorem urna amet tristique leo. Viverra lorem arcu nam nunc at ipsum quam. A proin id sagittis dignissim mauris condimentum ornare. Tempus mauris sed dictum ultrices.", "course_one.svg", "course one", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1163), null, "240", true, "[\"Sed lectus donec amet eu turpis interdum.\",\"Nulla at consectetur vitae dignissim porttitor.\",\"Phasellus id vitae dui aliquet mi.\",\"Integer cursus vitae, odio feugiat iaculis aliquet diam, et purus.\",\"In aenean dolor diam tortor orci eu.\"]", "4.2", "94", "12.50", "[\"Nulla faucibus mauris pellentesque blandit faucibus non. Sit ut et at suspendisse gravida hendrerit tempus placerat.\",\"Lobortis diam elit id nibh ultrices sed penatibus donec. Nibh iaculis eu sit cras ultricies. Nam eu eget etiam egestas donec scelerisque ut ac enim. Vitae ac nisl, enim nec accumsan vitae est.\",\"Duis euismod enim, facilisis risus tellus pharetra lectus diam neque. Nec ultrices mi faucibus est. Magna ullamcorper potenti elementum ultricies auctor nec volutpat augue.\",\"Morbi porttitor risus imperdiet a, nisl mattis. Amet, faucibus eget in platea vitae, velit, erat eget velit. At lacus ut proin erat.\",\"Risus morbi euismod in congue scelerisque fusce pellentesque diam consequat. Nisi mauris nibh sed est morbi amet arcu urna. Malesuada feugiat quisque consectetur elementum diam vitae. Dictumst facilisis odio eu quis maecenas risus odio fames bibendum.\",\"Quis risus quisque diam diam. Volutpat neque eget eu faucibus sed urna fermentum risus. Est, mauris morbi nibh massa.\"]", "[\"Introduction. Getting started\",\"The ultimate HTML developer: advanced HTML\",\"CSS \\u0026 CSS3: basic\",\"JavaScript basics for beginners\",\"Understanding APIs\",\"C# and .NET from beginner to advanced\"]", null, "25", "1.2", "showcase_image_1.svg", "Fullstack Web Developer Course from Scratch", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1168), "220", null, "180" },
                    { 2, null, null, null, null, null, "Jenny Wilson & Marvin McKinney", 2, null, "course_two.svg", "course two", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1188), null, null, false, null, "3.1", "92", "15.99", null, null, null, null, null, null, "HTML, CSS, JavaScript Web Developer", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1189), "160", null, null },
                    { 3, null, null, null, null, null, "Albert Flores", 6, null, "course_three.svg", "course three", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1191), "9.99", null, false, null, "2.7", "98", "44.99", null, null, null, null, null, null, "The Complete Front-End Web Development Course", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1191), "100", null, null },
                    { 4, null, null, null, null, null, "Marvin McKinney", 5, null, "course_four.svg", "course four", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1193), null, null, false, null, "3.1", "92", "15.99", null, null, null, null, null, null, "iOS & Swift - The Complete iOS App Development Course", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1193), "220", null, null },
                    { 5, null, null, null, null, null, "Esther Howard", 3, null, "course_five.svg", "course five", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1195), null, null, true, null, "4.2", "94", "12.50", null, null, null, null, null, null, "Data Science & Machine Learning with Python", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1195), "220", null, null },
                    { 6, null, null, null, null, null, "Robert Fox", 2, null, "course_six.svg", "course six", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1197), null, null, false, null, "4.2", "94", "10.50", null, null, null, null, null, null, "Creative CSS Drawing Course: Make Art With CSS", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1197), "220", null, null },
                    { 7, null, null, null, null, null, "Ralph Edwards", 4, null, "course_seven.svg", "course seven", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1199), null, null, false, null, "3.1", "92", "18.99", null, null, null, null, null, null, "Blender Character Creator v2.0 for Video Games Design", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1200), "160", null, null },
                    { 8, null, null, null, null, null, "Albert Flores", 4, null, "course_eight.svg", "course eight", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1201), "12.99", null, false, null, "2.7", "98", "44.99", null, null, null, null, null, null, "The Ultimate Guide to 2D Mobile Game Development with Unity", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1201), "100", null, null },
                    { 9, null, null, null, null, null, "Jenny Wilson", 5, null, "course_nine.svg", "course nine", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1203), null, null, false, null, "3.1", "92", "14.50", null, null, null, null, null, null, "Learn JMETER from Scratch on Live Apps-Performance Testing", new DateTime(2024, 4, 16, 9, 31, 27, 192, DateTimeKind.Utc).AddTicks(1203), "160", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");
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

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
