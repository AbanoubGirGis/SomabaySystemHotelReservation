using HostelReservation;
using SomabaySystem.Admin_VS_Receptionist;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomabaySystem
{
    internal class Welcome
    {
        public void WelcomeMethod()
        {
            string Login = "Login...";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Login.Length / 2)) + "}", Login));
            Console.WriteLine("\n\n");

            Console.Write("\t \t \t \t Enter username:");
            string? username = Console.ReadLine();

            Console.Write("\t \t \t \t Enter password: ");
            string password = ReadPassword();

            bool isAdmin = CheckCredentials(username, password);
            bool isReseption = CheckCredentialsToReseption(username, password);
            if (isAdmin)
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                string LoginSuccessfully = "Login successful!";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (LoginSuccessfully.Length / 2)) + "}", LoginSuccessfully));
                
                Console.WriteLine("\n");
                String Welcome = $"Welcome to Somabay System Admin: {username}";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Welcome.Length / 2)) + "}", Welcome));
                Admin admin = new Admin();
                admin.AdminOptions();
            }
            else if (isReseption)
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                string LoginSuccessfully = "Login successful!";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (LoginSuccessfully.Length / 2)) + "}", LoginSuccessfully));

                Console.WriteLine("\n");
                String Welcome = $"Welcome to Somabay System Receptionist: {username}";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Welcome.Length / 2)) + "}", Welcome));
                Reseption reseption = new Reseption();
                reseption.ReseptionOptions();
            }
            else
            {
                Console.WriteLine("\n\n");
                string faild = "Invalid username or password. Login failed.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (faild.Length / 2)) + "}", faild));
            }
        }

        string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (char.IsControl(key.KeyChar))
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(); 
            return password;
        }

        bool CheckCredentials(string username, string password)
        {
            int newPass;
            newPass = Convert.ToInt32(password);
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();

                string query = $"SELECT COUNT(*) FROM Login WHERE Username = @username AND Password = @password and Type = 'Admin'";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", newPass);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        bool CheckCredentialsToReseption(string username, string password)
        {
            int newPass;
            newPass = Convert.ToInt32(password);
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();

                string query = $"SELECT COUNT(*) FROM Login WHERE Username = @username AND Password = @password and Type = 'reseption'";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", newPass);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

    }
    
}
