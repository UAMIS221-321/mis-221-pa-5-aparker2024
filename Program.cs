using mis_221_pa_5_aparker2024;

Trainer[] trainers = new Trainer[50];
ListingFunctions[] listings = new ListingFunctions[50]; 

Menu menuOption = new Menu();

menuOption.MenuToString();
menuOption.SetMenuOption(int.Parse(Console.ReadLine()));
menuOption.RouteEm(trainers, listings);

// ListingUtility list = new ListingUtility();
// ListingReports listreports = new ListingReports(listings);
// list.GetListingsFromFile(listings);
// listreports.PrintAllListings();
// list.DeleteListing(listings);
//list.GetToListing(trainers, listings); // add to listing
