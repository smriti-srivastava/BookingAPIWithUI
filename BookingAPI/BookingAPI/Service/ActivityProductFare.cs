using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAPI.Service
{
    public class ActivityProductFare:IProductTotalFareStrategy
    {
        public float GetTotalFare(float fare)
        {
            return fare + (fare * 0.1F);
        }
    }
}