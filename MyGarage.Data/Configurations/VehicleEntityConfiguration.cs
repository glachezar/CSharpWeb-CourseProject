namespace MyGarage.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;


    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
                .HasData(GenerateVehicle());

            builder
                .HasOne(v => v.Customer)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        private Vehicle[] GenerateVehicle()
        {
            ICollection<Vehicle> vehicles = new HashSet<Vehicle>();

            Vehicle vehicle;

            vehicle = new Vehicle()
            {
                Make = "Acura",
                Model = "Legend",
                Vin = "JH4KA2532HC022031",
                EngineNumber = "12345678",
                YearManufactured = "1987",
                FuelType = "Gasoline",
                Mileage = "354123",
                RegNumber = "CA2525CB"

            };
            vehicles.Add(vehicle);

            vehicle = new Vehicle()
            {
                Make = "Hyundai",
                Model = "Sonata",
                Vin = "5NPEB4AC8DH617686",
                EngineNumber = "12345679",
                YearManufactured = "2013",
                FuelType = "Gasoline",
                Mileage = "123654",
                RegNumber = "BT2525BT",
                //CustomerId = Guid.Parse("1542b9ce-decd-4028-8b7d-c6e5ca5f64f7")
            };
            vehicles.Add(vehicle);




            return vehicles.ToArray();
        }
    }
}
