using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityWithRazorPage.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserTokens",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "UserLogins",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "UserClaims",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "RoleClaims",
                newSchema: "Security");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Security",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Security",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "FName",
                schema: "Security",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LName",
                schema: "Security",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "Security",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "Security",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Security",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FName",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LName",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Security",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Security",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "Security",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Security",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Security",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Security",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Security",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Security",
                newName: "RoleClaims");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
