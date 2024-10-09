using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityWithRazorPage.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] {"Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new[] {Guid.NewGuid().ToString(), "Admin", "ADMIN", Guid.NewGuid().ToString() },
                schema: "Security"
                );
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new[] { Guid.NewGuid().ToString(), "User", "USER", Guid.NewGuid().ToString() },
                schema: "Security"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [Security].[Roles]");
        }
    }
}
