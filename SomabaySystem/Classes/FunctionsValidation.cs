using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public static bool CheckoutValid(string date,string checkout)
        {
            
            int day = int.Parse(date.Split('/')[0]);
            int month = int.Parse(date.Split("/")[1]);
            int year = int.Parse(date.Split("/")[2]);

            int dayOut = int.Parse(checkout.Split('/')[0]);
            int monthOut = int.Parse(checkout.Split("/")[1]);
            int yearOut = int.Parse(checkout.Split("/")[2]);
            if ((yearOut >=year ) && (monthOut >= month) && (dayOut >= day))
                return true;
            return false;
        }
        #endregion

        #region Hotel id validation
        public static bool DoesHotelExistValdition(int pk)
        {
            string connectionString = "Data Source=DESKTOP-MLSL318\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT TOP 1 1 FROM Hotel WHERE HotelId = @HotelId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@HotelId", pk);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        #endregion
    }
}
