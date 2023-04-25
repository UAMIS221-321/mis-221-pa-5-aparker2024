namespace mis_221_pa_5_aparker2024
{
    public class ListingMenu
    {
        private ListingFunctions[] listings;

        public ListingMenu()
        {

        }

        public ListingMenu(ListingFunctions[] listings)
        {
            this.listings = listings;
        }

        public void ListingsMenu(ListingFunctions[] listings, Trainer[] trainers)
        {

            Console.Clear();
            ListingUtility listingFunctions = new ListingUtility(trainers, listings);
            ListingReports listingsReports = new ListingReports(listings);
            System.Console.WriteLine("Which function would you like to perform????");
            System.Console.WriteLine("1. Add listing\n2. Edit Listing info\n3. Delete Listing\n4. Exit to Menu");
            int listingMenu = int.Parse(Console.ReadLine());
            if (listingMenu == 1)
            {
                Console.Clear();
                listingFunctions.GetListingsFromFile(listings);
                listingFunctions.AddListing(trainers, listings);
                ListingsMenu(listings,trainers);
                
            }
            else if (listingMenu == 2)
            {
                Console.Clear();
                listingFunctions.GetListingsFromFile(listings);
                listingsReports.PrintAllListings();   
                listingFunctions.EditListing(listings, trainers);
                ListingsMenu(listings,trainers);
            }
            else if(listingMenu == 3)
            {
                Console.Clear();
                listingFunctions.GetListingsFromFile(listings);
                listingsReports.PrintAllListings();
                listingFunctions.DeleteListing(listings);
                ListingsMenu(listings,trainers);
            }
            else if (listingMenu == 4)
            {
                Console.Clear();
                Menu menuOption = new Menu();
                menuOption.MenuToString();
                menuOption.SetMenuOption(int.Parse(Console.ReadLine()));
                menuOption.RouteEm(trainers, listings);
            }
            else
            {
                System.Console.WriteLine("Invalid!");
                ListingFunctions.PauseIt();
                ListingsMenu(listings, trainers);
            }  

        }
    }
}