using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class ApplicationUserCustomerRelationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 8, 16, 54, 18, 439, DateTimeKind.Utc).AddTicks(8899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 8, 16, 25, 15, 901, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("54324ca0-a853-49ba-968d-1e7805dfd5d8"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov", null },
                    { new Guid("6a50272d-0e96-46bb-ade2-2388e3893a38"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov", null },
                    { new Guid("ab62bb11-3d07-4ee1-9581-f1911b02b9d1"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov", null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobCardId", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("15805aba-6eef-46ba-8f6e-31ff895cb193"), null, "Oil change", 50.00m },
                    { new Guid("d7c921b7-1eec-4b41-b434-e807e2416215"), null, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("60859e26-4040-4247-ac01-86485c91819c"), "Petar", "0888123457", "Petrov" },
                    { new Guid("7ade9fb8-2421-4bd4-a5c4-65583ed70f4b"), "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "JobCardId", "PartName", "PartNumber" },
                values: new object[,]
                {
                    { new Guid("2bbd2119-c6a1-43b7-853f-6eb3028f3059"), null, "Wishbone", "G40.3613/C" },
                    { new Guid("ff7d7e28-09a7-4233-8eff-70d668a8ffae"), null, "Handbrake cable", "G40.36415/C" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CustomerId", "EngineNumber", "FuelType", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("a62d5073-052d-4b96-88a5-df3ab3a0a98b"), null, "5GZCZ33D03S835560", "Gasoline", "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("deb12c65-790a-4491-aa2c-2e846704e034"), null, "JN6MD06S2BW031939", "Gasoline", "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("54324ca0-a853-49ba-968d-1e7805dfd5d8"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("6a50272d-0e96-46bb-ade2-2388e3893a38"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ab62bb11-3d07-4ee1-9581-f1911b02b9d1"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("15805aba-6eef-46ba-8f6e-31ff895cb193"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("d7c921b7-1eec-4b41-b434-e807e2416215"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("60859e26-4040-4247-ac01-86485c91819c"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("7ade9fb8-2421-4bd4-a5c4-65583ed70f4b"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("2bbd2119-c6a1-43b7-853f-6eb3028f3059"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("ff7d7e28-09a7-4233-8eff-70d668a8ffae"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("a62d5073-052d-4b96-88a5-df3ab3a0a98b"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("deb12c65-790a-4491-aa2c-2e846704e034"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 8, 16, 25, 15, 901, DateTimeKind.Utc).AddTicks(6748),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 8, 16, 54, 18, 439, DateTimeKind.Utc).AddTicks(8899));

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
        }
    }
}
