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
            AdminOption adminOption = (AdminOption)int.Parse(Console.ReadLine()!);
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
                    ReservationDisplay();
                    break;

                case AdminOption.Billing:
                    BillingDisplay();
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    break;
            }
        }

        void HotelDisplay()
        {
            string textToEnter = "*** -- Welcome to Hotels -- *** ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.WriteLine();
            Console.WriteLine("1..Show All Hotels.");
            Console.WriteLine("2..Create New Hotel.");
            Console.WriteLine("3..Update Hotel.");
            Console.WriteLine("4..Delete Hotel");
            Console.WriteLine("5..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option hotelOption = (Option)int.Parse(Console.ReadLine()!);
            Console.WriteLine("*** -- *** -- ***");
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
                    function.deleteeHotels();
                    break;

                case Option.Back:
                    AdminOptions();
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    break;
            }
        }

        void RoomDisplay()
        {
            string textToEnter = "*** -- Welcome to Rooms -- *** ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.WriteLine();
            Console.WriteLine("1..Show All Rooms.");
            Console.WriteLine("2..Create New Room.");
            Console.WriteLine("3..Update Room.");
            Console.WriteLine("4..Delete Room");
            Console.WriteLine("5..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option roomOption = (Option)int.Parse(Console.ReadLine()!);
            Console.WriteLine("*** -- *** -- ***");

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

                case Option.Back:
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

            }
        }

        void CustomerDisplay()
        {
            string textToEnter = "*** -- Welcome to Customer -- *** ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.WriteLine();
            Console.WriteLine("1..Show All Customers.");
            Console.WriteLine("2..Create New Customer.");
            Console.WriteLine("3..Update Customers.");
            Console.WriteLine("4..Delete Customers");
            Console.WriteLine("5..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option CustomerOption = (Option)int.Parse(Console.ReadLine()!);
            Console.WriteLine("*** -- *** -- ***");
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

                case Option.Back:
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;
            }
        }

        void ReservationDisplay()
        {
            string textToEnter = "*** -- Welcome to Reservation -- *** ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.WriteLine();
            Console.WriteLine("1..Show All Reservations.");
            Console.WriteLine("2..Create New Reservation.");
            Console.WriteLine("3..Update Reservation.");
            Console.WriteLine("4..Delete Reservation");
            Console.WriteLine("5..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option ReservationOption = (Option)int.Parse(Console.ReadLine()!);
            Console.WriteLine("*** -- *** -- ***");
            switch (ReservationOption)
            {
                case Option.Read:
                    break;

                case Option.Create:
                    break;

                case Option.Update:
                    break;

                case Option.Delete:
                    break;

                case Option.Back:
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;
            }
        }

        void BillingDisplay()
        {
            string textToEnter = "*** -- Welcome to Billing -- *** ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.WriteLine();
            Console.WriteLine("1..Show All Billings.");
            Console.WriteLine("2..Create New Billing.");
            Console.WriteLine("3..Update Billings.");
            Console.WriteLine("4..Delete Billings.");
            Console.WriteLine("5..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option BillingOption = (Option)int.Parse(Console.ReadLine()!);
            Console.WriteLine("*** -- *** -- ***");
            switch (BillingOption)
            {
                case Option.Read:
                    break;

                case Option.Create:
                    break;

                case Option.Update:
                    break;

                case Option.Delete:
                    break;

                case Option.Back:
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;
            }
        }
    }
}
