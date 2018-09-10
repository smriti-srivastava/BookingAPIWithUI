using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.Service
{
    interface IProductTotalFareStrategy
    {
        float GetTotalFare(float fare);
    }
}
