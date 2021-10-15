using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private readonly List<Car> data;

        public Parking(string type,int capacity)
        {
            this.data = new List<Car>();
            Type = type;
            Capacity = capacity;
        }
        public string Type { get;private  set; }
        public int Capacity { get;private  set; }
        public int Count => data.Count;

        public void Add(Car car)
        {
            if (Count + 1 <= Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (car != null)
            {
                data.Remove(car);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            if (data.Count > 0)
            {
                Car car = data.OrderByDescending(x => x.Year).First();
                return car;
            }
            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return car;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }
}
