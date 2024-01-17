using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomabaySystem.Classes
{
    internal class FunctionsValidation
    {
        #region checkinValidation
        public static bool CheckinValid(string date)
        {
            DateTime dateTime = DateTime.Now;
            int day = int.Parse(date.Split('/')[0]);
            int month = int.Parse(date.Split("/")[1]);
            int year = int.Parse(date.Split("/")[2]);
            if((year >= dateTime.Year) && (month >=dateTime.Month) && (day >= dateTime.Day))
                return true;
            return false;
        }
        public static bool CheckoutValid(string date,string checkin)
        {
            
            int day = int.Parse(date.Split('/')[0]);
            int month = int.Parse(date.Split("/")[1]);
            int year = int.Parse(date.Split("/")[2]);

            int dayOut = int.Parse(checkin.Split('/')[0]);
            int monthOut = int.Parse(checkin.Split("/")[1]);
            int yearOut = int.Parse(checkin.Split("/")[2]);
            if ((yearOut >=year ) && (monthOut >= month) && (dayOut >= day))
                return true;
            return false;
        }
        #endregion
    }
}
