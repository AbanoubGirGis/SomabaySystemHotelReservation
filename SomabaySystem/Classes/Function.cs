using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation.Classes
{
    internal class Function
    {
        //customer functions
        #region customer functions

        public Customer createcustomer()
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
            return customer;
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
    }
}
