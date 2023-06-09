namespace mis_221_pa_5_aparker2024
{
    public class Menu
    {
       
        private int menuChoice;

        public Menu()
        {

        }

        public Menu(int menuChoice)
        {
            this.menuChoice = menuChoice;
        }

        public int GetMenuOption()
        {
            return menuChoice;
        }

        public void SetMenuOption(int menuChoice)
        {
            this.menuChoice = menuChoice;
        }


        public void MenuToString()
        {
            
            System.Console.WriteLine("Which Section would you like to view...");
            System.Console.WriteLine("1.\tTrainer Data\n2.\tListing Data\n3.\tCustomer Booking\n4.\tReports\n5.\tExit Program");

        }

        public void RouteEm(Trainer[] trainers,ListingFunctions[] listings, Booking[] bookings)
        {
            switch (menuChoice)
            {
                case 1:
                    TrainerMenu trainerMenuOptions = new TrainerMenu(trainers);
                    trainerMenuOptions.TrainersMenu(trainers);
                    break;
                case 2:
                    ListingMenu listingMenuOptions = new ListingMenu(listings);
                    listingMenuOptions.ListingsMenu(listings, trainers, bookings);
                    break;
                case 3:
                   BookMenu newBookingMenu = new BookMenu();
                   newBookingMenu.BookingMenu(listings, trainers);
                    break;
                case 4:
                    ReportsMenu newReportingMenu = new ReportsMenu();
                    newReportingMenu.ReportingMenu(trainers,listings, bookings);
                    break;
                case 5:
                    System.Console.WriteLine("GGs mate");
                    break;
                default:
                    break;
            }

        }

    }

}