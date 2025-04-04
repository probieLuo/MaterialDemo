using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    content = table.Column<string>(type: "TEXT", nullable: false),
                    excerpt = table.Column<string>(type: "TEXT", nullable: true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    category_id = table.Column<int>(type: "INTEGER", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "draft"),
                    keywords = table.Column<string>(type: "TEXT", nullable: true),
                    views = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0),
                    likes = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0),
                    created_at = table.Column<int>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<int>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    published_at = table.Column<int>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    age = table.Column<int>(type: "INT", nullable: false),
                    address = table.Column<string>(type: "CHAR(50)", nullable: true),
                    salary = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
