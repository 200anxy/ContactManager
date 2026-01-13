
using System;
using System.Security.Cryptography.X509Certificates;
using System.Data.SQLite;
using System.ComponentModel.Design;



namespace ContactsManager
{

    class ContactMan
    {

        static void Main()
        {
            string connectionString = "Data Source=contacts.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS Contacts (Id INTEGER PRIMARY KEY, Name TEXT, PhoneNumber TEXT, Email TEXT, Address TEXT, Birthday TEXT, Notes TEXT)";
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("--------------------------------ContactMan v1.0----------------------------");
            Console.WriteLine("Options:");
            Console.WriteLine("(A)dd Contact, (D)elete Contact, (S)earch Contact, (L)ist Contacts, (Q)uit");
            string startUserinput = Console.ReadLine();
            bool isValidInput = false;
            if (startUserinput.Trim().ToLower() == "a")
            {
                Console.WriteLine("Add Contact");
                isValidInput = true;
                AddContact();

            }
            if (startUserinput.Trim().ToLower() == "d")
            {
                Console.WriteLine("Delete Contact");
                isValidInput = true;

                DeleteContact();

            }
            if (startUserinput.Trim().ToLower() == "s")
            {
                Console.WriteLine("Search Contacts");
                isValidInput = true;
                SearchContacts();
            }
            if (startUserinput.Trim().ToLower() == "l")
            {
                Console.WriteLine("List Contacts");
                isValidInput = true;
                ListContacts();
            }
            if (startUserinput.Trim().ToLower() == "q")
            {
                Console.WriteLine("Quitting Program");
                Task.Delay(2000);
                Environment.Exit(0);
            }
            if (isValidInput == false)
            {
                Console.WriteLine("Invalid Input");
                Main();
            }

        }
        static void AddContact()
        {
            string connectionString = "Data Source=contacts.db;Version=3;";
            Console.WriteLine("Enter Contact Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Contact Phone Number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Contact Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Contact Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Contact Birthday");
            string birthday = Console.ReadLine();
            Console.WriteLine("Enter Contact Notes");
            string notes = Console.ReadLine();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Contacts (Name, PhoneNumber, Email, Address, Birthday, Notes) VALUES (@Name, @PhoneNumber, @Email, @Address, @Birthday, @Notes)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Birthday", birthday);
                    command.Parameters.AddWithValue("@Notes", notes);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Contact Added succesfully");
                Main();
            }
        }
        static void ListContacts()
        {
            string connectionString = "Data Source=contacts.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Contacts";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Name: {reader["Name"]}, Phone Number: {reader["PhoneNumber"]}, Email: {reader["Email"]}, Address: {reader["Address"]}, Birthday: {reader["Birthday"]}, Notes: {reader["Notes"]}");
                        }
                        Main();
                    }
                }
            }
        }
        static void SearchContacts()
        {
            bool isValidName = false;
            string connectionString = "Data Source=contacts.db;Version=3;";
            Console.WriteLine("Enter Contact Name");
            string name = Console.ReadLine();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Contacts WHERE Name = @Name";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Name: {reader["Name"]}, Phone Number: {reader["PhoneNumber"]}, Email: {reader["Email"]}, Address: {reader["Address"]}, Birthday: {reader["Birthday"]}, Notes: {reader["Notes"]}");
                            isValidName = true;
                        }
                        if (isValidName != true)
                        {
                            Console.WriteLine("No contact found with that name.");
                            Console.WriteLine("Press enter to return to main menu.");
                            Console.ReadLine();
                        }
                        Console.Clear();
                        Main();
                    }
                }
            }
            
         }
        static void DeleteContact()
        {
            string connectionString = "Data Source=contacts.db;Version=3;";
            Console.WriteLine("Enter Contact Name");
            string deletename = Console.ReadLine();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Contacts WHERE Name = @Name";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", deletename);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Contact Deleted successfully");
            Main();
        }
    }
}

