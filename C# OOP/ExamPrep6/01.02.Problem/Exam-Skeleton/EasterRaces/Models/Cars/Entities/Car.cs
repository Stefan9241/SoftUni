﻿using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHp;
        private int maxHp;
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            minHp = minHorsePower;
            maxHp = maxHorsePower;
            HorsePower = horsePower;
            Model = model;
            CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => model;
            private set
            {
                if (value.Length < 4 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                model = value;
            }
        }
        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value > maxHp || value < minHp)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
