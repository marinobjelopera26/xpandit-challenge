using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpandIT.Challenge.DataLayer.Migrations
{
    public partial class AddAddressColumnToContactsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_CBK_PhoneNumberType_NumberTypeId",
                table: "PhoneNumber");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumber_NumberTypeId",
                table: "PhoneNumber");

            migrationBuilder.DropColumn(
                name: "NumberTypeId",
                table: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contact",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_Type",
                table: "PhoneNumber",
                column: "Type");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_CBK_PhoneNumberType_Type",
                table: "PhoneNumber",
                column: "Type",
                principalTable: "CBK_PhoneNumberType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_CBK_PhoneNumberType_Type",
                table: "PhoneNumber");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumber_Type",
                table: "PhoneNumber");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "NumberTypeId",
                table: "PhoneNumber",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_NumberTypeId",
                table: "PhoneNumber",
                column: "NumberTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_CBK_PhoneNumberType_NumberTypeId",
                table: "PhoneNumber",
                column: "NumberTypeId",
                principalTable: "CBK_PhoneNumberType",
                principalColumn: "Id");
        }
    }
}
