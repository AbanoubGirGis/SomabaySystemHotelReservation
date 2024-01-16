using ConsoleTables;
using System.Data.SqlClient;
namespace HostelReservation.Classes
{

    public class Hotels : IBaseInterface
    {
        //test
        private static int HotelId;
        private static string HotelName;
        private static string HotelPhone;
        private static int HotelZipCode;



        public int ID { get { return HotelId; } set { HotelId = value; } }
        public string Name { get { return HotelName; } set { HotelName = value; } }
        public int ZipCode { get { return HotelZipCode; } set { HotelZipCode = value; } }
        public string PhoneNumber { get { return HotelPhone; } set { HotelPhone = value; } }


        //public static void InputHotelsInfo()
        //{


        //    Console.Write("Enter Hotel Name: ");
        //    HotelName = Console.ReadLine();
        //    Console.Write("Enter ZipCode of hotels : ");
        //    HotelZipCode = int.Parse(Console.ReadLine());
        //    Console.Write("Enter Phone Number: ");
        //    HotelPhoneNumber = int.Parse(Console.ReadLine());

        //}

        //public static void AddHotels()
        //{
        //    OpenConnection();
        //    InputHotelsInfo();//InputHotelsInfo()
        //    string addHotelsQuery = "insert into Hotel " +
        //       "values('" + HoteslID + "', '" + HotelName + "', " +
        //       "'" + HotelZipCode + "', '" + HotelPhoneNumber + "')";

        //    int ctr = ExecuteQueries(addHotelsQuery);
        //    if (ctr > 0)
        //        Console.WriteLine("\nNew Hotel added....\n");
        //    CloseConnection();
        //}

        



        //public static void ShowAllHotels()
        //{

        //    //OpenConnection();
        //    Console.WriteLine("\n \n \t \t \t \t \t \t \t***** --- **** SHOWING ALL Hotels ***** --- ****\n");
        //    string[] val;
        //    var table = new ConsoleTable("Hotel ID", "Hotel Name", "Phone Number", "ZipCode");
        //    string showAllHotels = "select * from Hotel";
        //    ExecuteQueries(showAllHotels);
        //    SqlDataReader reader = DataReader(showAllHotels);
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            val = new string[reader.FieldCount];
        //            for (int i = 0; i < reader.FieldCount; i++)
        //                val[i] = Convert.ToString(reader.GetValue(i));
        //            table.AddRow(val[0], val[1], val[2], val[3]);
        //        }
        //        table.Write();
        //        Console.WriteLine();
        //    }
        //    else
        //        Console.WriteLine("No Records available in the database....\n");
        //    //CloseConnection();
        //}

        //public static void UpdateHotelsByID(int HotelsID)
        //{
        //    if (CheckPkExists(HotelsID))
        //    {
        //        GetHotelsDetails(HotelsID);
        //        InputHotelsInfo();
        //        OpenConnection();
        //        string updateHotelsbyId = "update Hotels set City = '" + HotelName + "', zipcode = " +
        //                     "'" + HotelZipCode + "',[phone number] = '" + HotelPhoneNumber + "' where [hotel id] = '" + HotelsID + "'";
        //        ExecuteQueries(updateHotelsbyId);
        //        Console.WriteLine("\nHotels id: {0} updated sucessfully....\n", HotelsID);
        //        CloseConnection();
        //    }
        //    else
        //        Console.WriteLine("\nHotels id: {0} does not exist in database....\n", HotelsID);
        //}

        //public static void GetHotelsDetails(int HotelsID)
        //{
        //    OpenConnection();
        //    string[] val;
        //    string getBookDetails = "select [hotel id], City, zipcode, [phone number] FROM Hotels where [hotel id] = " +
        //                 "'" + HotelsID + "'";
        //    SqlDataReader reader = DataReader(getBookDetails);
        //    if (reader.HasRows)
        //    {
        //        val = new string[reader.FieldCount];
        //        while (reader.Read())
        //        {
        //            for (int i = 0; i < reader.FieldCount; i++)
        //                val[i] = Convert.ToString(reader.GetValue(i));
        //        }
        //        Console.WriteLine("\nCity: {0}", val[0]);
        //        Console.WriteLine("Code: {0}", val[1]);
        //        Console.WriteLine("PhoneNumber No.: {0}", val[2]);
        //        Console.WriteLine("Name No.: {0}", val[3]);

        //    }
        //    else
        //        Console.WriteLine("\nHotels id: {0} not availabe in the database....\n", HotelsID);
        //    CloseConnection();
        //}

        public static void ShowHotelsCount()
        {
            Console.WriteLine("Available Hotels: {0}\n", CountRecords().ToString());
        }

        public void Create(object CreateObj)
        {
            Hotels hotels = new Hotels();
            hotels = (Hotels)CreateObj;


            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();

                string addhotelQuery = "INSERT INTO Hotel  VALUES (@HotelName, @HotelPhone, @HotelZipCode); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(addhotelQuery, con))
                {
                    command.Parameters.AddWithValue("@HotelName", hotels.Name);
                    command.Parameters.AddWithValue("@HotelPhone", hotels.PhoneNumber);
                    command.Parameters.AddWithValue("@HotelZipCode", hotels.ZipCode);

                    int hotelsId = Convert.ToInt32(command.ExecuteScalar());

                }
            }
        }

        public void Read(object ReadObj)
        {
            string[] val;
            var table = new ConsoleTable("Hotel ID", "Hotel Name", "Phone Number", "ZipCode");
            string showAllHotels = "select * from Hotel";
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();
                string selectHotel = "select * from Hotel";
                using (SqlCommand command = new SqlCommand(showAllHotels, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            val = new string[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                                val[i] = Convert.ToString(reader.GetValue(i));
                            table.AddRow(val[0], val[1], val[2], val[3]);
                        }
                        table.Write();
                        Console.WriteLine();
                    }
                    else { Console.WriteLine("NO rows existed"); }
                }
                con.Close();
            }
        }

        public void Update(object UpdateObj)
        {
            Hotels hotel = new Hotels();
            hotel = (Hotels)UpdateObj;
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();

                string updatehotel = $"update Hotel set HotelName='{hotel.Name}',HotelPhone='{hotel.PhoneNumber}',HotelZipCode='{hotel.ZipCode}' where HotelId={hotel.ID}";
                using (SqlCommand command = new SqlCommand(updatehotel, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("***Updated successfull******");
                    reader.Close();
                }

                con.Close();
            }
        }

        public void Delete(object DeleteObj)
        {

            Hotels hotel = new Hotels();
            hotel = (Hotels)DeleteObj;
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();
                string deletehotel = $"delete from Hotel where HotelId={hotel.ID}";
                using (SqlCommand command = new SqlCommand(deletehotel, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("****Deleted successfull******");
                }
                con.Close();
            }
        }
    }
}
