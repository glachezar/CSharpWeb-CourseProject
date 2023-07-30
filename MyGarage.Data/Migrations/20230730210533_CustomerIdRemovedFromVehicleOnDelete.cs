using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class CustomerIdRemovedFromVehicleOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Customers_CustomerId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ce9c5f90-7a31-4eb3-9aac-76e53546488d"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f691c7cb-46a8-4169-9ad3-d2b036cb7c82"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("fe113243-cc3a-47f7-bf03-71d2c83f6147"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("7385e6db-2679-4a6b-97ff-55152ca6b869"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("abb7c781-5cfa-41df-bc46-a7e995390422"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("28bb0089-5595-4849-ab9e-d4cd039f6f7b"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("77a7b440-4828-45b6-b5f1-361ef29622a6"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("4bcb5708-ce9e-4d38-9bac-364a642acad0"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("a4b6ed33-5282-4ede-8dca-94b8d24bf8c0"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("20885837-4133-474c-9d89-718755f961ad"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("71d4d80b-f40b-4d91-b822-55fd7cbca3da"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 30, 21, 5, 33, 235, DateTimeKind.Utc).AddTicks(2502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 28, 11, 41, 11, 645, DateTimeKind.Utc).AddTicks(3650));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("2d2cd72c-e94a-473b-a648-9fa22a1ca44f"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov" },
                    { new Guid("3d5e9963-7262-42c5-9648-af169a4724c5"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov" },
                    { new Guid("fe2f0768-0716-42fd-bb06-9951628c784a"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "IsActive", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("8cb5c2d3-bba4-4ab7-a0e3-8ee8faaf8e56"), true, "Tyre replacement", 20.00m },
                    { new Guid("9de062eb-2124-453d-bad3-d42af9159171"), true, "Oil change", 50.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "IsActive", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("3b8e7941-2b88-4087-9f5c-e7124e555161"), true, "Ivan", "0888123456", "Ivanov" },
                    { new Guid("b995c558-3c32-46c4-82c9-f8725b54b4cc"), true, "Petar", "0888123457", "Petrov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "IsActive", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("9beb6774-d13b-4b53-b61f-88a277b5ff0e"), true, "Wishbone", "G40.3613/C", 70.00m },
                    { new Guid("a411abdb-b468-4a52-89de-dced0f7ea240"), true, "Handbrake cable", "G40.36415/C", 65.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "IsActive", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("4afd086f-c548-4dcc-885e-dada23b08298"), null, null, "12345678", "Gasoline", true, "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("bb64ad4f-d277-4ba4-a9c8-ddd7442fabb1"), null, null, "12345679", "Gasoline", true, "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Customers_CustomerId",
                table: "Vehicles",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Customers_CustomerId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("2d2cd72c-e94a-473b-a648-9fa22a1ca44f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("3d5e9963-7262-42c5-9648-af169a4724c5"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("fe2f0768-0716-42fd-bb06-9951628c784a"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("8cb5c2d3-bba4-4ab7-a0e3-8ee8faaf8e56"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("9de062eb-2124-453d-bad3-d42af9159171"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("3b8e7941-2b88-4087-9f5c-e7124e555161"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("b995c558-3c32-46c4-82c9-f8725b54b4cc"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("9beb6774-d13b-4b53-b61f-88a277b5ff0e"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("a411abdb-b468-4a52-89de-dced0f7ea240"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("4afd086f-c548-4dcc-885e-dada23b08298"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("bb64ad4f-d277-4ba4-a9c8-ddd7442fabb1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 28, 11, 41, 11, 645, DateTimeKind.Utc).AddTicks(3650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 30, 21, 5, 33, 235, DateTimeKind.Utc).AddTicks(2502));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("ce9c5f90-7a31-4eb3-9aac-76e53546488d"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov" },
                    { new Guid("f691c7cb-46a8-4169-9ad3-d2b036cb7c82"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov" },
                    { new Guid("fe113243-cc3a-47f7-bf03-71d2c83f6147"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "IsActive", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("7385e6db-2679-4a6b-97ff-55152ca6b869"), true, "Oil change", 50.00m },
                    { new Guid("abb7c781-5cfa-41df-bc46-a7e995390422"), true, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "IsActive", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("28bb0089-5595-4849-ab9e-d4cd039f6f7b"), true, "Petar", "0888123457", "Petrov" },
                    { new Guid("77a7b440-4828-45b6-b5f1-361ef29622a6"), true, "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "IsActive", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("4bcb5708-ce9e-4d38-9bac-364a642acad0"), true, "Wishbone", "G40.3613/C", 70.00m },
                    { new Guid("a4b6ed33-5282-4ede-8dca-94b8d24bf8c0"), true, "Handbrake cable", "G40.36415/C", 65.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "IsActive", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("20885837-4133-474c-9d89-718755f961ad"), null, null, "12345678", "Gasoline", true, "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("71d4d80b-f40b-4d91-b822-55fd7cbca3da"), null, null, "12345679", "Gasoline", true, "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Customers_CustomerId",
                table: "Vehicles",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
