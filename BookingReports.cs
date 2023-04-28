namespace mis_221_pa_5_aparker2024
{
    public class BookingReports
    {
        Booking[] bookings;

        public BookingReports()
        {

        }

        public BookingReports(Booking[] bookings)
        {
            this.bookings = bookings;
        }

        public void PrintAllBookings(Booking[] bookings)
        {
            for (int i = 0; i < Booking.GetBookingCount(); i++)
            {
                System.Console.WriteLine(bookings[i].BookingToString());
            }
        }
    }
}