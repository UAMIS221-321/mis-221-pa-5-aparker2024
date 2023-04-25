namespace mis_221_pa_5_aparker2024
{
    public class Booking
    {
        private int bookingID;
        private string customerName;
        private string customerEmail;
        private string trainingDate;
        private int bookedTrainerID;
        private string bookedTrainerName;
        private bool sessionStatus;

        static private int bookingCount;
        
        public Booking()
        {

        }
        public Booking(int bookingID, string customerName, string customerEmail, string trainingDate, int bookedTrainerID, string bookedTrainerName, bool sessionStatus)
        {
            this.bookingID = bookingID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.bookedTrainerID = bookedTrainerID;
            this.bookedTrainerName = bookedTrainerName;
            this.sessionStatus = sessionStatus;
        }

         public void SetBookingID(int bookingID)
        {
            this.bookingID = bookingID;
        }
        public int GetBookingID()
        {
            return bookingID;
        }

        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetCustomerName()
        {
            return customerName;
        }

        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail()
        {
            return customerEmail;
        }

        public void SetTrainingDate(string trainingDate)
        {
            this.trainingDate = trainingDate;
        }
       
       public string GetTrainingDate()
       {
            return trainingDate;
       }
       public void SetBookedTrainerID(int bookedTrainerID)
       {
            this.bookedTrainerID = bookedTrainerID;
       }
       public int GetBookedTrainerID()
       {
        return bookedTrainerID;
       }

       public void SetBookedTrainerName(string bookedTrainerName)
       {
            this.bookedTrainerName = bookedTrainerName;
       }
       public string GetBookedTrainerName()
       {
            return bookedTrainerName;
       }

       public void SetSessionStatus(bool sessionStatus)
       {
        this.sessionStatus = sessionStatus;
       }
        public bool GetSessionStatus()
        {
            return sessionStatus;
        }


        static public void SetBookingCount(int bookingID)
        {
            Booking.bookingCount = bookingID;
        }
        static public int GetBookingCount()
        {
            return Booking.bookingCount;
        }

        static public int IncCount()
        {
            return bookingCount++;
        }
        static public int DecCount()
        {
            return bookingCount--;
        }
        
       static public void PauseIt()
        {
            System.Console.WriteLine("Enter any key to continue");
            Console.ReadKey();
        }

        public string BookingToFile()
        {
            return$"{bookingID}#{customerName}#{customerEmail}#{trainingDate}#{bookedTrainerID}#{bookedTrainerName}#{sessionStatus}";
          
        }
        public string BookingToString()
        {

            return $"Booking id: {bookingID}\tCustomer Name: {customerName}\tCustomer Email: {customerEmail}\tTraining Date: {trainingDate}\tBooked Trainer ID: {bookedTrainerID}\tBooked Trainer Name: {bookedTrainerName}";
            
        }
    }
}


    
