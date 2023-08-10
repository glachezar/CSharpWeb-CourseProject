using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class AddedJobCardPartsAndJobCardJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCardJob_JobCards_JobCardId",
                table: "JobCardJob");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCardJob_Jobs_JobId",
                table: "JobCardJob");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCardPart_JobCards_JobCardId",
                table: "JobCardPart");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCardPart_Parts_PartId",
                table: "JobCardPart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCardPart",
                table: "JobCardPart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCardJob",
                table: "JobCardJob");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("170c83f8-04d5-498c-8b27-79a3fb1d5a91"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("18ffd78a-9d2b-4bcb-9c0e-4703e2823e62"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a62280b0-2fcf-469e-a387-8febe4713cf2"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("00b6e79d-f29f-4fec-901b-37042f1babe5"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("125c95bf-bce4-44c8-9b24-104db763011d"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("44a00d0e-7c3f-4e3d-afba-0f21f6b353f9"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("739a3218-b371-4594-8411-1ac051122d44"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("5fb20293-0922-45ae-a4ad-40ea8128610b"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("f11a8741-20c2-4f81-900e-2b29c6eb0488"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("aa675283-bc85-44d8-ba8d-8b9de860d49e"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("b05aa607-e157-4fb1-8bdb-847ce21915fe"));

            migrationBuilder.RenameTable(
                name: "JobCardPart",
                newName: "JobCardParts");

            migrationBuilder.RenameTable(
                name: "JobCardJob",
                newName: "JobCardJobs");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardPart_PartId",
                table: "JobCardParts",
                newName: "IX_JobCardParts_PartId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardJob_JobCardId",
                table: "JobCardJobs",
                newName: "IX_JobCardJobs_JobCardId");

            migrationBuilder.AlterColumn<string>(
                name: "RegNumber",
                table: "Vehicles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Mileage",
                table: "Vehicles",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "EngineNumber",
                table: "Vehicles",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCardParts",
                table: "JobCardParts",
                columns: new[] { "JobCardId", "PartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCardJobs",
                table: "JobCardJobs",
                columns: new[] { "JobId", "JobCardId" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("b3f92660-0c1e-4459-8523-4bbb4b111c62"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov" },
                    { new Guid("b8a79345-25de-4c65-9bf0-4c489a4d6d3b"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov" },
                    { new Guid("ec90e7e0-905d-4c85-84b4-d221b10c71c0"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "IsActive", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("441542ee-8008-4384-a760-751c654a5d42"), true, "Oil change", 50.00m },
                    { new Guid("b8ff8022-00bd-4dda-aeaa-643f14f5ff92"), true, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "IsActive", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("64005135-bcdd-4b2e-b390-6bb976032eed"), true, "Ivan", "0888123456", "Ivanov" },
                    { new Guid("f18286c1-e8fc-49bf-9caf-ac9db07bc936"), true, "Petar", "0888123457", "Petrov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "IsActive", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("75ed0495-f56c-42ec-800f-2a751143cae3"), true, "Handbrake cable", "G40.36415/C", 65.00m },
                    { new Guid("c4215a06-6978-4693-83f2-e965edefd114"), true, "Wishbone", "G40.3613/C", 70.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "IsActive", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("b41ac9a3-6f4b-4be1-9218-7d68d724dbdb"), null, null, "12345678", "Gasoline", true, "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("ea22b878-249d-407a-9989-4d15c95f2a0d"), null, null, "12345679", "Gasoline", true, "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardJobs_JobCards_JobCardId",
                table: "JobCardJobs",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardJobs_Jobs_JobId",
                table: "JobCardJobs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardParts_JobCards_JobCardId",
                table: "JobCardParts",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardParts_Parts_PartId",
                table: "JobCardParts",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCardJobs_JobCards_JobCardId",
                table: "JobCardJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCardJobs_Jobs_JobId",
                table: "JobCardJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCardParts_JobCards_JobCardId",
                table: "JobCardParts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCardParts_Parts_PartId",
                table: "JobCardParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCardParts",
                table: "JobCardParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCardJobs",
                table: "JobCardJobs");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b3f92660-0c1e-4459-8523-4bbb4b111c62"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b8a79345-25de-4c65-9bf0-4c489a4d6d3b"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ec90e7e0-905d-4c85-84b4-d221b10c71c0"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("441542ee-8008-4384-a760-751c654a5d42"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("b8ff8022-00bd-4dda-aeaa-643f14f5ff92"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("64005135-bcdd-4b2e-b390-6bb976032eed"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("f18286c1-e8fc-49bf-9caf-ac9db07bc936"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("75ed0495-f56c-42ec-800f-2a751143cae3"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("c4215a06-6978-4693-83f2-e965edefd114"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("b41ac9a3-6f4b-4be1-9218-7d68d724dbdb"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("ea22b878-249d-407a-9989-4d15c95f2a0d"));

            migrationBuilder.RenameTable(
                name: "JobCardParts",
                newName: "JobCardPart");

            migrationBuilder.RenameTable(
                name: "JobCardJobs",
                newName: "JobCardJob");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardParts_PartId",
                table: "JobCardPart",
                newName: "IX_JobCardPart_PartId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardJobs_JobCardId",
                table: "JobCardJob",
                newName: "IX_JobCardJob_JobCardId");

            migrationBuilder.AlterColumn<string>(
                name: "RegNumber",
                table: "Vehicles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mileage",
                table: "Vehicles",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EngineNumber",
                table: "Vehicles",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCardPart",
                table: "JobCardPart",
                columns: new[] { "JobCardId", "PartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCardJob",
                table: "JobCardJob",
                columns: new[] { "JobId", "JobCardId" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("170c83f8-04d5-498c-8b27-79a3fb1d5a91"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov" },
                    { new Guid("18ffd78a-9d2b-4bcb-9c0e-4703e2823e62"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov" },
                    { new Guid("a62280b0-2fcf-469e-a387-8febe4713cf2"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "IsActive", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("00b6e79d-f29f-4fec-901b-37042f1babe5"), true, "Oil change", 50.00m },
                    { new Guid("125c95bf-bce4-44c8-9b24-104db763011d"), true, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "IsActive", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("44a00d0e-7c3f-4e3d-afba-0f21f6b353f9"), true, "Ivan", "0888123456", "Ivanov" },
                    { new Guid("739a3218-b371-4594-8411-1ac051122d44"), true, "Petar", "0888123457", "Petrov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "IsActive", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("5fb20293-0922-45ae-a4ad-40ea8128610b"), true, "Wishbone", "G40.3613/C", 70.00m },
                    { new Guid("f11a8741-20c2-4f81-900e-2b29c6eb0488"), true, "Handbrake cable", "G40.36415/C", 65.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "IsActive", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("aa675283-bc85-44d8-ba8d-8b9de860d49e"), null, null, "12345678", "Gasoline", true, "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("b05aa607-e157-4fb1-8bdb-847ce21915fe"), null, null, "12345679", "Gasoline", true, "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardJob_JobCards_JobCardId",
                table: "JobCardJob",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardJob_Jobs_JobId",
                table: "JobCardJob",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardPart_JobCards_JobCardId",
                table: "JobCardPart",
                column: "JobCardId",
                principalTable: "JobCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardPart_Parts_PartId",
                table: "JobCardPart",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
