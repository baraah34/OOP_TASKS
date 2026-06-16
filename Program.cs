using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagementSystem
{
    //ROOM
    class Room
    {
        public int roomNumber;
        public string roomType;
        public double pricePerNight;
        public bool isAvailable;

        // ROOM CONSTRUCTOR => give values to  object  when you create it.
        public Room(int roomNumber, string roomType, double pricePerNight, bool isAvailable)
        {
            this.roomNumber = roomNumber;
            this.roomType = roomType;
            this.pricePerNight = pricePerNight;
            this.isAvailable = isAvailable;
        }

        public void displayRoom()
        {
            Console.WriteLine("Room Number: " + roomNumber);
            Console.WriteLine("Room Type: " + roomType);
            Console.WriteLine("Price Per Night: " + pricePerNight.ToString("F2") + " OMR");
            Console.WriteLine("Available: " + isAvailable);
         
        }
    }




    internal class Program

    {
        static void Main(string[] args)
        {
            bool choice = true;

            while (choice)
            {
                Console.Clear();

                Console.WriteLine("================================================");
                Console.WriteLine("GRAND VISTA HOTEL — MANAGEMENT SYSTEM");
                Console.WriteLine("================================================");
                Console.WriteLine("1. Add New Room");
                Console.WriteLine("2. Register New Guest");
                Console.WriteLine("3. Book a Room for a Guest");
                Console.WriteLine("4. Search & Filter Rooms");
                Console.WriteLine("5. Guest & Booking Statistics");
                Console.WriteLine("6. Check Out a Guest");
                Console.WriteLine("7. Remove Unavailable Rooms");
                Console.WriteLine("0. Exit");
                Console.WriteLine("================================================");
                Console.Write("Enter your choice: ");

                string choices = Console.ReadLine();

                switch (choices)
                {
                    case "1":// Add New Room
                        break;

                    case "2"://Register New Guest
                        break;

                    case "3"://Book a Room for a Guest
                        break;

                    case "4"://Search & Filter Rooms
                        break;

                    case "5":// Guest & Booking Statistics
                        break;

                    case "6"://Check Out a Guest
                        break;

                    case "7"://Remove Unavailable Rooms
                        break;

                    case "0":
                        choice = false;
                        Console.WriteLine("Exit system.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (choice)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}