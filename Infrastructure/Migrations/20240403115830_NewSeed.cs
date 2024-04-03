using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7509), null, new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7510) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7539), null, new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7542), new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7542) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7544), null, new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7544) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7546), null, new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7546) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7548), null, new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7548) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7550), null, new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7552), new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7552) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7554), null, new DateTime(2024, 4, 3, 11, 58, 30, 203, DateTimeKind.Utc).AddTicks(7554) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8137), "", new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8138) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8160), "", new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8161) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8163), new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8163) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8164), "", new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8165) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8166), "", new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8168), "", new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8168) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8170), "", new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8172), new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8172) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "DiscountPrice", "Updated" },
                values: new object[] { new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8174), "", new DateTime(2024, 4, 3, 11, 48, 43, 479, DateTimeKind.Utc).AddTicks(8174) });
        }
    }
}
