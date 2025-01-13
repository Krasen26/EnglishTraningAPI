﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTraning.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnglishTenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BulgarianSentence = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EnglishSentence = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TensesType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishTenses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnglishTenses");
        }
    }
}
