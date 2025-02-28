using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SQLServer.EF.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Orders_OrderId",
                table: "Images");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImagePath", "OrderId" },
                values: new object[] { 1, "Images/Orders/wall.jpg", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Orders_OrderId",
                table: "Images",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Orders_OrderId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Orders_OrderId",
                table: "Images",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
