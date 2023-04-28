namespace mis_221_pa_5_aparker2024
{
    public class BookMenu
    {       
         private ListingFunctions[] listings;
        private Trainer[] trainers;
        private Booking[] bookings;

        public BookMenu()
        {

        }
        public BookMenu(Trainer[] trainers, ListingFunctions[] listings, Booking[] bookings)
        {
            this.trainers = trainers;
            this.listings = listings;
            this.bookings = bookings;
        }

        public void BookingMenu(ListingFunctions[] listings, Trainer[] trainers)
        {
            Console.Clear();
            BookingReports bookingReport = new BookingReports();
            BookingUtility bookingUtilities = new BookingUtility();
            ListingUtility listingUtility1 = new ListingUtility();
            ListingReports listingReports = new ListingReports(listings);
            System.Console.WriteLine("Which would you like to do??\n");
            System.Console.WriteLine("1. View all Sessions\n2. Book a Session\n3. Exit");
            int bookingMenu = int.Parse(Console.ReadLine());

            if (bookingMenu == 1)
            {
                Console.Clear();
                listingUtility1.GetListingsFromFile(listings);
                listingReports.PrintAllListings();
                ListingFunctions.PauseIt();
                BookingMenu(listings, trainers);


            }
            else if(bookingMenu == 2)
            {
                Console.Clear();
                bookingUtilities.AddBooking(trainers, listings);
            }
            else if (bookingMenu == 3)
            {
                System.Console.WriteLine("You will now be sent back to the menu");
                Console.Clear();
                Menu menuOption = new Menu();
                menuOption.MenuToString();
                menuOption.SetMenuOption(int.Parse(Console.ReadLine()));
                menuOption.RouteEm(trainers, listings, bookings);
            }
            else
            {
                System.Console.WriteLine("Invalid");
                ListingFunctions.PauseIt();
                BookingMenu(listings, trainers);
            }

        }
    }
}