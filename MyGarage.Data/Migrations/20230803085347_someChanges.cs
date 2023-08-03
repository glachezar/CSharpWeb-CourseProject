using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class someChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: new DateTime(2023, 8, 3, 8, 53, 46, 448, DateTimeKind.Utc).AddTicks(6419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 30, 21, 5, 33, 235, DateTimeKind.Utc).AddTicks(2502));

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

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("7fe870fa-c2b7-4868-8fa9-c568d4f1d986"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov" },
                    { new Guid("920ebe5e-2296-4e30-8275-f72ae04dc508"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov" },
                    { new Guid("be5f0ac1-b76b-415c-885c-a926f293c924"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "IsActive", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("2813f948-4bd7-481a-a3a4-03766fc13f4f"), true, "Oil change", 50.00m },
                    { new Guid("6f6ec6bf-d253-4d73-9aa7-a2fba42e4907"), true, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "IsActive", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("243d161f-da84-484a-aa08-55a5f44a18aa"), true, "Petar", "0888123457", "Petrov" },
                    { new Guid("aefb1d99-b762-4b2e-a96a-0b2442bcbbc5"), true, "Ivan", "0888123456", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "IsActive", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("23f83042-5b91-4aeb-88eb-dd44fbd3fe4e"), true, "Handbrake cable", "G40.36415/C", 65.00m },
                    { new Guid("2a046a0f-8347-45ca-a673-206743a789b5"), true, "Wishbone", "G40.3613/C", 70.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "IsActive", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("8ece19fc-eb8f-4e95-b3b8-01bb3e1abed6"), null, null, "12345679", "Gasoline", true, "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" },
                    { new Guid("e4f6749b-83f8-4fdf-87fa-97b0afcf625d"), null, null, "12345678", "Gasoline", true, "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("7fe870fa-c2b7-4868-8fa9-c568d4f1d986"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("920ebe5e-2296-4e30-8275-f72ae04dc508"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("be5f0ac1-b76b-415c-885c-a926f293c924"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("2813f948-4bd7-481a-a3a4-03766fc13f4f"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("6f6ec6bf-d253-4d73-9aa7-a2fba42e4907"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("243d161f-da84-484a-aa08-55a5f44a18aa"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("aefb1d99-b762-4b2e-a96a-0b2442bcbbc5"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("23f83042-5b91-4aeb-88eb-dd44fbd3fe4e"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("2a046a0f-8347-45ca-a673-206743a789b5"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("8ece19fc-eb8f-4e95-b3b8-01bb3e1abed6"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("e4f6749b-83f8-4fdf-87fa-97b0afcf625d"));

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "JobCards");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "JobCards");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 30, 21, 5, 33, 235, DateTimeKind.Utc).AddTicks(2502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 3, 8, 53, 46, 448, DateTimeKind.Utc).AddTicks(6419));

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
        }
    }
}
