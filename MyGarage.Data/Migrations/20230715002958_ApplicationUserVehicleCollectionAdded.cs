using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class ApplicationUserVehicleCollectionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("0337c1dd-08fa-4b3a-aac9-4b57b1f90c9a"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("371b5cdc-1779-4888-8f9a-c58542b48902"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("3c44ffef-bcd6-4d9e-9341-3df9aa75a4b5"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("0ad1f76c-478f-4efe-9705-6aa764c86b03"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("fcb640fe-67c0-482a-b599-a7acca967a35"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("523d2f9f-3b0a-466a-8a40-7f28c73ca220"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("839d20b4-fe29-4c58-ac57-7fc0c5c0f6b9"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("036f4771-e075-4d08-bf80-5afc5794f0b6"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("3acb2cf4-01b9-4ba8-a07b-d3f0c54611f9"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("1b0b15fe-8fc4-4b3a-b216-c9a7818cdc23"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("b8e55a4b-36e0-45e9-9906-41a095813738"));

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
                defaultValue: new DateTime(2023, 7, 15, 0, 29, 57, 410, DateTimeKind.Utc).AddTicks(156),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 0, 13, 59, 713, DateTimeKind.Utc).AddTicks(6641));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("4293f1fd-326d-4848-a000-cdd21214e618"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov", null },
                    { new Guid("54d9dc25-93b1-4445-a63c-9b9e8a7337ab"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov", null },
                    { new Guid("6d594eda-fc37-49fc-9802-d06ad507a426"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov", null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobCardId", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("0ca55a51-b362-4a2b-ada8-d7216dc45ca5"), null, "Oil change", 50.00m },
                    { new Guid("ae845ed9-d129-4fbb-be3a-596d58b37dc7"), null, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("1f883a74-cc3e-4068-ab50-ee1517b9b10f"), "Petar", "0888123457", "Petrov" },
                    { new Guid("49aec610-97bb-4768-95ae-e208926978dd"), "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "JobCardId", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("6ba6c4a8-c4a9-4262-b579-d168687d1995"), null, "Handbrake cable", "G40.36415/C", 65.00m },
                    { new Guid("93c4492d-73ab-4ea3-b8d8-cecbbfb4c109"), null, "Wishbone", "G40.3613/C", 70.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("6131ea8b-b390-4bd9-90b6-788529c37e91"), null, null, "12345679", "Gasoline", "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" },
                    { new Guid("d4ce8a6c-e22a-47f1-b53d-6d6615b559a7"), null, null, "12345678", "Gasoline", "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" }
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("4293f1fd-326d-4848-a000-cdd21214e618"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("54d9dc25-93b1-4445-a63c-9b9e8a7337ab"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("6d594eda-fc37-49fc-9802-d06ad507a426"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("0ca55a51-b362-4a2b-ada8-d7216dc45ca5"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("ae845ed9-d129-4fbb-be3a-596d58b37dc7"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("1f883a74-cc3e-4068-ab50-ee1517b9b10f"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("49aec610-97bb-4768-95ae-e208926978dd"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("6ba6c4a8-c4a9-4262-b579-d168687d1995"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("93c4492d-73ab-4ea3-b8d8-cecbbfb4c109"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("6131ea8b-b390-4bd9-90b6-788529c37e91"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("d4ce8a6c-e22a-47f1-b53d-6d6615b559a7"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 0, 13, 59, 713, DateTimeKind.Utc).AddTicks(6641),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 0, 29, 57, 410, DateTimeKind.Utc).AddTicks(156));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("0337c1dd-08fa-4b3a-aac9-4b57b1f90c9a"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov", null },
                    { new Guid("371b5cdc-1779-4888-8f9a-c58542b48902"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov", null },
                    { new Guid("3c44ffef-bcd6-4d9e-9341-3df9aa75a4b5"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov", null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobCardId", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("0ad1f76c-478f-4efe-9705-6aa764c86b03"), null, "Oil change", 50.00m },
                    { new Guid("fcb640fe-67c0-482a-b599-a7acca967a35"), null, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("523d2f9f-3b0a-466a-8a40-7f28c73ca220"), "Petar", "0888123457", "Petrov" },
                    { new Guid("839d20b4-fe29-4c58-ac57-7fc0c5c0f6b9"), "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "JobCardId", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("036f4771-e075-4d08-bf80-5afc5794f0b6"), null, "Wishbone", "G40.3613/C", 70.00m },
                    { new Guid("3acb2cf4-01b9-4ba8-a07b-d3f0c54611f9"), null, "Handbrake cable", "G40.36415/C", 65.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CustomerId", "EngineNumber", "FuelType", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("1b0b15fe-8fc4-4b3a-b216-c9a7818cdc23"), null, "5GZCZ33D03S835560", "Gasoline", "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("b8e55a4b-36e0-45e9-9906-41a095813738"), null, "JN6MD06S2BW031939", "Gasoline", "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });
        }
    }
}
