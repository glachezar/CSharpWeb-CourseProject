using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class AddedPricePropertyToPartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Parts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 13, 17, 49, 21, 49, DateTimeKind.Utc).AddTicks(8236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 8, 16, 54, 18, 439, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("1a1fe45e-6b52-43f5-aa89-834bd8a5ab07"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov", null },
                    { new Guid("1eba4f2a-400e-4dc4-a985-d6a5630e687f"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov", null },
                    { new Guid("5217caa3-b513-434a-8e9f-80999d50f9e8"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov", null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobCardId", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("0919e083-7137-417a-9a35-8ee5fd11e5b7"), null, "Tyre replacement", 20.00m },
                    { new Guid("740d1999-24af-4eff-a0d0-a7b564643898"), null, "Oil change", 50.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("029dff04-c0cd-42d1-acfd-64eb2599fe67"), "Petar", "0888123457", "Petrov" },
                    { new Guid("97df411f-c565-4523-bdf1-8e01fba64fdb"), "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "JobCardId", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("2c566e7e-a017-48cc-8542-43cb348316f6"), null, "Wishbone", "G40.3613/C", 70.00m },
                    { new Guid("c537a6f7-646e-4544-8a66-d67a2ffc323d"), null, "Handbrake cable", "G40.36415/C", 65.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CustomerId", "EngineNumber", "FuelType", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("29971c57-ec5b-4d0c-b6e1-7d7366f5a90b"), null, "JN6MD06S2BW031939", "Gasoline", "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" },
                    { new Guid("7ab8b5cd-781b-4358-9ff3-b9f25959e7d3"), null, "5GZCZ33D03S835560", "Gasoline", "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("1a1fe45e-6b52-43f5-aa89-834bd8a5ab07"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("1eba4f2a-400e-4dc4-a985-d6a5630e687f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5217caa3-b513-434a-8e9f-80999d50f9e8"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("0919e083-7137-417a-9a35-8ee5fd11e5b7"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("740d1999-24af-4eff-a0d0-a7b564643898"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("029dff04-c0cd-42d1-acfd-64eb2599fe67"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("97df411f-c565-4523-bdf1-8e01fba64fdb"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("2c566e7e-a017-48cc-8542-43cb348316f6"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("c537a6f7-646e-4544-8a66-d67a2ffc323d"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("29971c57-ec5b-4d0c-b6e1-7d7366f5a90b"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("7ab8b5cd-781b-4358-9ff3-b9f25959e7d3"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Parts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 8, 16, 54, 18, 439, DateTimeKind.Utc).AddTicks(8899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 13, 17, 49, 21, 49, DateTimeKind.Utc).AddTicks(8236));

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
        }
    }
}
