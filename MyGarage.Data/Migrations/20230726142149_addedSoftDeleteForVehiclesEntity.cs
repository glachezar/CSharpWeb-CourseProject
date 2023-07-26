using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class addedSoftDeleteForVehiclesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5156d9c7-1ddf-4066-9182-5c5e76ae0f1a"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a51efaa6-a946-41c5-b5dd-31bf02553539"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ddefdbd2-e6ff-4b70-b214-8642aa05ced5"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("88c8c9ce-8f2b-4615-8d06-972c746b4eeb"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("d7cc8159-422e-4a62-9fb5-c99207cb8a85"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("3738c511-a9af-47b1-bf80-6b5a03e0c6ee"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("80c2a4cc-f6bc-48b7-935d-9e0f09082264"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("5311c357-663e-4de7-9a50-64a3045b3e75"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("89be2c05-61fc-4fa0-b7ba-286cf4b5929e"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("1996a226-488e-417a-8b75-25213cedb1fe"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("969c3f9f-c59b-4c5b-a689-d2cfd36b639a"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 14, 21, 48, 549, DateTimeKind.Utc).AddTicks(6064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 25, 18, 34, 39, 536, DateTimeKind.Utc).AddTicks(3865));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("04a36611-0e5c-4152-a7d4-bde574991396"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov", null },
                    { new Guid("5877c6b9-4bb9-4335-a7b0-cd3baeb8ff0e"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov", null },
                    { new Guid("9eb204ad-b8c6-4e4a-a1ee-1b1267e88b1b"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov", null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("03531805-e054-4179-a1d1-6071c9c6ce4d"), "Tyre replacement", 20.00m },
                    { new Guid("c3a2f70a-0a4f-4557-aa69-33427ab12a5e"), "Oil change", 50.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("34b3ec3a-5680-487c-a465-8ebf13d922e2"), "Petar", "0888123457", "Petrov" },
                    { new Guid("5416b35c-4964-4ed7-a125-d12cc4765339"), "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "JobCardId", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("5c5a99d7-90a9-4ffb-9842-5fb8b5332ce6"), null, "Handbrake cable", "G40.36415/C", 65.00m },
                    { new Guid("9c06cacc-e6e1-493f-a21f-2cc92b756feb"), null, "Wishbone", "G40.3613/C", 70.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "IsActive", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("0ebaf95a-ffc7-4987-95f8-6f1c238301eb"), null, null, "12345678", "Gasoline", true, "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("46997793-e217-4db1-bf2d-a2f795ccf8b3"), null, null, "12345679", "Gasoline", true, "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("04a36611-0e5c-4152-a7d4-bde574991396"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5877c6b9-4bb9-4335-a7b0-cd3baeb8ff0e"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("9eb204ad-b8c6-4e4a-a1ee-1b1267e88b1b"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("03531805-e054-4179-a1d1-6071c9c6ce4d"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("c3a2f70a-0a4f-4557-aa69-33427ab12a5e"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("34b3ec3a-5680-487c-a465-8ebf13d922e2"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("5416b35c-4964-4ed7-a125-d12cc4765339"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("5c5a99d7-90a9-4ffb-9842-5fb8b5332ce6"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("9c06cacc-e6e1-493f-a21f-2cc92b756feb"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("0ebaf95a-ffc7-4987-95f8-6f1c238301eb"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("46997793-e217-4db1-bf2d-a2f795ccf8b3"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vehicles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 18, 34, 39, 536, DateTimeKind.Utc).AddTicks(3865),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 26, 14, 21, 48, 549, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("5156d9c7-1ddf-4066-9182-5c5e76ae0f1a"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov", null },
                    { new Guid("a51efaa6-a946-41c5-b5dd-31bf02553539"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov", null },
                    { new Guid("ddefdbd2-e6ff-4b70-b214-8642aa05ced5"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov", null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("88c8c9ce-8f2b-4615-8d06-972c746b4eeb"), "Tyre replacement", 20.00m },
                    { new Guid("d7cc8159-422e-4a62-9fb5-c99207cb8a85"), "Oil change", 50.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("3738c511-a9af-47b1-bf80-6b5a03e0c6ee"), "Ivan", "0888123456", "Ivanov" },
                    { new Guid("80c2a4cc-f6bc-48b7-935d-9e0f09082264"), "Petar", "0888123457", "Petrov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "JobCardId", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("5311c357-663e-4de7-9a50-64a3045b3e75"), null, "Wishbone", "G40.3613/C", 70.00m },
                    { new Guid("89be2c05-61fc-4fa0-b7ba-286cf4b5929e"), null, "Handbrake cable", "G40.36415/C", 65.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("1996a226-488e-417a-8b75-25213cedb1fe"), null, null, "12345678", "Gasoline", "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("969c3f9f-c59b-4c5b-a689-d2cfd36b639a"), null, null, "12345679", "Gasoline", "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });
        }
    }
}
