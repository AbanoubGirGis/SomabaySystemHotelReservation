using SomabaySystem.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation.Classes
{
    internal class Function
    {
        #region customer functions

        public void CreateCustomer()
        {
            Customer customer = new Customer();
            Console.Write("Enter Customer Name: ");
            customer.FullName = Console.ReadLine();
            Console.Write("Enter Customer City: ");
            customer.City = Console.ReadLine();
            Console.Write("Enter Customer Phone Number: ");
            customer.Phonenumber = Console.ReadLine();
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
            customer.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            customer.FullName = Console.ReadLine();
            Console.Write("Enter Customer City: ");
            customer.City = Console.ReadLine();
            Console.Write("Enter Customer Phone Number: ");
            customer.Phonenumber = Console.ReadLine();
            customer.Update(customer);
        }
        public void DeleteCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("enter the customer id ");
            customer.ID = int.Parse(Console.ReadLine());
            customer.Delete(customer);
        }


        #endregion

        #region Rooms Functions
        public void CreateRoomOperation()
        {
            Rooms rooms = new Rooms();
            Console.Write("Enter Number Of Beds: ");
            rooms.NumberBeds = int.Parse(Console.ReadLine());

            Console.Write("Enter Rates Of Room: ");
            rooms.RatesRooms = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Number Of Hotel: ");
            rooms.HotelId = int.Parse(Console.ReadLine());
            //if (!DBconnection.CheckPkExists(rooms.HotelId))
            //    Console.WriteLine("Incorect Hotel Id");

            rooms.Create(rooms);
            Console.WriteLine("\n*** -- ** Succusfully ** -- ***\n");
        }

        public void ReadroomOperation()
        {
            Rooms room = new Rooms();
            Console.Write("Enter Hotel Number: ");
            room.HotelId = int.Parse(Console.ReadLine());
            room.Read(room);
        }

        public void DeleteRoomOpertion()
        {
            Rooms room = new Rooms();
            Console.Write("Enter Hotel Number: ");
            room.HotelId = int.Parse(Console.ReadLine());
            Console.Write("Enter Room Number: ");
            room.RoomId = int.Parse(Console.ReadLine());
            room.Delete(room);
        }

        public void UpdateRoomOperation()
        {
            Rooms room = new Rooms();
            Console.Write("Enter Room Number: ");
            room.RoomId = int.Parse(Console.ReadLine());
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
            h.Name = Console.ReadLine();
            Console.Write("Enter ZipCode of hotels : ");
            h.ZipCode = int.Parse(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            h.PhoneNumber = Console.ReadLine();
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

            if (FunctionsValidation.DoesHotelExistValdition(H.ID))
            {
                Console.WriteLine("Enter The Hotel name");
                H.Name = Console.ReadLine();
                Console.WriteLine("enter the hotel phone");
                H.PhoneNumber = Console.ReadLine();
                Console.WriteLine("enter the hotel zipcode");
                H.ZipCode = int.Parse(Console.ReadLine());
                H.Update(H);
            }
            else { Console.WriteLine("NOT existed"); }


        }

        public void deleteeHotels()
        {
            Hotels H = new Hotels();
            Console.WriteLine("Enter Hotels ID to delete it: ");
            H.ID = int.Parse(Console.ReadLine());
            if (FunctionsValidation.DoesHotelExistValdition(H.ID))
            {
                H.Delete(H);
                Console.WriteLine("Deleted Succefully");
            }
            else { Console.WriteLine("NOT existed"); }

        }

        #endregion

        #region Reservation Function

        #endregion
    }
}
