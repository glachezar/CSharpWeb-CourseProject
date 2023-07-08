using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGarage.Data.Models;

namespace MyGarage.Data.Configurations
{


    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(GenerateVehicle());
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
                EngineNumber = "5GZCZ33D03S835560",
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
                EngineNumber = "JN6MD06S2BW031939",
                YearManufactured = "2013",
                FuelType = "Gasoline",
                Mileage = "123654",
                RegNumber = "BT2525BT"
            };
            vehicles.Add(vehicle);




            return vehicles.ToArray();
        }
    }
}
