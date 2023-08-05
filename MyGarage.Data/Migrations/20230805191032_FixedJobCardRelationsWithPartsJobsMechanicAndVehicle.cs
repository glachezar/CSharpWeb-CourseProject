using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class FixedJobCardRelationsWithPartsJobsMechanicAndVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCardPart_Parts_PartsId",
                table: "JobCardPart");

            migrationBuilder.DropTable(
                name: "JobJobCard");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("856686a4-7eef-4b32-9c02-78a44d26c750"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("98d65ece-ce7e-4cd5-ae6d-5b5b976fd78b"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b8e05675-3dfd-4259-b8fd-bd6377c83821"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("0200b44f-c5e4-40be-839c-640f7d401909"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("57f35e55-ca82-4b1c-9283-7e6bfae07518"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("98d4552b-fbc7-4527-8ab0-016527aaf7b5"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("c44abaae-bc7a-4b55-8cc4-91ba1d7d6627"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("71cb3556-796e-41b5-83cb-07a260bad214"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("8f2da949-cc03-4c22-aa48-b1fc16d14fca"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("3a446cd0-2344-40f3-9a09-cbc0bbaefa89"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("a9f38e7a-1b07-48cb-b257-4fca2e111bcc"));

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "JobCards");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "JobCards");

            migrationBuilder.RenameColumn(
                name: "PartsId",
                table: "JobCardPart",
                newName: "PartId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardPart_PartsId",
                table: "JobCardPart",
                newName: "IX_JobCardPart_PartId");

            migrationBuilder.CreateTable(
                name: "JobCardJob",
                columns: table => new
                {
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardJob", x => new { x.JobId, x.JobCardId });
                    table.ForeignKey(
                        name: "FK_JobCardJob_JobCards_JobCardId",
                        column: x => x.JobCardId,
                        principalTable: "JobCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardJob_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_JobCardJob_JobCardId",
                table: "JobCardJob",
                column: "JobCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardPart_Parts_PartId",
                table: "JobCardPart",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCardPart_Parts_PartId",
                table: "JobCardPart");

            migrationBuilder.DropTable(
                name: "JobCardJob");

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

            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "JobCardPart",
                newName: "PartsId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardPart_PartId",
                table: "JobCardPart",
                newName: "IX_JobCardPart_PartsId");

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "JobCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PartId",
                table: "JobCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("856686a4-7eef-4b32-9c02-78a44d26c750"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov" },
                    { new Guid("98d65ece-ce7e-4cd5-ae6d-5b5b976fd78b"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov" },
                    { new Guid("b8e05675-3dfd-4259-b8fd-bd6377c83821"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "IsActive", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("0200b44f-c5e4-40be-839c-640f7d401909"), true, "Tyre replacement", 20.00m },
                    { new Guid("57f35e55-ca82-4b1c-9283-7e6bfae07518"), true, "Oil change", 50.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "IsActive", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("98d4552b-fbc7-4527-8ab0-016527aaf7b5"), true, "Petar", "0888123457", "Petrov" },
                    { new Guid("c44abaae-bc7a-4b55-8cc4-91ba1d7d6627"), true, "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "IsActive", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("71cb3556-796e-41b5-83cb-07a260bad214"), true, "Wishbone", "G40.3613/C", 70.00m },
                    { new Guid("8f2da949-cc03-4c22-aa48-b1fc16d14fca"), true, "Handbrake cable", "G40.36415/C", 65.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "IsActive", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("3a446cd0-2344-40f3-9a09-cbc0bbaefa89"), null, null, "12345679", "Gasoline", true, "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" },
                    { new Guid("a9f38e7a-1b07-48cb-b257-4fca2e111bcc"), null, null, "12345678", "Gasoline", true, "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobJobCard_JobsId",
                table: "JobJobCard",
                column: "JobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardPart_Parts_PartsId",
                table: "JobCardPart",
                column: "PartsId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
