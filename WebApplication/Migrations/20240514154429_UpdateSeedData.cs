using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsGraduated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthPlace", "DateOfBirth", "FirstName", "Gender", "IsGraduated", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("1474ca19-ff9f-4a0b-8502-c203e8609e26"), "Lâm Đồng", new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Công", 0, true, "Đặng Phan Thành", "0375.284.637" },
                    { new Guid("2d827ff5-420f-4ba2-aae1-478bb9e8dd92"), "Hà Nội", new DateTime(1995, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linh", 1, true, "Nguyễn Mỹ", "0375.284.636" },
                    { new Guid("c9884941-4d2c-4e57-bcdc-a65dd88bdd11"), "Hải Phòng", new DateTime(2002, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phương", 1, false, "Nguyễn Thị Mai", "0375.284.635" },
                    { new Guid("e4e77d8f-684d-473e-be17-03c43a076ded"), "Huế", new DateTime(2003, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thu", 1, false, "Phan Thị Hà", "0375.284.634" },
                    { new Guid("f37bcac6-754b-4d7f-9c66-4387f9e98cd7"), "Hà Nội", new DateTime(1994, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quang", 0, false, "Trần Huy", "0375.284.633" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
