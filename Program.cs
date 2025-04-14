namespace AirlineReservationConsoleSystem
{
    internal class Program
    {

        public static int maxFlight = 3;
        public static int maxPassenger = 3;
        public static int FlightCounter = 0;
        public static int maxSeats = 20;
        public static int maxBooking = 10;
        public static int basePrice = 120;
        public static string flightCode = "";
        public static string passengerName = "";
        public static string[] booking_Id = new string[3];
        public static string[] seats = new string[3];
        public static string[] bookingFlight = new string[3];
        public static string[] flight_Code = new string[3];
        public static string[] from_City = new string[3];
        public static string[] to_City = new string[3];
        public static DateTime[] departure_Time = new DateTime[3];
        public static int[] flight_duration = new int[3];
        public static string[] passenger_Name = new string[3];
        public static DateTime departure;
        public static int numTickets;

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


                        AddFlight(flight_Code[FlightCounter], from_City[FlightCounter], to_City[FlightCounter], departure_Time[FlightCounter], flight_duration[FlightCounter]);
                      

                        break;
                    case 2:
                        DisplayAllFlights();
                        break;
                    case 3:

                        Console.Write("Enter flight code : ");
                        string code = Console.ReadLine().ToLower();
                        bool result = FindFlightByCode(code);
                        if (result)
                        {

                            result = true;
                        }
                        else
                        {
                            Console.WriteLine("Flight not found.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        StartSystem();
                        break;
                    case 4:

                        UpdateFlightDeparture(ref departure);
                        break;
                    case 5:
                        //CancelFlightBooking();


                        break;
                    case 6:
                      
                        BookFlight(passengerName, flightCode);
                        break;
                    case 7:
                        Console.Write("Enter flight code to validate: ");
                        flightCode = Console.ReadLine().ToLower();

                        bool isValid = ValidateFlightCode(flightCode);
                        if (isValid)
                        {
                            Console.WriteLine("Flight code is valid.");
                        }
                        else
                        {
                            Console.WriteLine("Flight code already exists.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        StartSystem();

                        break;
                    
                    case 9:
                        Console.Write("Enter flight code to display details: ");
                        code = Console.ReadLine().ToLower();
                        DisplayFlightDetails(code);
                        break;
                    case 10:
                        Console.WriteLine("Enter destination city to search: ");
                        string toCity = Console.ReadLine().ToLower();
                        SearchBookingsByDestination(toCity);
                        break;
                   // case 11:
                       // //CalculateFare();
                       // Console.WriteLine("Choose fare calculation:");
                       // Console.Write("1. Regular");
                       // Console.Write("2. Double price");
                       // Console.Write("3. With discount");

                       // int fareCalculation = int.Parse(Console.ReadLine());
                       
                       // if (fareCalculation == 1)

                       // {
                           
                       //     CalculateFare(basePrice, numTickets);
                       //     break;
                       // }
                       // else if (fareCalculation == 2)
                       // {
                           
                       //     CalculateFare(basePrice, numTickets);
                       //     break;
                       // }
                       // else if (fareCalculation == 3)
                       // {
                         
                       //     Console.Write("Enter discount: ");
                       //     int discount = int.Parse(Console.ReadLine());
                       //     CalculateFare(basePrice, numTickets, discount);
                       //     break;
                       // }
                       // else
                       // {
                       //     Console.WriteLine("Invalid choice. Please try again.");
                       //     break;
                       // }
                       // maxSeats= maxSeats - numTickets;
                       //// totlaprice 

                       // break;
                    case 0:
                        ExitApplication();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }


            }
        }
        // Exit application
        public static void ExitApplication()
        {
            Console.WriteLine("Exiting the application. Goodbye!");

        }
        // Add flight
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
                            fromCity = from_City[i].ToString();
                            if (string.IsNullOrWhiteSpace(fromCity))
                            {
                                Console.WriteLine("From City cannot be empty. Please try again.");
                                found = false;
                            }
                            else if (int.TryParse(fromCity, out int result)) 
                            {
                                Console.WriteLine("Invalid input! Please enter a string");
                                found = false;
                            }
                           
                            else
                            {
                                found = true;
                                from_City[i] = fromCity;
                                break;
                            }
                        } while (!found);


                        do
                        {
                            Console.WriteLine("Enter To City : ");
                            to_City[i] = Console.ReadLine();
                            toCity = to_City[i].ToString();
                            if (string.IsNullOrWhiteSpace(toCity))
                            {
                                Console.WriteLine("From City cannot be empty. Please try again.");
                                found = false;
                            }
                            else if (int.TryParse(toCity, out int result))
                            {
                                Console.WriteLine("Invalid input! Please enter a string");
                                found = false;
                            }

                            else
                            {
                                found = true;
                                to_City[i] = toCity;
                                break;
                            }
                        } while (!found);



                        do
                        {
                            Console.WriteLine("Enter Flight Duration : ");
                            flight_duration[i] = int.Parse(Console.ReadLine());


                           
                            duration = flight_duration[i];
                            if (flight_duration[i] < 0)
                            {
                                Console.WriteLine("Flight duration cannot be negative. Please try again.");
                                found = false;
                            }
                         
                            else
                            {
                                flight_duration[i] = duration;
                                found = true;
                                break;
                            }
                        } while (!found);


                        do
                        {
                            Console.WriteLine("Enter Departure Time (yy-mm-dd hh:mm): ");
                            departure_Time[i] = DateTime.Parse(Console.ReadLine());
                            departureTime = departure_Time[i];
                            if (departure_Time[i] == null)
                            {
                                Console.WriteLine("Departure time cannot be empty. Please try again.");
                            }
                            else if (int.TryParse(departure_Time[i].ToString(), out int result))
                            {
                                Console.WriteLine("Invalid input! Please enter a valid date and time");
                            }
                            else
                            {
                                found = true;
                                departure_Time[i] = departureTime;
                                break;
                            }
                          
                        } while (!found);





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
           
            StartSystem();



        }
        // Display all flights
        public static void DisplayAllFlights()
        {
            if (FlightCounter == 0)
            {
                Console.WriteLine("No flight record found. \n");
            }

            else
            {

                Console.WriteLine("Displaying all flights:");
                for (int i = 0; i < FlightCounter; i++)
                {
                    Console.WriteLine("Flight Code : " + flight_Code[i]);
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
        }
        // Find flight by code
        public static bool FindFlightByCode(string code)
        {



            bool found;
            do
            {

                found = false;
                if (FlightCounter == 0)
                {

                    Console.WriteLine("No flight record found. \n");
                
                    found = false;
                    

                }
                else if (string.IsNullOrWhiteSpace(code))
                {
                    Console.WriteLine("Flight code cannot be empty. Please try again.");
                    found = false;

                }


                else
                {


                    for (int i = 0; i < FlightCounter; i++)
                    {
                        string lowerCode = flight_Code[i].ToLower();

                        if (lowerCode == code)
                        {
                            Console.WriteLine("\nFlight found:");
                            Console.WriteLine("Flight Code : " + flight_Code[i]);
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
                 
                    return false;
                    
                }

            } while (!found);
            return found;


        }
        // Update flight departure time
        public static DateTime UpdateFlightDeparture(ref DateTime departure)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                Console.WriteLine("Flight Code : " + flight_Code[i]);
                Console.WriteLine("From City : " + from_City[i]);
                Console.WriteLine("To City : " + to_City[i]);
                Console.WriteLine("Departure Time : " + departure_Time[i]);
                Console.WriteLine("Flight Duration : " + flight_duration[i]);
                Console.WriteLine("\n");
            }

            Console.WriteLine("Enter flight Code to update departure time: ");
            string flightCode = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < FlightCounter; i++)
            {
                if (flight_Code[i] == flightCode)
                {
                    Console.WriteLine("Enter new Departure Time (yyyy-mm-dd hh:mm): ");
                    DateTime newDeparture = DateTime.Parse(Console.ReadLine());

                    if (newDeparture < DateTime.Now)
                    {
                        Console.WriteLine("Departure time cannot be in the past. Please try again.");
                    }
                    else
                    {
                        departure_Time[i] = newDeparture;
                        Console.WriteLine("Departure time updated successfully.");
                        departure = newDeparture;
                        found = true;

                        break;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Flight code not found.");
                found = false;
                
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
            StartSystem();
            return departure;
        }
        // Cancel flight booking
        public static string CancelFlightBooking(out string passengerName)
        {
            passengerName = ""; 

            try
            {
                Console.Write("Enter booking id to cancel flight booking: ");
                string bookingId = Console.ReadLine().ToLower();

                for (int i = 0; i < FlightCounter; i++)
                {

                    string bookId = booking_Id[i].ToString().ToLower(); 
                    if (booking_Id[i] == bookingId)
                    {

                       
                            passenger_Name[i] = "";
                            //flight_Code[i] = "";
                       
                        Console.WriteLine("Booking cancelled.");
                            return passengerName;
                        
                    }
                }

                Console.WriteLine("Booking not found.");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Booking id can't be null: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input. Please enter a valid booking id: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return passengerName;
        }
        // Book flight
        public static void BookFlight(string passengerName, string flightCode = "Default001")
        {


            if (FlightCounter == 0)
            {
                Console.WriteLine("No flight record found. \n");

            }
            else
            {
                Console.WriteLine("---Booking flight---\n");

                for (int i = 0; i < FlightCounter; i++)
                {
                    bool found = false;
                    do
                    {

                        Console.WriteLine("Enter Passenger Name: ");
                        passengerName = Console.ReadLine();

                        // passengerName = passenger_Name[i].ToString();
                        if (passengerName == null)
                        {
                            Console.WriteLine("Passenger name cannot be empty. Please try again.");
                            //found = false;
                        }
                        else if (int.TryParse(passengerName, out int result))
                        {
                            Console.WriteLine("Invalid input! Please enter a string");
                        }
                        else
                        {
                            found = true;
                            passenger_Name[i] = passengerName;
                            booking_Id[i] = GenerateBookingID(passengerName);
                        }

                    } while (!found);



                    do
                    {

                        Console.WriteLine("Enter flight Code : ");
                        flight_Code[i] = Console.ReadLine();
                        flightCode = flight_Code[i].ToString();


                        if (string.IsNullOrWhiteSpace(flightCode))
                        {
                            string bookingFlight = BookFlight(flightCode);
                            found = true;
                            break;

                        }

                        else if (int.TryParse(flightCode, out int result))
                        {
                            Console.WriteLine("Invalid input! Please enter a string");
                            break;
                        }
                        else
                        {
                            for (int index = 0; index < FlightCounter; index++)
                            {
                                string flightCodeLow = flightCode[index].ToString().ToLower();

                                if (flightCodeLow == flightCode)
                                {
                                    found = true;
                                    flightCode = flight_Code[i].ToString();
                                    bookingFlight[i] = flightCode;
                                    break;
                                }
                            }

                        }
                    } while (!found);


                    Console.WriteLine("Enter number of Tickets : ");
                    int numTickets = int.Parse(Console.ReadLine());

                    if (numTickets < maxSeats)
                    {
                        Console.WriteLine("Number of tickets cannot be less than 0. Please try again.");
                        //found = false;
                    }
                    else if (numTickets > maxSeats)
                    {
                        Console.WriteLine("Number of tickets cannot be more than available seats. Please try again.");
                        //found = false;
                    }
                    else
                    {
                        //CalculateFare(basePrice, numTickets);
                        Console.WriteLine("Do you have a discount? (y/n): ");
                        char discountChoice = Console.ReadKey().KeyChar;
                        if (discountChoice == 'y' || discountChoice == 'Y')
                        {
                            Console.WriteLine("Enter discount amount: ");
                            int discount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Total fare after discount: " + CalculateFare(basePrice, numTickets, discount));
                        }
                        else
                        {
                            // Calculate fare without discount

                            Console.WriteLine("Total fare: " + CalculateFare(basePrice, numTickets));

                        }

                        maxSeats = maxSeats - numTickets;




                    }

                    Console.WriteLine(" Booking successfully!");


                }


                Console.WriteLine("Press any key to continue...");
                Console.WriteLine();
                Console.Clear();
                StartSystem();
            }

        }
        public static string BookFlight(string flightCode = "Default001")
        {
           return flightCode;
        }
        // Validate flight code
        public static bool ValidateFlightCode(string flightCode)
        {
            Console.WriteLine("Validating flight code...\n");

            for (int i = 0; i < FlightCounter; i++)
            {
                if (flight_Code[i] == flightCode)
                {
                   
                    return false;
                }
               
            }
            return true; 

        }
        // Generate booking ID
        public static string GenerateBookingID(string passengerName)
        {
            // Generate a random number
            Random random = new Random();
            int randomInt = random.Next(1000, 9999);
            string bookingId;
            bookingId = passengerName + randomInt;
            

            return bookingId;
        }
        // Display flight details
        public static void DisplayFlightDetails(string code)

        {


            if (FlightCounter == 0)
            {
                Console.WriteLine("No flight record found. \n");
            }

            else
            {

               
                Console.WriteLine("--------View booking flight-----------");
                for (int i = 0; i < FlightCounter; i++)
                {
                    if (flight_Code[i] == code)
                    {
                        //bookingFlight[i] = flight_Code[i];
                        Console.WriteLine("Flight Code : " + flight_Code[i]);
                        //Console.WriteLine("BookingFlight" + bookingFlight[i]);
                        Console.WriteLine("From City : " + from_City[i]);
                        Console.WriteLine("To City : " + to_City[i]);
                        Console.WriteLine("Departure Time : " + departure_Time[i]);
                        Console.WriteLine("Flight Duration : " + flight_duration[i]);
                        Console.WriteLine("Passenger Name : " + passenger_Name[i]);
                        Console.WriteLine("Booking ID : " + booking_Id[i]);

                    }
                    else
                    {
                        Console.WriteLine("Flight code not found.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    // Console.Clear();
                    //StartSystem();

                }
            }
        }
        // Search bookings by destination
        public static void SearchBookingsByDestination(string toCity)
        {
            if (FlightCounter == 0)
            {
                Console.WriteLine("No flight record found. \n");
            }

            else
            {

                Console.WriteLine("Displaying all flights:");
               
                for (int i = 0; i < FlightCounter; i++)
                {
                    if (to_City[i] == toCity)
                    {
                        Console.WriteLine("-----Filter flight by destination------");
                        Console.WriteLine("Flight Code : " + flight_Code[i]);
                        Console.WriteLine("BookingFlight" + bookingFlight[i]);
                        Console.WriteLine("From City : " + from_City[i]);
                        Console.WriteLine("To City : " + to_City[i]);
                        Console.WriteLine("Departure Time : " + departure_Time[i]);
                        Console.WriteLine("Flight Duration : " + flight_duration[i]);


                    }
                    else
                    {
                        Console.WriteLine("Flight Destination not found.");
                    }

                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();

        }
        // Calculate fare int 
        public static int CalculateFare(int basePrice, int numTickets)
        {
            int totalprice = basePrice * numTickets;
            return totalprice;


        }
        // Calculate fare double/int
        public static double CalculateFare(double basePrice, int numTickets)
        {
            double totalprice = basePrice * numTickets;
            return totalprice;
        }
        // Calculate fare with discount
        public static int CalculateFare(int basePrice, int numTickets, int discount)
        {
            int totalprice = (basePrice * numTickets) - discount;
            return totalprice;
        }
        // Confirm action
        public static bool ConfirmAction(string action)
        {
            Console.WriteLine($"Are you sure you want to {action} ? (y / n) : ");
            return Console.ReadKey().KeyChar == 'y' || Console.ReadKey().KeyChar == 'Y';
        }












    }
}
