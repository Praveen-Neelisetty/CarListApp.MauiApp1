using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CarListApp.MauiApp1.Models
{
    [Table("Cars")]
    public class Car : BaseEntity
    {
        public string Make {  get; set; } // brand of the car
        public string Model { get; set; }

        [MaxLength(15), Unique]
        public string Vin { get; set; } // Vehicle Identification Number
    }
}
