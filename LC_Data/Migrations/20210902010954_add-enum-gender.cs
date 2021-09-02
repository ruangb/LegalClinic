using Microsoft.EntityFrameworkCore.Migrations;

namespace LC.Data.Migrations
{
    public partial class addenumgender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldDefaultValue: "M");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Customers",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "M",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
