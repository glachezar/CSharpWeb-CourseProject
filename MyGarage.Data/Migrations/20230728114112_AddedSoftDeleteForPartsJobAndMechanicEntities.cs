using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class AddedSoftDeleteForPartsJobAndMechanicEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_JobCards_JobCardId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_JobCardId",
                table: "Parts");

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
                name: "JobCardId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Customers");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Parts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Mechanics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 28, 11, 41, 11, 645, DateTimeKind.Utc).AddTicks(3650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 26, 14, 21, 48, 549, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.CreateTable(
                name: "JobCardPart",
                columns: table => new
                {
                    JobCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardPart", x => new { x.JobCardId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_JobCardPart_JobCards_JobCardId",
                        column: x => x.JobCardId,
                        principalTable: "JobCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardPart_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_JobCardPart_PartsId",
                table: "JobCardPart",
                column: "PartsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCardPart");

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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Jobs");

            migrationBuilder.AddColumn<Guid>(
                name: "JobCardId",
                table: "Parts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 14, 21, 48, 549, DateTimeKind.Utc).AddTicks(6064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 28, 11, 41, 11, 645, DateTimeKind.Utc).AddTicks(3650));

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Parts_JobCardId",
                table: "Parts",
                column: "JobCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_JobCards_JobCardId",
                table: "Parts",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id");
        }
    }
}
