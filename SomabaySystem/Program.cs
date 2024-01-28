﻿using System.Data.SqlClient;
using HostelReservation.Classes;
using SomabaySystem;
using SomabaySystem.Admin_VS_Receptionist;
using SomabaySystem.Classes;
namespace HostelReservation
{
    internal class Program
    {
        // هتشتغل هنا علي ده عشان متوهش 
        // Connection Abanoub Server//"Data Source=DESKTOP-MLSL318\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"   محدش يلعب فيه
        //Connection Marwan Server//"Data Source=DESKTOP-VD76OGN\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"
        public static readonly string PublicConnectionString = "Data Source=.;Initial Catalog=Somabay;Integrated Security=True";
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n");
            string textToEnter = "***** --- ***** --- ***** --- ***** Welcome to Soma Pay ***** --- ***** --- ***** --- *****";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.WriteLine("\n\n\n\n\n");

            Welcome welcome = new Welcome();
            welcome.WelcomeMethod();
        }
    }
}
