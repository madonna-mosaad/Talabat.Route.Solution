using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Layer.Data.Migrations
{
    /// <inheritdoc />
    public partial class editColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DilveryTime",
                table: "deliveryMethods",
                newName: "DeliveryTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryTime",
                table: "deliveryMethods",
                newName: "DilveryTime");
        }
    }
}
