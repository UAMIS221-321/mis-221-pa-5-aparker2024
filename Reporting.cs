namespace mis_221_pa_5_aparker2024
{
    public class Reporting
    {
        private Trainer[] trainers;
        private ListingFunctions[] listings;
        private Booking[] bookings;

        private int totalSessions;


        public Reporting()
        {

        }

        public Reporting(Trainer[] trainers, ListingFunctions[] listings, Booking[] bookings)
        {
            this.trainers = trainers;
            this.listings = listings;
            this.bookings = bookings;
        }

        public int GetTotalSession()
        {
            return totalSessions;
        }
        public void SetTotalSessioms(int totalSessions)
        {
            this.totalSessions = totalSessions;
        }

       
    }
}