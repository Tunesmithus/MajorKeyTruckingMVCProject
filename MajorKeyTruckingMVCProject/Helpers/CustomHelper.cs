using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Helpers
{
    public static class CustomHelper
    {
        public static decimal RatePerMile(decimal loadedMiles, decimal unloadedMiles, decimal loadPay)
        {
            decimal result = 0;
            if (unloadedMiles == 0)
            {
                result = loadPay / loadedMiles;
            }

            else
            {
               result =  loadPay / (unloadedMiles + loadedMiles);
            }

            return result;
        }
    }
}
