using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class AddedCustomerIdRelationToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("314bb288-753d-41d8-8b51-a019b418bb10"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("bf6136b0-f608-4b54-ada3-f806814336c4"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e1f50d11-4cbd-4d33-b4c0-2181bd2730a6"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("018c307f-f810-44b2-88d7-20c2bf99ebab"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("237a7a16-4230-42c1-a88b-68bdca61d3a3"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("27d2c681-c3b1-40e7-a7eb-ebc4e9b26dc3"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("3f7fe907-1b59-4675-9516-b0d6da6783f3"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("94863fbc-a1c7-4043-a700-b581bbc36b65"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("e083be9e-9269-4ae4-87c3-c272a775da68"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("27fe0c8d-859a-4093-8b3f-f4197dee28ed"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("a8f8bc9d-50ee-43dd-8e97-a9f9df0b9805"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CustomerId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("314bb288-753d-41d8-8b51-a019b418bb10"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov" },
                    { new Guid("bf6136b0-f608-4b54-ada3-f806814336c4"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov" },
                    { new Guid("e1f50d11-4cbd-4d33-b4c0-2181bd2730a6"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "IsActive", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("018c307f-f810-44b2-88d7-20c2bf99ebab"), true, "Oil change", 50.00m },
                    { new Guid("237a7a16-4230-42c1-a88b-68bdca61d3a3"), true, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "IsActive", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("27d2c681-c3b1-40e7-a7eb-ebc4e9b26dc3"), true, "Ivan", "0888123456", "Ivanov" },
                    { new Guid("3f7fe907-1b59-4675-9516-b0d6da6783f3"), true, "Petar", "0888123457", "Petrov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "IsActive", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("94863fbc-a1c7-4043-a700-b581bbc36b65"), true, "Handbrake cable", "G40.36415/C", 65.00m },
                    { new Guid("e083be9e-9269-4ae4-87c3-c272a775da68"), true, "Wishbone", "G40.3613/C", 70.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "IsActive", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("27fe0c8d-859a-4093-8b3f-f4197dee28ed"), null, null, "12345678", "Gasoline", true, "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" },
                    { new Guid("a8f8bc9d-50ee-43dd-8e97-a9f9df0b9805"), null, null, "12345679", "Gasoline", true, "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" }
                });
        }
    }
}
