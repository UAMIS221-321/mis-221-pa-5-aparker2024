using mis_221_pa_5_aparker2024;

Trainer[] trainers = new Trainer[50];
ListingFunctions[] listings = new ListingFunctions[50]; 
Booking[] bookings = new Booking[50];

Menu menuOption = new Menu();

menuOption.MenuToString();
menuOption.SetMenuOption(int.Parse(Console.ReadLine()));
menuOption.RouteEm(trainers, listings, bookings);

// Reporting customerReports = new Reporting();
// BookingUtility bookUtility = new BookingUtility(trainers,listings,bookings);
// BookingReports newReprt = new BookingReports();
// bookUtility.GetBookingsFromfile(bookings);
// // newReprt.PrintAllBookings(bookings);
// // customerReports.IndividualCustomerSessions(bookings);

// // ListingUtility listingUtility = new ListingUtility();
// // ListingReports listingReports = new ListingReports(listings);
// // listingUtility.GetListingsFromFile(listings);
// // bookUtility.GetBookingsFromfile(bookings);
// // customerReports.RevenueReport(listings, bookings);
// ReportingUtility reportingUtility = new ReportingUtility(trainers, listings,bookings);
// ReportingReports reportingReports = new ReportingReports();

// reportingUtility.IndividualCustomerSessions(bookings);


