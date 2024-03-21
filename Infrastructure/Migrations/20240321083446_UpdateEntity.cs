using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Courses",
                newName: "YouTubeSubscribers");

            migrationBuilder.AddColumn<string>(
                name: "AccessTime",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Articles",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutherBio",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorImage",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseDescription",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaceBookFollowers",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBestSeller",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LearnPoints",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikesInNumbers",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikesInPercent",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramDetails",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resources",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessTime",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Articles",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AutherBio",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AuthorImage",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseDescription",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "FaceBookFollowers",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsBestSeller",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LearnPoints",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LikesInNumbers",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LikesInPercent",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ProgramDetails",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Resources",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "YouTubeSubscribers",
                table: "Courses",
                newName: "Likes");
        }
    }
}
