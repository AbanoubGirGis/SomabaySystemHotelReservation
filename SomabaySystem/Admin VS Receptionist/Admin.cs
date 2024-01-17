using HostelReservation;
using HostelReservation.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomabaySystem.Admin_VS_Receptionist
{
    internal class Admin
    {
        public void AdminOptions()
        {
            Console.WriteLine("How can I help you today?");
            Console.WriteLine();

            Console.WriteLine("1..Hotels");
            Console.WriteLine("2..Rooms");
            Console.WriteLine("3..Customers");
            Console.WriteLine("4..Reservations");
            Console.WriteLine("5..Billing");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            AdminOption adminOption = (AdminOption)int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("*** -- *** -- ***");
            switch (adminOption)
            {
                case AdminOption.Hotels:
                    HotelDisplay();
                    break;

                case AdminOption.Rooms:
                    RoomDisplay();
                    break;

                case AdminOption.Customers:
                    CustomerDisplay();
                    break;

                case AdminOption.Reservation:
                    break;

                case AdminOption.Billing:
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    break;
            }
        }
        void HotelDisplay()
        {
            Console.WriteLine("Welcome to Hotels: ");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.WriteLine("1..Show All Hotels.");
            Console.WriteLine("2..Create New Hotel.");
            Console.WriteLine("3..Update Hotel.");
            Console.WriteLine("4..Delete Hotel");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option hotelOption = (Option)int.Parse(Console.ReadLine());
            switch (hotelOption)
            {
                case Option.Read:
                    function.SelectHotels();
                    break;

                case Option.Create:
                    function.CreateHotels();
                    break;

                case Option.Update:
                    function.UpdateeHotels();
                    break;

                case Option.Delete:
                    function.DeleteeHotels();
                    break;
            }
        }
        void RoomDisplay()
        {
            Console.WriteLine("Welcome to Rooms: ");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.WriteLine("1..Show All Rooms.");
            Console.WriteLine("2..Create New Room.");
            Console.WriteLine("3..Update Room.");
            Console.WriteLine("4..Delete Room");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option roomOption = (Option)int.Parse(Console.ReadLine());
            switch (roomOption)
            {
                case Option.Read:
                    function.ReadroomOperation();
                    break;

                case Option.Create:
                    function.CreateRoomOperation();
                    break;

                case Option.Update:
                    function.UpdateRoomOperation();
                    break;

                case Option.Delete:
                    function.DeleteRoomOpertion();
                    break;
            }
        }
        void CustomerDisplay()
        {
            Console.WriteLine("Welcome to Customers: ");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.WriteLine("1..Show All Customers.");
            Console.WriteLine("2..Create New Customer.");
            Console.WriteLine("3..Update Customers.");
            Console.WriteLine("4..Delete Customers");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option CustomerOption = (Option)int.Parse(Console.ReadLine());
            switch (CustomerOption)
            {
                case Option.Read:
                    function.SelectCustomer();
                    break;

                case Option.Create:
                    function.CreateCustomer();
                    break;

                case Option.Update:
                    function.UpdateCustomer();
                    break;

                case Option.Delete:
                    function.DeleteCustomer();
                    break;
            }
        }
    }
}
