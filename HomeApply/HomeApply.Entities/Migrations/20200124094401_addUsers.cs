using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeApply.Entities.Migrations
{
    public partial class addUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "SK");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "SK",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    MobileNo = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Qualification = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    AddressLine = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    InterestField = table.Column<string>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "SK");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "SK",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    InterestField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    MobileNo = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }
    }
}
