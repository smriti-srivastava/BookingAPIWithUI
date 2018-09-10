using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAPI.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Place { get; set; }
        public float Price { get; set; }
        public bool IsBooked { get; set; }
        public bool IsSaved { get; set; }
    }
}