﻿using System.ComponentModel.DataAnnotations;

namespace CarListApp.Api
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } // brand of the car
        public string Model { get; set; }
        public string Vin { get; set; } // Vehicle Identification Number
    }
}