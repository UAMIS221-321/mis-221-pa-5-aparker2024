namespace mis_221_pa_5_aparker2024
{
    public class ReportsMenu
    {
        private ListingFunctions[] listings;
        private Trainer[] trainers;
        private Booking[] bookings;

        public ReportsMenu()
        {

        }
        public ReportsMenu(Trainer[] trainers, ListingFunctions[] listings, Booking[] bookings)
        {
            this.trainers = trainers;
            this.listings = listings;
            this.bookings = bookings;
        }   


        public void ReportingMenu(Trainer[] trainers, ListingFunctions[] listings, Booking[] bookings)
        {
            Console.Clear();
            BookingReports bookingReport = new BookingReports();
            BookingUtility bookingUtilities = new BookingUtility(trainers, listings, bookings);
            ListingUtility listingUtility1 = new ListingUtility(trainers, listings);
            ListingReports listingReports = new ListingReports(listings);
            ReportingUtility reportingUtilities = new ReportingUtility(trainers, listings, bookings);
            ReportingReports reportingReport = new ReportingReports();

            System.Console.WriteLine("Which would you like to do??\n");
            System.Console.WriteLine("1. View Individual Sessions\n2. View All Customer Session\n3. View Revenue Report\n4. Exit ");
            int reportingMenu = int.Parse(Console.ReadLine());

            if (reportingMenu == 1)
            {
                bookingUtilities.GetBookingsFromfile(bookings);
                reportingUtilities.IndividualCustomerSessions(bookings);
                ListingFunctions.PauseIt();
                ReportingMenu(trainers, listings, bookings);
                
            }
            else if (reportingMenu == 2)
            {
                bookingUtilities.GetBookingsFromfile(bookings);
                reportingUtilities.HistoricalCustomerSessions(bookings);
                bookingReport.PrintAllBookings(bookings);
                ListingFunctions.PauseIt();
                ReportingMenu(trainers, listings, bookings);
            }
            else if (reportingMenu == 3)
            {
                listingUtility1.GetListingsFromFile(listings);
                bookingUtilities.GetBookingsFromfile(bookings);
                reportingUtilities.RevenueReport(listings, bookings);
                ListingFunctions.PauseIt();
                ReportingMenu(trainers, listings, bookings);
            }
            else if (reportingMenu == 4)
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
                ReportingMenu(trainers, listings, bookings);
            }
        }
    }
}