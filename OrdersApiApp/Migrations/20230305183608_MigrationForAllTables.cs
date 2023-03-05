using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersApiApp.Migrations
{
    /// <inheritdoc />
    public partial class MigrationForAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_EntityOrder_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Product_ProductId",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "EntityProduct");

            migrationBuilder.RenameTable(
                name: "OrderProduct",
                newName: "EntityOrderProduct");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductId",
                table: "EntityOrderProduct",
                newName: "IX_EntityOrderProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_OrderId",
                table: "EntityOrderProduct",
                newName: "IX_EntityOrderProduct_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityProduct",
                table: "EntityProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityOrderProduct",
                table: "EntityOrderProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityOrderProduct_EntityOrder_OrderId",
                table: "EntityOrderProduct",
                column: "OrderId",
                principalTable: "EntityOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityOrderProduct_EntityProduct_ProductId",
                table: "EntityOrderProduct",
                column: "ProductId",
                principalTable: "EntityProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityOrderProduct_EntityOrder_OrderId",
                table: "EntityOrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityOrderProduct_EntityProduct_ProductId",
                table: "EntityOrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityProduct",
                table: "EntityProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityOrderProduct",
                table: "EntityOrderProduct");

            migrationBuilder.RenameTable(
                name: "EntityProduct",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "EntityOrderProduct",
                newName: "OrderProduct");

            migrationBuilder.RenameIndex(
                name: "IX_EntityOrderProduct_ProductId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_EntityOrderProduct_OrderId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_EntityOrder_OrderId",
                table: "OrderProduct",
                column: "OrderId",
                principalTable: "EntityOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Product_ProductId",
                table: "OrderProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
