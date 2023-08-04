
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarage.Data.Migrations
{
    public partial class FixForDateTimeWhenCreatingJobCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 3, 8, 53, 46, 448, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Egn", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("1c0dbee2-8a68-4983-9b87-5d8de1fcfe47"), null, null, null, "Peshov@mcg.bg", "Pesho", "0888100200", "Peshov" },
                    { new Guid("2bf3f0fd-5e63-495a-b588-e7549dd3359f"), null, null, null, "Martinov@mcg.bg", "Martin", "0888100100", "Martinov" },
                    { new Guid("64b29285-8ad3-449a-ace7-78308e8ba857"), null, null, null, "Ivanov@mcg.bg", "Ivan", "0888100200", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "IsActive", "JobName", "Price" },
                values: new object[,]
                {
                    { new Guid("152519f7-4a6d-44d0-9cf0-d71b1c921557"), true, "Oil change", 50.00m },
                    { new Guid("d430969c-c809-4c39-b3da-908ccca51b4d"), true, "Tyre replacement", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "IsActive", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("27d6e4c1-c8cb-43bf-a70e-d6307f67a0a9"), true, "Ivan", "0888123456", "Ivanov" },
                    { new Guid("7e6ed7c2-957f-4832-8dee-14ee6c65a466"), true, "Petar", "0888123457", "Petrov" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "IsActive", "PartName", "PartNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("7c0cde43-4b28-4035-afb5-de5e4ffa30e5"), true, "Wishbone", "G40.3613/C", 70.00m },
                    { new Guid("e04cf186-1ea7-4daf-acd1-6d7c1a58eb14"), true, "Handbrake cable", "G40.36415/C", 65.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "EngineNumber", "FuelType", "IsActive", "Make", "Mileage", "Model", "RegNumber", "Vin", "YearManufactured" },
                values: new object[,]
                {
                    { new Guid("c7f5a05b-8cac-4fa3-9427-f6f0a6ff91d8"), null, null, "12345679", "Gasoline", true, "Hyundai", "123654", "Sonata", "BT2525BT", "5NPEB4AC8DH617686", "2013" },
                    { new Guid("edcdc088-a55f-475d-bc99-18c76124157d"), null, null, "12345678", "Gasoline", true, "Acura", "354123", "Legend", "CA2525CB", "JH4KA2532HC022031", "1987" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("1c0dbee2-8a68-4983-9b87-5d8de1fcfe47"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("2bf3f0fd-5e63-495a-b588-e7549dd3359f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("64b29285-8ad3-449a-ace7-78308e8ba857"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("152519f7-4a6d-44d0-9cf0-d71b1c921557"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("d430969c-c809-4c39-b3da-908ccca51b4d"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("27d6e4c1-c8cb-43bf-a70e-d6307f67a0a9"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("7e6ed7c2-957f-4832-8dee-14ee6c65a466"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("7c0cde43-4b28-4035-afb5-de5e4ffa30e5"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("e04cf186-1ea7-4daf-acd1-6d7c1a58eb14"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("c7f5a05b-8cac-4fa3-9427-f6f0a6ff91d8"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("edcdc088-a55f-475d-bc99-18c76124157d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 8, 53, 46, 448, DateTimeKind.Utc).AddTicks(6419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

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
    }
}
