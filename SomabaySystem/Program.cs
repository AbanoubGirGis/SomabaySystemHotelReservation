﻿using System.Data.SqlClient;
using HostelReservation.Classes;
using SomabaySystem;
namespace HostelReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("\t \t \t \t  ***** --- ***** --- ***** --- ***** Welcome to Soma Pay ***** --- ***** --- ***** --- *****");
            Console.WriteLine("\n\n");
            string textToEnter ="***** --- ***** --- ***** --- ***** Welcome to Soma Pay ***** --- ***** --- ***** --- *****";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.WriteLine("\n\n\n\n\n");

            Admin admin = new Admin();
            admin.AdminMethod();
        }
    }
}
