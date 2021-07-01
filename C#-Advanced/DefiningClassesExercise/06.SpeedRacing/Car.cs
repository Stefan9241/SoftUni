namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double Consumption { get; set; }
        public double Distance { get; set; }

        public Car(string model, double fuel, double consumption)
        {
            Model = model;
            FuelAmount = fuel;
            Consumption = consumption;
            Distance = 0;
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * Consumption;
            if (fuelNeeded <= FuelAmount)
            {
                FuelAmount -= fuelNeeded;
                Distance += distance;
            }
            else
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
