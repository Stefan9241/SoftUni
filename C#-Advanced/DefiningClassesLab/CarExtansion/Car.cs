using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQantity;
        private double fuelConsumption;

        public double FuelConsumption
        {
            set { fuelConsumption = value; }
            get { return fuelConsumption; }
        }
        public double FuelQuantity
        {
            set { fuelQantity = value; }
            get { return fuelQantity; }
        }
        public string Make
        {
            set
            { make = value; }
            get { return make; }
        }

        public string Model
        {
            set
            {
                model = value;
            }
            get
            {
                return model;
            }
        }

        public int Year
        {
            set
            {
                year = value;
            }
            get
            {
                return year;
            }
        }
        public void Drive(double distance)
        {
            bool canContinue = this.fuelQantity - (distance * this.fuelConsumption) >= 0;
            if (canContinue)
            {
                this.fuelQantity -= distance * this.fuelConsumption;
            }
            else
            {
                System.Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.make}");
            sb.AppendLine($"Model: {this.model}");
            sb.AppendLine($"Year: {this.year}");
            sb.Append($"Fuel: {this.fuelQantity:f2}");
            return sb.ToString();
        }
    }
}
