using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class EntityRelationsFixedAndDataSeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobCards_JobCardId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_JobCards_JobCardId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Customers_CustomerId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("29e48460-1bc1-4c5f-b739-4a8ed60dfd44"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("cd25734b-1377-47d7-bd7b-885e640b7c34"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd5e4b-563d-4bfe-923d-584a35e54672"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobCardId",
                table: "Parts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobCardId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 8, 4, 40, 2, 572, DateTimeKind.Utc).AddTicks(9821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 11, 35, 47, 622, DateTimeKind.Utc).AddTicks(5964));

            migrationBuilder.AddColumn<Guid>(
                name: "MechanicId",
                table: "JobCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "IX_JobCards_MechanicId",
                table: "JobCards",
                column: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Mechanics_MechanicId",
                table: "JobCards",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobCards_JobCardId",
                table: "Jobs",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_JobCards_JobCardId",
                table: "Parts",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Customers_CustomerId",
                table: "Vehicles",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Mechanics_MechanicId",
                table: "JobCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobCards_JobCardId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_JobCards_JobCardId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Customers_CustomerId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_JobCards_MechanicId",
                table: "JobCards");

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
                name: "MechanicId",
                table: "JobCards");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JobCardId",
                table: "Parts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JobCardId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 11, 35, 47, 622, DateTimeKind.Utc).AddTicks(5964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 8, 4, 40, 2, 572, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[] { new Guid("29e48460-1bc1-4c5f-b739-4a8ed60dfd44"), null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[] { new Guid("cd25734b-1377-47d7-bd7b-885e640b7c34"), null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Egn", "Email", "Name", "PhoneNumber", "Surname", "VehicleId" },
                values: new object[] { new Guid("d4fd5e4b-563d-4bfe-923d-584a35e54672"), null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobCards_JobCardId",
                table: "Jobs",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_JobCards_JobCardId",
                table: "Parts",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Customers_CustomerId",
                table: "Vehicles",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
