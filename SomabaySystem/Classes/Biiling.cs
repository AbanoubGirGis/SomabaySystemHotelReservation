using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace HostelReservation.Classes
{
    class Bill
    {
        public int BillingId { get; set; }
        public int CustomerId { get; set; }
        public int DaysNumber { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal Deposit { get; set; }

        public Bill(int billingId, int customerId, int daysNumber, decimal roomCharge, decimal deposit)
        {
            BillingId = billingId;
            CustomerId = customerId;
            DaysNumber = daysNumber;
            RoomCharge = roomCharge;
            Deposit = deposit;
        }
        public void Create()
        {
            string connectionString = "Data Source=.;Initial Catalog=Somabay;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Bill (CustomerId, DaysNumber, RoomCharge, Deposit) VALUES (@CustomerId, @DaysNumber, @RoomCharge, @Deposit)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@DaysNumber", DaysNumber);
                    command.Parameters.AddWithValue("@RoomCharge", RoomCharge);
                    command.Parameters.AddWithValue("@Deposit", Deposit);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void UpdateBill()
        {
            string connectionString = "Data Source=.;Initial Catalog=Somabay;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Bill SET CustomerId = @CustomerId, DaysNumber = @DaysNumber, RoomCharge = @RoomCharge, Deposit = @Deposit WHERE BillingId = @BillingId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BillingId", BillingId);
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@DaysNumber", DaysNumber);
                    command.Parameters.AddWithValue("@RoomCharge", RoomCharge);
                    command.Parameters.AddWithValue("@Deposit", Deposit);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void DeleteBill()
        {
            string connectionString = "Data Source=.;Initial Catalog=Somabay;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Bill WHERE BillingId = @BillingId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BillingId", BillingId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
