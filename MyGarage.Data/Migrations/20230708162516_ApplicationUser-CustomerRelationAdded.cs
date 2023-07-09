using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class ApplicationUserCustomerRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("1e4ce432-61a7-4b09-898e-878ce98758be"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5bf58197-6447-41bc-b942-e598f14e4dff"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f2e41eda-3eed-4451-b22a-37bf0e3a4661"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("b3511038-b514-48e9-b9d5-7133f3e6cc19"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bc832043-460b-4bfa-afd5-89fb0a083d09"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("3d628372-ecb9-4af8-935f-b9dd6adf1e1b"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("dbfbbd19-bf53-4738-b7bc-b588bfcc7028"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("5e002558-34fc-48f2-ba1d-78fa3f70533e"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("c30eb32c-9b6f-423a-b77e-91e8e2f7bb15"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("be1c0105-211e-4a66-9710-19f77ff68d6f"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("d05ef901-2e08-47ca-9fde-de7bd658b5b3"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 8, 16, 25, 15, 901, DateTimeKind.Utc).AddTicks(6748),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 8, 4, 40, 2, 572, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("9b8fd2ed-3e0c-4b72-84e3-bb9aa9007b23"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov", null },
                    { new Guid("e9882318-1d61-4663-9d8c-d81e168f5b6e"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov", null },
                    { new Guid("f84e9ea6-edcb-40f8-8b6e-94c15316a8ba"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov", null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobCardId", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("430bbbad-259b-409b-849f-f40360d4275d"), null, "Oil change", 50.00m },
                    { new Guid("5dcb549b-e468-44c4-bb26-7569b30b02f2"), null, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("42a4ad20-146e-4c16-ab37-eb2fe44efd88"), "Petar", "0888123457", "Petrov" },
                    { new Guid("da188915-e1db-4655-be6e-4f0a41bf0fd7"), "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "JobCardId", "PartName", "PartNumber" },
                values: new object[,]
                {
                    { new Guid("6a585155-41ef-46ee-bec8-4a62eede3901"), null, "Wishbone", "G40.3613/C" },
                    { new Guid("b4304aa7-800f-4be4-959d-9f4d457582b9"), null, "Handbrake cable", "G40.36415/C" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CustomerId", "EngineNumber", "FuelType", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("2ad5af7e-edb8-41b0-b2cf-770dfbef4714"), null, "5GZCZ33D03S835560", "Gasoline", "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("3c1a5adf-4ab6-4333-8665-367840bf7876"), null, "JN6MD06S2BW031939", "Gasoline", "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("9b8fd2ed-3e0c-4b72-84e3-bb9aa9007b23"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e9882318-1d61-4663-9d8c-d81e168f5b6e"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f84e9ea6-edcb-40f8-8b6e-94c15316a8ba"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("430bbbad-259b-409b-849f-f40360d4275d"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("5dcb549b-e468-44c4-bb26-7569b30b02f2"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("42a4ad20-146e-4c16-ab37-eb2fe44efd88"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("da188915-e1db-4655-be6e-4f0a41bf0fd7"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("6a585155-41ef-46ee-bec8-4a62eede3901"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("b4304aa7-800f-4be4-959d-9f4d457582b9"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("2ad5af7e-edb8-41b0-b2cf-770dfbef4714"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("3c1a5adf-4ab6-4333-8665-367840bf7876"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 8, 4, 40, 2, 572, DateTimeKind.Utc).AddTicks(9821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 8, 16, 25, 15, 901, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("1e4ce432-61a7-4b09-898e-878ce98758be"), null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov", null },
                    { new Guid("5bf58197-6447-41bc-b942-e598f14e4dff"), null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov", null },
                    { new Guid("f2e41eda-3eed-4451-b22a-37bf0e3a4661"), null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov", null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobCardId", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("b3511038-b514-48e9-b9d5-7133f3e6cc19"), null, "Tyre replacement", 20.00m },
                    { new Guid("bc832043-460b-4bfa-afd5-89fb0a083d09"), null, "Oil change", 50.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("3d628372-ecb9-4af8-935f-b9dd6adf1e1b"), "Petar", "0888123457", "Petrov" },
                    { new Guid("dbfbbd19-bf53-4738-b7bc-b588bfcc7028"), "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "JobCardId", "PartName", "PartNumber" },
                values: new object[,]
                {
                    { new Guid("5e002558-34fc-48f2-ba1d-78fa3f70533e"), null, "Handbrake cable", "G40.36415/C" },
                    { new Guid("c30eb32c-9b6f-423a-b77e-91e8e2f7bb15"), null, "Wishbone", "G40.3613/C" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("be1c0105-211e-4a66-9710-19f77ff68d6f"), null, null, "JN6MD06S2BW031939", "Gasoline", "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" },
                    { new Guid("d05ef901-2e08-47ca-9fde-de7bd658b5b3"), null, null, "5GZCZ33D03S835560", "Gasoline", "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ApplicationUserId",
                table: "Vehicles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
