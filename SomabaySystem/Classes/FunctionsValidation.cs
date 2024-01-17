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
            if((year >= dateTime.Year) && (int.Parse(date.Split('/')[1])>=month) && (day >= dateTime.Day))
                return true;
            return false;
        }
        #endregion
    }
}
