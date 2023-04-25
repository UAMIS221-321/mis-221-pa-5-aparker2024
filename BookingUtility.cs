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

        }

        public void AddBooking(ListingFunctions[] listings)
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
                    MakeSession(listings, trainers);
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
                AddBooking(listings);
            }
        }


        private void MakeSession(ListingFunctions[] listings, Trainer[] trainers)
        {
            System.Console.WriteLine("AVAILABLE TRAINING SESSIONS.....");
            ListingUtility getListing = new ListingUtility(trainers, listings);
            ListingReports printListings = new ListingReports(listings);
            getListing.GetListingsFromFile(listings);
            printListings.PrintAllListings();

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

        private void SaveToBookingFile(Booking[] bookings)
        {
            StreamWriter toBookingFile = new StreamWriter("transactions.txt");

            for (int i = 0; i < Booking.GetBookingCount(); i++)
            {
                toBookingFile.WriteLine(bookings[i].BookingToFile());
            }
            toBookingFile.Close();
        }

        private int FindBooking(int searchListing, Booking[] bookings)
        {
            for (int i = 0; i < Booking.GetBookingCount(); i++)
            {
                return i;
            }

            return -1;
        }
    }
}