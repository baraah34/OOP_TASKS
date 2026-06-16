using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    //GUEST CLASS

    class Guest
    {
        public string guestId;
        public string guestName;
        public string roomNumber;
        public string checkInDate;
        public int totalNights;

        // GUEST CONSTRUCTOR
        public Guest(string guestId, string guestName, string roomNumber, string checkInDate, int totalNights)
        {
            this.guestId = guestId;
            this.guestName = guestName;
            this.roomNumber = roomNumber;
            this.checkInDate = checkInDate;
            this.totalNights = totalNights;
        }

        public void displayGuest()
        {
            Console.WriteLine("Guest ID: " + guestId);
            Console.WriteLine("Guest Name: " + guestName);
            Console.WriteLine("Room Number: " + roomNumber);
            Console.WriteLine("Check-In Date: " + checkInDate);
            Console.WriteLine("Total Nights: " + totalNights);
        }

        public double calculateCost(List<Room> rooms)//THE METHIOD RECEIVE THE LIST OF HOTEL ROOM
        {
            //SEARCH INSIDE THE ROOM LIST TO FIND THE ROOM BOOKED BY  GUEST

           // FOR EACH ROOM r, CHECK IF THE ROOM NUMBER EQUALES  GUEST ROOM NUMBER
            Room room = rooms.FirstOrDefault(r => r.roomNumber.ToString() == roomNumber);  //FirstOrDefault =>FIND THE FIRST ROOM THAT MATCH THE CONDITION

            if (room == null)
            {
                return 0;
            }

            return room.pricePerNight * totalNights;
        }
    }






    internal class Program

    {
        //CASE 1 FUNCTION
        static void AddNewRoom(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("===== Add New Room =====");

            Console.Write("Enter room number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            // Room number and price must be validated as positive numbers.

            if (roomNumber <= 0)
            {
                Console.WriteLine("Room number must be positive.");
                return;
            }

            // Before adding, check whether a room with the same room number already exists in the rooms list. If it does, display an
           // error and return to the menu without adding.
            if (rooms.Any(r => r.roomNumber == roomNumber))
            {
                Console.WriteLine("Error: Room number already exists.");
                return;
            }

            Console.Write("Enter room type Single - Double - Suite: ");
            string roomType = Console.ReadLine();

            Console.Write("Enter price per night: ");
            double pricePerNight = double.Parse(Console.ReadLine());

            if (pricePerNight <= 0)
            {
                Console.WriteLine("Price must be positive.");
                return;
            }
            // If the room number is unique, create a new Room object and add it to the rooms list. The room is always available when first added
          Room AddNewRoom = new Room(roomNumber, roomType, pricePerNight, true);
            rooms.Add(AddNewRoom);

            Console.WriteLine("\nRoom added successfully!");
            Console.WriteLine("Room Number: " + roomNumber);
            Console.WriteLine("Room Type: " + roomType);
            Console.WriteLine("Price Per Night: " + pricePerNight.ToString("F2") + " OMR");
            Console.WriteLine("Updated Total Room Count: " + rooms.Count);
        }

        //CASE 2

        static void RegisterNewGuest(List<Guest> guests)
        {
            Console.Clear();
            Console.WriteLine("===== Register New Guest =====");

            Console.Write("Enter guest name: ");
            string guestName = Console.ReadLine();

            Console.Write("Enter check-in date: ");
            string checkInDate = Console.ReadLine();

            Console.Write("Enter number of nights: ");
            int totalNights = int.Parse(Console.ReadLine());

            // Number of nights must be validated as a positive integer:

            if (totalNights <= 0)
            {
                Console.WriteLine("Number of nights must be positive.");
                return;
            }

            //Auto - generate the guest ID from the current size of the guests list(format: G001, G002, G003...):

            string guestId = "G" + (guests.Count + 1).ToString("D3");


           // Create a new Guest object with roomNumber set to a default value of 'Not Assigned', then add it to the guests list:

            Guest newGuest = new Guest(guestId, guestName, "Not Assigned", checkInDate, totalNights);


            guests.Add(newGuest);

            Console.WriteLine("\nGuest registered successfully!");
            Console.WriteLine("Generated Guest ID: " + guestId);
            Console.WriteLine("Guest Name: " + guestName);
            Console.WriteLine("Room Number: Not Assigned");
            Console.WriteLine("Check-In Date: " + checkInDate);
            Console.WriteLine("Total Nights: " + totalNights);
        }


        //case 3 

        static void BookRoomForGuest(List<Room> rooms, List<Guest> guests)
        {
            Console.Clear();
            Console.WriteLine("===== Book a Room for a Guest =====");

            Console.Write("Enter guest ID: ");
            string guestId = Console.ReadLine();

            Guest guest = guests.FirstOrDefault(g => g.guestId == guestId);

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            Console.Write("Enter desired room number: ");
            int roomNumber;

            if (!int.TryParse(Console.ReadLine(), out roomNumber))
            {
                Console.WriteLine("Invalid room number.");
                return;
            }

            Room room = rooms.FirstOrDefault(r => r.roomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            if (room.isAvailable == false)
            {
                Console.WriteLine("Room is already booked.");
                return;
            }

            guest.roomNumber = room.roomNumber.ToString();
            room.isAvailable = false;

            Console.WriteLine("\nBooking confirmed!");
            Console.WriteLine("Guest Name: " + guest.guestName);
            Console.WriteLine("Room Number: " + room.roomNumber);
            Console.WriteLine("Room Type: " + room.roomType);
            Console.WriteLine("Price Per Night: " + room.pricePerNight.ToString("F2") + " OMR");
            Console.WriteLine("Total Nights: " + guest.totalNights);
            Console.WriteLine("Total Cost: " + guest.calculateCost(rooms).ToString("F2") + " OMR");
        }

        static void Main(string[] args)
        {

            List<Room> rooms = new List<Room>();

            List<Guest> guests = new List<Guest>();

            rooms.Add(new Room(111, "Single", 26.00, true));
            rooms.Add(new Room(112, "Double", 42.00, true));
            rooms.Add(new Room(113, "Suite", 88.00, true));
            rooms.Add(new Room(114, "Single", 35.00, true));
            rooms.Add(new Room(115, "Double", 50.00, true));
            rooms.Add(new Room(116, "Suite", 150.00, true));


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
                        AddNewRoom(rooms);
                        break;

                    case "2"://Register New Guest
                        RegisterNewGuest(guests);
                        break;

                    case "3"://Book a Room for a Guest
                        BookRoomForGuest(rooms,guests);
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