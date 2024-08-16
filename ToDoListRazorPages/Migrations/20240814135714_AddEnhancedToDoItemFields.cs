using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListRazorPages.Migrations
{
    /// <inheritdoc />
    public partial class AddEnhancedToDoItemFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "ToDoItems",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                  CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                  IsCompleted = table.Column<bool>(type: "bit", nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_ToDoItems", x => x.Id);
              });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
