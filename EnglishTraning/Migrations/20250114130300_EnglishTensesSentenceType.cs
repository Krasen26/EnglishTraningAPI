using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTraning.Migrations
{
    /// <inheritdoc />
    public partial class EnglishTensesSentenceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SentenceType",
                table: "EnglishTenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentenceType",
                table: "EnglishTenses");
        }
    }
}
