﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace HostelReservation.Classes
{
    internal class Customer : IBaseInterface
    {
        //fields
        private int id;
        private static int nextId = 1;
        private string fname;
        private string fullName;
        private string city;
        private string phonenumber;
        private string zipcode;

        //props
        public int ID { get { return id; } set { id = value; } }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }


        //method
        public static int Generateid()
        {
            return nextId++;
        }
        public void CreateCustomer()
        {
            Console.Write("Enter Customer Name: ");
            FullName = Console.ReadLine();
            Console.Write("Enter Customer City: ");
            City = Console.ReadLine();
            Console.Write("Enter Customer Phone Number: ");
            Phonenumber = Console.ReadLine();
            Console.WriteLine(" *** -- Saved Sucessfuly -- ***");
        }


        public void Create(object CreateObj)
        {
            Customer customer = new Customer();
            customer = (Customer)CreateObj;


            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-VD76OGN\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();

                string addCustomerQuery = "INSERT INTO Customer  VALUES (@FullName, @City, @Phonenumber); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(addCustomerQuery, con))
                {
                    command.Parameters.AddWithValue("@FullName", customer.FullName);
                    command.Parameters.AddWithValue("@City", customer.City);
                    command.Parameters.AddWithValue("@Phonenumber", customer.phonenumber);

                    int customerId = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("Customer ID: " + customerId);
                }
            }
        }

        public void Read(object ReadObj)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-VD76OGN\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();
                string selectCustoers = "select *from Customer";
                using (SqlCommand command = new SqlCommand(selectCustoers, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int customerid = reader.GetInt32(0);
                            string fullname = reader.GetString(1);
                            string city = reader.GetString(2);
                            string phonenumber = reader.GetString(3);
                            Console.WriteLine($"the customer id is {customerid}" +
                                $" ,Name = {fullname} ," +
                                $" city = {city} ," +
                                $"phone number = {phonenumber}");
                        }
                    }
                    else { Console.WriteLine("NO rows existed"); }
                }
                con.Close();
            }


        }




        public void Update(object UpdateObj)
        {
            Customer customer = new Customer();
            customer = (Customer)UpdateObj;
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-VD76OGN\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();
                string updateCustomer = $"update Customer set CustomerFullName='{customer.FullName}',CustomerCity='{customer.City}',CustomerPhone='{customer.Phonenumber}' where CustomerId={customer.ID}";
                using (SqlCommand command = new SqlCommand(updateCustomer, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("**********Updated successfull");
                    reader.Close();
                }
                
                string select = $"select * from Customer where CustomerId = {customer.ID}";
                using (SqlCommand command1 = new SqlCommand(select, con))
                {
                    SqlDataReader sqlDataReader = command1.ExecuteReader();
                    if (sqlDataReader.HasRows) { 
                        while (sqlDataReader.Read())
                    {
                        int customerid = sqlDataReader.GetInt32(0);
                        string fullname = sqlDataReader.GetString(1);
                        string city = sqlDataReader.GetString(2);
                        string phonenumber = sqlDataReader.GetString(3);
                        Console.WriteLine($"the customer id is {customerid}" +
                            $" ,Name = {fullname} ," +
                            $" city = {city} ," +
                            $"phone number = {phonenumber}");
                    }
                    }
                    else { Console.WriteLine("not updated"); }
                }
                con.Close();
            }
        }



        public void Delete(object DeleteObj)
        {
            Customer customer = new Customer();
            customer = (Customer)DeleteObj;
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-VD76OGN\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();
                string deleteCustomer = $"delete from Customer where CustomerId={customer.ID}";
                using (SqlCommand command = new SqlCommand(deleteCustomer, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("**********Deleted successfull");
                }
                con.Close();
            }
        }


    }
}
