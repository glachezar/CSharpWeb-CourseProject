using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class AddedManyToMAnyRelationBetweenJobAndJObCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobCards_JobCardId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobCardId",
                table: "Jobs");

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
                name: "JobCardId",
                table: "Jobs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 18, 34, 39, 536, DateTimeKind.Utc).AddTicks(3865),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 0, 29, 57, 410, DateTimeKind.Utc).AddTicks(156));

            migrationBuilder.CreateTable(
                name: "JobJobCard",
                columns: table => new
                {
                    JobCardsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobJobCard", x => new { x.JobCardsId, x.JobsId });
                    table.ForeignKey(
                        name: "FK_JobJobCard_JobCards_JobCardsId",
                        column: x => x.JobCardsId,
                        principalTable: "JobCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobJobCard_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_JobJobCard_JobsId",
                table: "JobJobCard",
                column: "JobsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobJobCard");

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

            migrationBuilder.AddColumn<Guid>(
                name: "JobCardId",
                table: "Jobs",
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
                oldDefaultValue: new DateTime(2023, 7, 25, 18, 34, 39, 536, DateTimeKind.Utc).AddTicks(3865));

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
                name: "IX_Jobs_JobCardId",
                table: "Jobs",
                column: "JobCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobCards_JobCardId",
                table: "Jobs",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id");
        }
    }
}
