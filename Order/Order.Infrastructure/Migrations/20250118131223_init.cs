using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Order.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ShippingFee = table.Column<int>(type: "integer", nullable: false),
                    DiscountFee = table.Column<int>(type: "integer", nullable: false),
                    VoucherName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VoucherCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VoucherValue = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Photo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "DiscountFee", "FullName", "LastModifiedAt", "LastModifiedBy", "Note", "Phone", "ShippingFee", "Status", "TotalPrice", "VoucherCode", "VoucherName", "VoucherValue" },
                values: new object[] { new Guid("81b32b4d-75ab-45ca-b932-ad2197004ade"), "Cần Thơ", new DateTime(2025, 1, 18, 13, 12, 23, 86, DateTimeKind.Utc).AddTicks(389), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), 0, "Huỳnh Hữu Nghĩa", new DateTime(2025, 1, 18, 13, 12, 23, 86, DateTimeKind.Utc).AddTicks(391), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Giao hàng nhanh", "0832474699", 32000, 0, 289814, "NGHIAHH", "Voucher 28/08", 24 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Category", "Discount", "Name", "OrderId", "Photo", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("8be8d0fd-6ff6-4d30-8268-92c7329a9229"), "Coffee", 5, "Phindi Hạt Dẻ Cười", new Guid("81b32b4d-75ab-45ca-b932-ad2197004ade"), "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg", 65000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"), 2 },
                    { new Guid("9d6837ec-e060-4ffc-a13c-e15d338cf25e"), "Coffee", 0, "PhinDi Cassia", new Guid("81b32b4d-75ab-45ca-b932-ad2197004ade"), "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg", 55000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"), 2 },
                    { new Guid("e6c309bd-62fb-4c0b-9ffd-7a2e7ce02e30"), "Other", 3, "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE", new Guid("81b32b4d-75ab-45ca-b932-ad2197004ade"), "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png", 109000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
