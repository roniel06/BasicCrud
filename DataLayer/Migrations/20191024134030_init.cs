using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 80, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 80, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    SecondName = table.Column<string>(maxLength: 80, nullable: false),
                    LastName = table.Column<string>(maxLength: 80, nullable: false),
                    SecondLastName = table.Column<string>(maxLength: 80, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 80, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 80, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PersonId",
                table: "Articles",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
