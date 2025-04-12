namespace AirlineReservationConsoleSystem
{
    internal class Program
    {

        public static int maxFlight = 3;
        public static int FlightCounter = 0;
        public static string[] flight_Code = new string[3];

        public static string[] from_City = new string[3];
        public static string[] to_City = new string[3];
        public static DateTime[] departure_Time = new DateTime[3];
        public static int[] flight_duration = new int[3];
        
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

                       AddFlight(flight_Code[FlightCounter], from_City[FlightCounter], to_City[FlightCounter], departure_Time[FlightCounter], flight_duration[FlightCounter]);

                        break;
                    case 2:
                        DisplayAllFlights();  
                        break;
                    case 3:

                        Console.Write("Enter flight code : ");
                        string code = Console.ReadLine().ToLower();
                        FindFlightByCode(code);
                        break;
                    case 4:
                        //UpdateFlightDeparture();
                        break;
                    case 5:
                        //CancelFlightBooking();
                        break;
                    case 6:
                        //BookFlight();
                        break;
                    case 7:
                        //ValidateFlightCode();
                        break;
                    case 8:
                        //GenerateBookingID();
                        break;
                    case 9:
                        //DisplayFlightDetails();
                        break;
                    case 10:
                        //SearchBookingsByDestination();
                        break;
                    case 11:
                        //CalculateFare();
                        break;
                    case 0:
                        ExitApplication();
                        return;
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


            char doAgain;
            do
            {
                Console.WriteLine("\n Enter Number of Flight to add:\n");
                int numberOfFlight = int.Parse(Console.ReadLine());



                if (numberOfFlight + FlightCounter <= maxFlight)
                {

                    for (int i = FlightCounter; i < FlightCounter + numberOfFlight; i++)
                    {
                        //string stringflightCode = "";
                        bool found = false;
                        do
                        {

                            Console.WriteLine("Enter flight Code : ");
                            flight_Code[i] = Console.ReadLine();
                            flightCode = flight_Code[i].ToString();


                            if (string.IsNullOrWhiteSpace(flightCode))
                            {
                                Console.WriteLine("Flight Code cannot be empty. Please try again.");
                                found = false;

                            }

                            else if (int.TryParse(flightCode, out int result))
                            {
                                Console.WriteLine("Invalid input! Please enter a string");
                            }
                            else
                            {
                                found = true;
                                flight_Code[i] = flightCode;
                                break;
                            }
                        } while (!found);

                        do
                        {
                            Console.WriteLine("Enter From City : ");
                            from_City[i] = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(from_City[i]))
                            {
                                Console.WriteLine("From City cannot be empty. Please try again.");
                            }
                        } while (string.IsNullOrWhiteSpace(from_City[i]));


                        do
                        {
                            Console.WriteLine("Enter To City : ");
                            to_City[i] = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(to_City[i]))
                            {
                                Console.WriteLine("To City cannot be empty. Please try again.");
                            }
                        } while (string.IsNullOrWhiteSpace(to_City[i]));



                        do
                        {
                            Console.WriteLine("Enter Flight Duration : ");
                            flight_duration[i] = int.Parse(Console.ReadLine());
                            if (flight_duration[i] < 0)
                            {
                                Console.WriteLine("Flight duration cannot be negative. Please try again.");
                            }
                        } while (flight_duration[i] < 0);


                        do
                        {
                            Console.WriteLine("Enter Departure Time (yyyy-mm-dd hh:mm): ");
                            departure_Time[i] = DateTime.Parse(Console.ReadLine());
                            if (departure_Time[i] < DateTime.Now)
                            {
                                Console.WriteLine("Departure time cannot be in the past. Please try again.");
                            }
                        } while (departure_Time[i] < DateTime.Now);





                        Console.WriteLine("Flight Added Successfully .");
                    }

                    FlightCounter = FlightCounter + numberOfFlight;
                }

                else if (FlightCounter == maxFlight)
                {
                    Console.WriteLine("Maximum number of flight reached. No more flight can be added.");
                }
                else
                {
                    Console.WriteLine($"Invalid input . the remaining space is {maxFlight - FlightCounter}");


                }

                Console.WriteLine("\n Do you want to add more flight? (y/n) \n");
                doAgain = Console.ReadKey().KeyChar;

            } while (doAgain == 'y' || doAgain == 'Y');

            Console.Clear();
            //Console.WriteLine("Press any key to continue...");
            StartSystem();



        }

        public static void DisplayAllFlights()
        {


            Console.WriteLine("Displaying all flights:");
            for (int i = 0; i < FlightCounter; i++)
            {
                Console.WriteLine("Flight Code : "+ flight_Code[i]);
                Console.WriteLine("From City : " + from_City[i]);
                Console.WriteLine("To City : " + to_City[i]);
                Console.WriteLine("Departure Time : " + departure_Time[i]);
                Console.WriteLine("Flight Duration : " + flight_duration[i]);
                Console.WriteLine("\n");

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
            StartSystem();

        }





        public static void FindFlightByCode(string code)
        {
          
            

            bool found; 
            do 
            {

                
                
                found = false; 
                if (FlightCounter == 0) 
                {
                    Console.WriteLine("No student record found.");
                    found = false;
                    break;

                }
                else if (string.IsNullOrWhiteSpace(code))
                {
                    Console.WriteLine("Name cannot be empty. Please try again.");
                    found = false;

                }

                else if (int.TryParse(code, out int result))
                {
                    Console.WriteLine("Invalid input! Please enter a string");
                }

                else 
                {


                    for (int i = 0; i < FlightCounter; i++) 
                    {
                        string lowerCode = flight_Code[i].ToLower();

                        if (lowerCode == code) 
                        {
                            Console.WriteLine( "Flight Code : " + flight_Code[i]);
                            Console.WriteLine("From City : " + from_City[i]);
                            Console.WriteLine("To City : " + to_City[i]);
                            Console.WriteLine("Departure Time : " + departure_Time[i]);
                            Console.WriteLine("Flight Duration : " + flight_duration[i]);
                            Console.WriteLine("\n");
                            found = true;
                            break;
                        }


                    }
                }
                if (!found) 
                {
                    Console.WriteLine("Not found. Try again.");
                }

            } while (!found);

            Console.WriteLine("Press any key to continue...");
            Console.Clear();
            StartSystem();

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
