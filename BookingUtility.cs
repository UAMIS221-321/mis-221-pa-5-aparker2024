namespace mis_221_pa_5_aparker2024
{
    public class BookingUtility
    {
        private ListingFunctions[] listings;
        private Trainer[] trainers;
        private Booking[] bookings;

        public BookingUtility()
        {

        }
        public BookingUtility(Trainer[] trainers, ListingFunctions[] listings, Booking[] bookings)
        {
            this.trainers = trainers;
            this.listings = listings;
            this.bookings = bookings;
        }

        public void AddBooking(Trainer[] trainers, ListingFunctions[] listings)
        {
            System.Console.WriteLine("Are you sure you would like to book a session? 'Y' or 'N'");
            string addBooking = Console.ReadLine();

            if(addBooking.ToUpper() == "Y")
            {
                System.Console.WriteLine("Enter 'STOP' to stop adding");
                Booking.PauseIt();
                Console.Clear();
                while (addBooking.ToUpper() != "STOP")
                {
                    MakeSession(trainers, listings);
                    System.Console.WriteLine("Enter 'STOP' to stop adding\tEnter 'Y' to add another");
                    addBooking = Console.ReadLine();   
                }

            }
            else if(addBooking.ToUpper() == "N")
            {
                System.Console.WriteLine("You will now be sent back to the menu");
            }
            else
            {
                System.Console.WriteLine("Invalid");
                Booking.PauseIt();
                AddBooking(trainers, listings);
            }
        }


        private void MakeSession(Trainer[] trainers, ListingFunctions[] listings)
        {
            System.Console.WriteLine("AVAILABLE TRAINING SESSIONS.....");
            ListingUtility getListing = new ListingUtility(trainers, listings);
            ListingReports printListings = new ListingReports(listings);
            TrainerUtility getAllTrainer = new TrainerUtility(trainers);
            getAllTrainer.GetTrainersFromFile();
            getListing.GetListingsFromFile(listings);
            printListings.PrintAllListings();

            System.Console.WriteLine($"\nPlease enter The Id of the session you would like to book");
            int searchListID = int.Parse(Console.ReadLine());

            int foundListing = getListing.FindListing(searchListID, listings);
            int findTrainer = getAllTrainer.FindTrainer(searchListID);
            

            if (foundListing != -1 && bookings[searchListID -1].GetSessionStatus() != true) 
            {   
                
                Booking bookingSession = new Booking();   
                       

                bookingSession.SetBookingID(Booking.GetBookingCount() + 1);
                System.Console.WriteLine($"Booking ID: {bookingSession.GetBookingID()}");
                System.Console.WriteLine("Please Enter your Name: ");
                bookingSession.SetCustomerName(Console.ReadLine());
                System.Console.WriteLine("Please Enter your User Name");
                bookingSession.SetCustomerEmail(Console.ReadLine() + "@crimson.ua.edu");

                bookingSession.SetTrainingDate(listings[searchListID -1].GetDateOfSession());
                System.Console.WriteLine($"Your session is set for: {bookingSession.GetTrainingDate()} at {listings[foundListing].GetTimeOfSession()} ");
            
                int nameID = FindNameID(listings[searchListID-1].GetTrainerName(), trainers, bookings);
                
                if (nameID != -1)
                {
                    bookingSession.SetBookedTrainerID(nameID + 1);
                }
                else
                {
                    System.Console.WriteLine("no ID found");
                }
                bookingSession.SetBookedTrainerName(listings[searchListID - 1].GetTrainerName());   
                System.Console.WriteLine($"With our trainer {bookingSession.GetBookedTrainerID()}: {bookingSession.GetBookedTrainerName()}");
                System.Console.WriteLine("You are all booked!! Thank you");
                bookingSession.SetSessionStatus(true);

                

                bookings[Booking.GetBookingCount()] = bookingSession;
                Booking.IncCount();
                SaveToBookingFile();


            }
                else if(bookings[searchListID -1].GetSessionStatus() == true) {
                System.Console.WriteLine("sesssion unavailable");

            }

        }


        public void GetBookingsFromfile(Booking[] bookings)
        {
            Booking.SetBookingCount(0);
            StreamReader inFile = new StreamReader("transactions.txt");

            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                bookings[Booking.GetBookingCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], bool.Parse(temp[6]));
                Booking.IncCount();
                line = inFile.ReadLine();

            }
            inFile.Close();
        }

        private void SaveToBookingFile()
        {
            StreamWriter toBookingFile = new StreamWriter("transactions.txt");

            for (int i = 0; i < Booking.GetBookingCount(); i++)
            {
                toBookingFile.WriteLine(bookings[i].BookingToFile());
            }
            toBookingFile.Close();
        }

        private int FindBooking(int searchBooking, Booking[] bookings, ListingFunctions[] listings)
        {
            for (int i = 0; i < Booking.GetBookingCount(); i++)
            {
                if (bookings[i].GetBookingID() == searchBooking)
                {
                    return i;
                }
            }

            return -1;
        }

        private int FindNameID(string name, Trainer[] trainers, Booking[] bookings)
        {
        
                
                    for (int j = 0; j < Trainer.GetCount(); j++)
                    {
                        if( trainers[j].GetTrainerName() == name)
                        {

                            return j;
                        }
                    }
                

            return -1 ;
        }
    }
}