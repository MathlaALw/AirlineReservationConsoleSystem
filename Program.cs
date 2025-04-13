namespace AirlineReservationConsoleSystem
{
    internal class Program
    {

        public static int maxFlight = 3;
        public static int maxPassenger = 3;
        public static int FlightCounter = 0;
        public static string flightCode = "Default001";
        public static string passengerName = "";
        public static int[] booking_Id = new int[3];
        public static bool[] isbooked = new bool[3];
        public static string[] bookingFlight = new string[3];
        public static string[] flight_Code = new string[3];

        public static string[] from_City = new string[3];
        public static string[] to_City = new string[3];
        public static DateTime[] departure_Time = new DateTime[3];
        public static int[] flight_duration = new int[3];
        public static string[] passenger_Name = new string[3];
        public static DateTime departure;

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
                            Console.WriteLine("Flight found.");

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


                        //DisplayAllFlights();

                        //Console.Write("Enter flight code to update flight departure : ");
                        //string codeFlightUpdate = Console.ReadLine().ToLower();

                        // UpdateFlightDeparture();

                        UpdateFlightDeparture(ref departure);
                        break;
                    case 5:
                        //CancelFlightBooking();


                        break;
                    case 6:
                        Console.WriteLine("Passenger Name: ");
                        passengerName = Console.ReadLine().ToLower();
                        Console.WriteLine("Enter flight Code : ");
                        flightCode = Console.ReadLine().ToString();

                        //BookFlight(passengerName, flightCode);
                        if (passengerName != null && flightCode != null)
                        {
                            BookFlight(passengerName, flightCode);
                        }
                        else
                        {
                            BookFlight(flightCode);
                        }



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
                    case 8:
                        GenerateBookingID(passengerName);
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
                            Console.WriteLine("Enter Departure Time (yy-mm-dd hh:mm): ");
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





        public static bool FindFlightByCode(string code)
        {



            bool found;
            do
            {

                found = false;
                if (FlightCounter == 0)
                {
                    // Console.WriteLine("No flight record found.");
                    found = false;
                    break;

                }
                else if (string.IsNullOrWhiteSpace(code))
                {
                    Console.WriteLine("Flight code cannot be empty. Please try again.");
                    found = false;

                }

                //else if (int.TryParse(code, out int result))
                //{
                //    Console.WriteLine("Invalid input! Please enter a string");
                //    //found = false;
                //}

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
                    //Console.WriteLine("Not found. Try again.");
                    return false;
                    break;
                }

            } while (!found);
            return found;


        }


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
            }

            return departure;
        }




        public static string CancelFlightBooking(out string passengerName)
        {
            passengerName = string.Empty; 

            try
            {
                Console.Write("Enter booking id to cancel flight booking: ");
                int bookingId = int.Parse(Console.ReadLine());

                for (int i = 0; i < FlightCounter; i++)
                {
                    if (booking_Id[i] == bookingId)
                    {
                        if (isbooked[i])
                        {
                            isbooked[i] = false;
                            passengerName = passenger_Name[i];
                            Console.WriteLine("Booking cancelled.");
                            return passengerName;
                        }
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



        public static void BookFlight(string passengerName, string flightCode = "Default001")
        {


            Console.WriteLine("Booking flight...\n");






           
            for (int i = 0; i < FlightCounter; i++)
            {
                if (FlightCounter == 0)
                {
                    Console.WriteLine("No flight record found. \n");
                    break;
                }
                else
                {
                    Console.WriteLine("Passenger Name: ");
                    passengerName = Console.ReadLine();


                    if (passengerName == null)
                    {
                        Console.WriteLine("Passenger name cannot be empty. Please try again.");
                        //found = false;
                    }
                    else if (int.TryParse(passengerName, out int result))
                    {
                        Console.WriteLine("Invalid input! Please enter a string");
                    }
                    passenger_Name[i] = passengerName;
                    //booking_Id[i] = GenerateBookingID(passengerName);


                    Console.WriteLine("Enter flight Code : ");
                    flightCode = Console.ReadLine().ToString();
                    if (string.IsNullOrWhiteSpace(flightCode))
                    {
                        //Console.WriteLine("Flight Code cannot be empty. Please try again.");
                        // found = false;
                        Console.WriteLine(flightCode);
                        

                    }

                    else if (int.TryParse(flightCode, out int result))
                    {
                        Console.WriteLine("Invalid input! Please enter a string");
                    }


                    flight_Code[i] = flightCode;
                }

                Console.WriteLine("Flight booked successfully!");

                Console.WriteLine("Press any key to continue...");
                Console.WriteLine();
            }
                    
           // Console.Clear();
           // StartSystem();

        }


        public static void BookFlight( string flightCode = "Default001")
        {


           Console.WriteLine(flightCode);



            for (int i = 0; i < FlightCounter; i++)
            {
                if (FlightCounter == 0)
                {
                    Console.WriteLine("No flight record found. \n");
                    break;
                }
                else
                {
                    


                    if (passengerName == null)
                    {
                        Console.WriteLine("Passenger name cannot be empty. Please try again.");
                        //found = false;
                    }
                    else if (int.TryParse(passengerName, out int result))
                    {
                        Console.WriteLine("Invalid input! Please enter a string");
                    }
                    passenger_Name[i] = GenerateBookingID(passengerName);
                    //booking_Id[i] = GenerateBookingID(passengerName);


                   

                    flight_Code[i] = flightCode;
                }

                Console.WriteLine("Flight booked successfully!");

                Console.WriteLine("Press any key to continue...");
                Console.WriteLine();
            }


        }




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




        public static string GenerateBookingID(string passengerName)
        {
            // Generate a random number
            Random random = new Random();
            int randomNumber = random.Next();
            string bookingId = randomNumber.ToString();

            // Append the booking ID to the passenger name
           // passengerName = passengerName + bookingId;

            for (int i = 0; i < FlightCounter; i++)
            {
                if (passenger_Name[i] == passengerName)
                {
                    booking_Id[i] = randomNumber;
                    passengerName = passenger_Name[i] + booking_Id[i];
                    return passengerName;
                   // return bookingId;
                }
            }

            
            Console.WriteLine("Booking ID generated successfully but no matching passenger found.");
            return bookingId;
        }

        public static void DisplayFlightDetails(string code)

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
                    if (flight_Code[i] == code)
                    {
                        bookingFlight[i]=flight_Code[i];
                        Console.WriteLine("Flight Code : " + flight_Code[i]);
                        Console.WriteLine("BookingFlight"+ bookingFlight[i]);
                        Console.WriteLine("From City : " + from_City[i]);
                        Console.WriteLine("To City : " + to_City[i]);
                        Console.WriteLine("Departure Time : " + departure_Time[i]);
                        Console.WriteLine("Flight Duration : " + flight_duration[i]);

                        Console.WriteLine("--------view booking flight-----------");






                        for (int j = 0; j < FlightCounter; j++)
                        {
                            if (bookingFlight[i] == flight_Code[j])
                            {
                                Console.WriteLine("Booking Flight : " + bookingFlight[i]);
                                Console.WriteLine("Passenger Name : " + passenger_Name[j]);
                            }
                            else
                            {
                                Console.WriteLine("Booking Flight not found.");
                            }
                            //Console.WriteLine("Passenger Name : " + passenger_Name[i]);
                            //isbooked[j] = true;
                        }
                        
                        Console.WriteLine("Booking ID : " + booking_Id[i]);

                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("Flight code not found.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    StartSystem();

                }

            }


        }


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
        }


        public static int CalculateFare(int basePrice, int numTickets)
        {
            return basePrice * numTickets;


        }

        public static double CalculateFare(double basePrice, int numTickets)
        {
            return basePrice * numTickets;
        }



        public static int CalculateFare(int basePrice, int numTickets, int discount)
        {
            return (basePrice * numTickets) - discount;
        }


        public static bool ConfirmAction(string action)
        {
            Console.WriteLine($"Are you sure you want to {action} ? (y / n) : ");
            return Console.ReadKey().KeyChar == 'y' || Console.ReadKey().KeyChar == 'Y';
        }












    }
}
