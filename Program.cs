namespace AirlineReservationConsoleSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            StartSystem();
        }


        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Airline Reservation System!");
        }

        public static int ShowMainMenu()
        {
            Console.WriteLine("1. Add Flight");
            Console.WriteLine("2. Display All Flights");
            Console.WriteLine("3. Find Flight By Code");
            Console.WriteLine("4. Update Flight Departure");
            Console.WriteLine("5. Cancel Flight Booking");
            Console.WriteLine("6. Book Flight");
            Console.WriteLine("7. Validate Flight Code");
            Console.WriteLine("8. Generate Booking ID");
            Console.WriteLine("9. Display Flight Details");
            Console.WriteLine("10. Search Bookings By Destination");
            Console.WriteLine("11. CalculateFare");
            Console.WriteLine("0. Exit System");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void StartSystem()
        {

            DisplayWelcomeMessage();

            while (true)
            {
                int choice = ShowMainMenu();
                switch (choice)
                {
                    case 1:
                        //AddFlight();
                        break;
                    case 2:
                        //CancelFlightBooking();
                        break;
                    case 3:
                        DisplayAllFlights();
                        break;
                    case 4:
                        //AddFlight(flightCode, fromCity, toCity, departureTime, duration);
                        break;
                    case 5:
                        ExitApplication();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }


        public static void ExitApplication()
        {
            Console.WriteLine("Exiting the application. Goodbye!");
        }



        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration)
        {

           



        }      
        
        public static void DisplayAllFlights()
        {

        }





        public static void FindFlightByCode(string code)
        {

        }


        public static void UpdateFlightDeparture(ref DateTime departure)
        {

        }


        //public static void CancelFlightBooking(out string passengerName)
        //{

        //}



        public static void BookFlight(string passengerName, string flightCode = "Default001")
        {

        }

        public static void ValidateFlightCode(string flightCode)
        {

        }



        public static void GenerateBookingID(string passengerName)

        {

        }

        public static void DisplayFlightDetails(string code)

        {

        }


        public static void SearchBookingsByDestination(string toCity)
        {

        }


        public static void CalculateFare(int basePrice, int numTickets)
        {

        }

        public static void CalculateFare(double basePrice, int numTickets)
        {

        }



        public static void CalculateFare(int basePrice, int numTickets, int discount)
        {

        }


        public static void ConfirmAction(string action)
        {

        }












    }
}
