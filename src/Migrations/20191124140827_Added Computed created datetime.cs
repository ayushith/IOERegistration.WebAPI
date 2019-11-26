using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOERegistration.WebAPI.Migrations
{
    public partial class AddedComputedcreateddatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "CourseDegreeLevels",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "CourseDegreeLevels",
                columns: new[] { "Id", "CreatedBy", "DegreeLevelCode", "DegreeLevelName", "LastModified", "LastModifiedBy" },
                values: new object[] { 1, "Admin", "B", "Bachelor", null, null });

            migrationBuilder.InsertData(
                table: "CourseDegreeLevels",
                columns: new[] { "Id", "CreatedBy", "DegreeLevelCode", "DegreeLevelName", "LastModified", "LastModifiedBy" },
                values: new object[] { 2, "Admin", "M", "Master", null, null });

            migrationBuilder.InsertData(
                table: "CourseDegreeLevels",
                columns: new[] { "Id", "CreatedBy", "DegreeLevelCode", "DegreeLevelName", "LastModified", "LastModifiedBy" },
                values: new object[] { 3, "Admin", "P", "PHD", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseDegreeLevels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseDegreeLevels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseDegreeLevels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "CourseDegreeLevels",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
