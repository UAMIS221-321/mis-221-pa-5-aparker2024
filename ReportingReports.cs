namespace mis_221_pa_5_aparker2024
{
    public class ReportingReports
    {

        private Trainer[] trainers;
        private ListingFunctions[] listings;
        private Booking[] bookings;


        public ReportingReports()
        {

        }

        public ReportingReports(Trainer[] trainers, ListingFunctions[] listings, Booking[] bookings)
        {
            this.trainers = trainers;
            this.listings = listings;
            this.bookings = bookings;
        }
        public void SortByCustomer(Booking[] bookings)
        {
            for (int i = 0; i < Booking.GetBookingCount(); i++)
            {
                int min = i;

                for (int j = i + 1; j < Booking.GetBookingCount(); j++)
                {
                    if (bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName() ) < 0)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    SwapCustomers(min, i, bookings);
                }
            }
        }

        public void SortByDate(Booking[] bookings)
        {
            
            for (int i = 0; i < Booking.GetBookingCount(); i++)
            {
                int totalSessions = 0;
                int min = i;

                for (int j = i + 1; j < Booking.GetBookingCount(); j++)
                {
                  
                    if (bookings[j].GetTrainingDate().CompareTo(bookings[min].GetTrainingDate() ) < 0)
                    {
                        min = j;
                        
                    }      
                   
                }
                if (min != i)
                {
                 SwapCustomers(min, i, bookings);
                }
                
            }
        }


  
          
        public void SwapCustomers(int x, int y, Booking[] bookings)
        {

            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;

        }
        
    }
}