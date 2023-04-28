namespace mis_221_pa_5_aparker2024
{
    public class ReportingUtility
    {
        private ListingFunctions[] listings;
        private Trainer[] trainers;
        private Booking[] bookings;

        public ReportingUtility()
        {

        }
        public ReportingUtility(Trainer[] trainers, ListingFunctions[] listings, Booking[] bookings)
        {
            this.trainers = trainers;
            this.listings = listings;
            this.bookings = bookings;
        }


 public void IndividualCustomerSessions(Booking[] bookings)
        {
            
            System.Console.WriteLine("Enter the userName for your search");
            string userName = Console.ReadLine() + "@crimson.ua.edu";
            System.Console.WriteLine("\nAll of Your sessions:");
            bool foundBooking = false;
            for (int i = 0; i < Booking.GetBookingCount(); i++)
            {
                if (userName.ToUpper() == bookings[i].GetCustomerEmail().ToUpper())
                {
                 System.Console.WriteLine(bookings[i].BookingToString());
                 foundBooking= true;
                 

                } 
            }  
            
            if (!foundBooking)
            {
                System.Console.WriteLine("No booking found!");
                IndividualCustomerSessions(bookings);
            }
            
        }

        public void HistoricalCustomerSessions(Booking[] bookings)
        {
            ReportingReports reportingReports = new ReportingReports();
            System.Console.WriteLine("do you want to sort by date or customer");
            string dateOrCustomer = Console.ReadLine();
            if (dateOrCustomer.ToUpper() == "DATE")
            {
                reportingReports.SortByDate(bookings);
            }
            else if(dateOrCustomer.ToUpper() == "CUSTOMER")
            {
                reportingReports.SortByCustomer(bookings);
            }
            else
            {
                System.Console.WriteLine("invalid");
                HistoricalCustomerSessions(bookings);
            }
        }

        public void RevenueReport(ListingFunctions[] listings, Booking[] bookings)
        {
            string months = "Janurary Feburary March April May June July August September October November Decemeber";
            string days = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31";
            string[] calenderMonths = months.Split(' ');
            string[] calenderDays = days.Split(',');
            double monthlyRevenue = 0;
            for (int i = 0; i < Booking.GetBookingCount(); i++)
            {
                for (int j = 0; j < calenderMonths.Length; j++)
                {
                    for (int k = 0; k < calenderDays.Length; k++)
                    { 
                        
                        if (calenderMonths[j].ToUpper() + " " + calenderDays[k] == bookings[i].GetTrainingDate().ToUpper())
                        {
                            months = calenderMonths[j];
                            monthlyRevenue += listings[i].GetCostOfSession();
                            
                        }
                    }
                }
                
            }
            System.Console.WriteLine($"The Total Revenue for {months} is... ${monthlyRevenue}");
        }
       
    }
}