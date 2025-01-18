// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography.X509Certificates;



namespace ContactsManager
{

    class ContactMan
    {

        static void Main()
        {
            Console.WriteLine("--------------------------------ContactMan v1.0----------------------------");
            Console.WriteLine("Options:");
            Console.WriteLine("(A)dd Contact, (D)elete Contact, (S)earch Contact, (L)ist Contacts, (Q)uit");
            string startUserinput = Console.ReadLine();
            bool isValidInput = false;
            if (startUserinput.Trim().ToLower() == "a")
            {
                Console.WriteLine("Add Contact");
                isValidInput = true;
            }
            if (startUserinput.Trim().ToLower() == "d")
            {
                Console.WriteLine("Delete Contact");
                isValidInput = true;
            }
            if (startUserinput.Trim().ToLower() == "s")
            {
                Console.WriteLine("Search Contacts");
                isValidInput = true;
            }
            if (startUserinput.Trim().ToLower() == "l")
            {
                Console.WriteLine("List Contacts");
                isValidInput = true;
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
    }
}

