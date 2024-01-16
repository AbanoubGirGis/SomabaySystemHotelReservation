using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace HostelReservation.Classes
{
    public class Reservation : IBaseInterface
    {
        public DateTime ReservationCheckIn { get; set; }
        public DateTime ReservationCheckOut { get; set; }
        public int RoomID { get; set; }
        public int CustomerID { get; set; }


        public void Create(object obj)
        {
            Reservation reservation = new Reservation();
            reservation = (Reservation)obj;

            Reservation re = new Reservation();
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Somabay;Integrated Security=True"))
            {

                bool isConnectionOpen = (connection.State == System.Data.ConnectionState.Open);
                reservation.RoomID = RoomID;
                reservation.CustomerID = CustomerID;
                reservation.ReservationCheckIn = ReservationCheckIn;
                reservation.ReservationCheckOut = ReservationCheckOut;

                string insertQuery = "INSERT INTO Reservation VALUES (@ReservationCheckIn, @ReservationCheckOut, @RoomID, @CustomerID);UPDATE Room SET RoomStatus = 'U' WHERE RoomID = @RoomID; ";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ReservationCheckIn", ReservationCheckIn);
                    command.Parameters.AddWithValue("@ReservationCheckOut", ReservationCheckOut);
                    command.Parameters.AddWithValue("@RoomID", RoomID);
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(object DeleteObj)
        {
            throw new NotImplementedException();
        }

        public void Read(object ReadObj)
        {
            throw new NotImplementedException();
        }

        public void Update(object UpdateObj)
        {
            throw new NotImplementedException();
        }
    }
}
