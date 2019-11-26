using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOERegistration.WebAPI.Migrations
{
    public partial class initialmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseDegreeLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    DegreeLevelCode = table.Column<string>(nullable: false),
                    DegreeLevelName = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDegreeLevels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDegreeLevels");
        }
    }
}
