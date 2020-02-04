using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskDAL.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Industries_industryId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Industries_industryId",
                table: "AspNetUsers",
                column: "industryId",
                principalTable: "Industries",
                principalColumn: "industryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Industries_industryId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Industries_industryId",
                table: "AspNetUsers",
                column: "industryId",
                principalTable: "Industries",
                principalColumn: "industryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
