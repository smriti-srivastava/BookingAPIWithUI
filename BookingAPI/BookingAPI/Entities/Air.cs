using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAPI.Entities
{
    public class Air
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Duration { get; set; }
        public bool IsBooked { get; set; }
        public bool IsSaved { get; set; }
    }
}