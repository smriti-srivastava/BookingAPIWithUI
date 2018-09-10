using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAPI.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public bool IsBooked { get; set; }
        public bool IsSaved { get; set; }

    }
}