namespace combined.Models
{
    public class Car : Vehicle
    {
        public Car(VehicleType type, string make, string model) : base(type, make, model)
        {
        }

        public int Doors { get; set; }

        public string Engine { get; set; }

        public int Wheels { get; set; }

        public string BodyType { get; set; }
    }
}