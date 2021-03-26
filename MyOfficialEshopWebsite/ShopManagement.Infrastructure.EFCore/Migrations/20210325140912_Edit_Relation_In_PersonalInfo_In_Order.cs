using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class Edit_Relation_In_PersonalInfo_In_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_OrderId",
                table: "PersonalInformation");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_OrderId",
                table: "PersonalInformation",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_OrderId",
                table: "PersonalInformation");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_OrderId",
                table: "PersonalInformation",
                column: "OrderId");
        }
    }
}
