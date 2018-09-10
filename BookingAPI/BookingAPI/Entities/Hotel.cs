using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAPI.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool IsBooked { get; set; }
        public bool IsSaved { get; set; }

    }
}