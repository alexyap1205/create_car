using System;

namespace combined.Models
{
    public class Vehicle
    {
        public Guid Id { get; }
        
        public VehicleType VehicleType { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public Vehicle(VehicleType type, string make, string model)
        {
            Id = new Guid();
            VehicleType = type;
            Make = make;
            Model = model;
        }
    }
}