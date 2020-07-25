using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmsapp
{
    public static class Utility
    {
        public static int GetdayId(string dayValue)
        {
            int dayId = 0;
            switch (dayValue) {
                case "MON":
                    dayId = 1;
                    break;

                case "TUE":
                    dayId = 2;
                    break;

                case "WED":
                    dayId = 3;
                    break;

                case "THR":
                    dayId = 4;
                    break;

                case "FRI":
                    dayId = 5;
                    break;

                case "SAT":
                    dayId = 6;
                    break;

                case "SUN":
                    dayId = 7;
                    break;
            }

            return dayId;
        }
    }
}