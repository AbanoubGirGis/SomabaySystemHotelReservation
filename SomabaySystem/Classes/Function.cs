using SomabaySystem.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation.Classes
{
    public class Function
    {
        #region customer functions

        public void CreateCustomer()
        {
            Customer customer = new Customer();
            Console.Write("Enter Customer Name: ");
            customer.FullName = Console.ReadLine()!;
            Console.Write("Enter Customer City: ");
            customer.City = Console.ReadLine()!;
            Console.Write("Enter Customer Phone Number: ");
            customer.Phonenumber = Console.ReadLine()!;
            Console.WriteLine(" *** -- Saved Sucessfuly -- ***");
            customer.Create(customer);
        }
        public void SelectCustomer()
        {
            Customer customer = new Customer();
            customer.Read(customer);
        }
        public void UpdateCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("enter the customer Id ");
            customer.ID = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Customer Name: ");
            customer.FullName = Console.ReadLine()!;
            Console.Write("Enter Customer City: ");
            customer.City = Console.ReadLine()!;
            Console.Write("Enter Customer Phone Number: ");
            customer.Phonenumber = Console.ReadLine()!;
            customer.Update(customer);
        }
        public void DeleteCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("enter the customer id ");
            customer.ID = int.Parse(Console.ReadLine()!);
            customer.Delete(customer);
        }


        #endregion

        #region Rooms Functions
        public void CreateRoomOperation()
        {
            Rooms rooms = new Rooms();
            Console.Write("Enter Number Of Beds: ");
            rooms.NumberBeds = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Rates Of Room: ");
            rooms.RatesRooms = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter Number Of Hotel: ");
            rooms.HotelId = int.Parse(Console.ReadLine()!);
            //if (!DBconnection.CheckPkExists(rooms.HotelId))
            //    Console.WriteLine("Incorect Hotel Id");

            rooms.Create(rooms);
            Console.WriteLine("\n*** -- ** Succusfully ** -- ***\n");
        }

        public void ReadroomOperation()
        {
            Rooms room = new Rooms();
            Console.Write("Enter Hotel Number: ");
            room.HotelId = int.Parse(Console.ReadLine()!);
            room.Read(room);
        }

        public void DeleteRoomOpertion()
        {
            Rooms room = new Rooms();
            Console.Write("Enter Hotel Number: ");
            room.HotelId = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Room Number: ");
            room.RoomId = int.Parse(Console.ReadLine()!);
            room.Delete(room);
        }

        public void UpdateRoomOperation()
        {
            Rooms room = new Rooms();
            Console.Write("Enter Room Number: ");
            room.RoomId = int.Parse(Console.ReadLine()!);
            //if (DBconnection.CheckPkRoomExists(room.RoomId))
            //{
            //    Console.Write("Enter Number Of Beds: ");
            //    room.NumberBeds = int.Parse(Console.ReadLine());

            //    Console.Write("Enter Rates Of Room: ");
            //    room.RatesRooms = decimal.Parse(Console.ReadLine());

            //    Console.Write("Enter Number Of Hotel: ");
            //    room.HotelId = int.Parse(Console.ReadLine());
            //    if (!DBconnection.CheckPkExists(room.HotelId))
            //        Console.WriteLine("Incorect Hotel Id");
            //    room.Update(room);
            //}
            //else
            //    Console.WriteLine("\nRoom id: {0} does not exist in database....\n", room.RoomId);

        }
        #endregion

        #region Hotel Functions
        public void CreateHotels()
        {
            Hotels h = new Hotels();
           
            Console.Write("Enter Hotel Name: ");
            h.Name = Console.ReadLine()!;
            Console.Write("Enter ZipCode of hotels : ");
            h.ZipCode = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Phone Number: ");
            h.PhoneNumber = Console.ReadLine()!;
            Console.WriteLine(" *** -- Saved Sucessfuly -- ***");
            h.Create(h);
        }

        public void SelectHotels()
        {
            Hotels hotels = new Hotels();
            hotels.Read(hotels);
        }

        public void UpdateeHotels()
        {
            Hotels H = new Hotels();
            Console.WriteLine("Enter The Hotel Id");
            H.ID = FunctionsValidation.ValidationID();

            FunctionsValidation.ValidationID();
            if (FunctionsValidation.DoesHotelExistValdition(H.ID))
            {
                Console.WriteLine("Enter The Hotel name");
                H.Name = Console.ReadLine()!;
                Console.WriteLine("enter the hotel phone");
                H.PhoneNumber = Console.ReadLine()!;
                Console.WriteLine("enter the hotel zipcode");
                H.ZipCode = int.Parse(Console.ReadLine()!);
                H.Update(H);
            }
            else { Console.WriteLine("NOT existed"); }


        }

        public void deleteeHotels()
        {
            Hotels H = new Hotels();
            Console.WriteLine("Enter Hotels ID to delete it: ");
            H.ID = int.Parse(Console.ReadLine()!);
            if (FunctionsValidation.DoesHotelExistValdition(H.ID))
            {
                H.Delete(H);
                Console.WriteLine("Deleted Succefully");
            }
            else { Console.WriteLine("NOT existed"); }

        }

        #endregion

        #region Reservation Function
        public  static void createReservation() 
        {
            Reservation R = new Reservation();
            Console.Write("Enter ID: ");
             R.RoomID= FunctionsValidation.ValidationID();
            Console.Write("Enter Customer Id ");
            R.CustomerID = FunctionsValidation.ValidationID();
            Console.Write("Enter CheckIn ");
            string checkIn = Console.ReadLine();
            FunctionsValidation.CheckinValid(checkIn);
            if (DateTime.TryParse(checkIn, out DateTime dateValue))
            R.ReservationCheckIn = dateValue;
            Console.Write("Enter CheckOut ");
            string checkOut = Console.ReadLine();
            FunctionsValidation.CheckoutValid(checkIn, checkOut);
            if (DateTime.TryParse(checkIn, out DateTime dateValue1))
            R.ReservationCheckOut = dateValue1;
            R.Create(R);
            Console.WriteLine(" *** -- Saved Sucessfuly -- ***");
        }
        

        public   static void SelectReservation() //select all data from reservation and customer name 
        {
            Reservation  Res = new Reservation();
            Res.Read(Res);
        } 


        public static void SelectResverationId()  //this function to get data for reservation for specicific  customer id 
        {
            Reservation re= new Reservation();  
            Console.WriteLine("Enter the customer id ");
            int id = int.Parse(Console.ReadLine());
            re.ReadId(id);
        }

        public static void UpdateReservation()
        {
            Reservation R = new Reservation();
            Console.WriteLine("Enter The reservation Id");
            R.ReservationId = int.Parse(Console.ReadLine());
            FunctionsValidation.ValidationID(R.ReservationId);
            Console.WriteLine("Enter The roome Id ");
            R.RoomID = int.Parse(Console.ReadLine());
            FunctionsValidation.ValidationID(R.RoomID);
            Console.WriteLine("Enter check in ");
            string? s = Console.ReadLine();


            Console.WriteLine("Enter The check out");
            string checkout = Console.ReadLine();
            FunctionsValidation.CheckinValid(time);
            Console.WriteLine("enter the hotel phone");
            R.CustomerID = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the hotel zipcode");
            H.ZipCode = int.Parse(Console.ReadLine());

        }
        #endregion
    }
}
