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

        public int GetBookingID()
        {
            return bookingID;
        }
         public void SetBookingID(int bookingID)
        {
            this.bookingID = bookingID;
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


        static public void SetBookingCount(int bookingCount)
        {
            Booking.bookingCount = bookingCount;
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

          
            if (sessionStatus == false)
            {
                System.Console.WriteLine("Was this session Cancelled or Completed?\t\tenter 'CA' or 'CO'");
                string cancelledCompleted = Console.ReadLine();
                if (cancelledCompleted.ToUpper() == "CA")
                {
                    return $"Booking ID: {bookingID}\t\tCustomer Name: {customerName}\t\tCustomer Email: {customerEmail}\t\tTraining Date: {trainingDate}Trainer: {bookedTrainerID} {bookedTrainerName}\t\tSession Status: Cancelled";
                }

                else if (cancelledCompleted.ToUpper() == "CO")
                {
                    return $"Booking ID: {bookingID}\t\tCustomer Name: {customerName}\t\tCustomer Email: {customerEmail}\t\tTraining Date: {trainingDate}Trainer: {bookedTrainerID} {bookedTrainerName}\t\tSession Status: Completed";
                }
                else
                {
                    System.Console.WriteLine("Invalid option");
                    PauseIt();
                    BookingToFile();
                }
               
            }
            return $"Booking ID: {bookingID}\t\tCustomer Name: {customerName}\t\tCustomer Email: {customerEmail}\t\tTraining Date: {trainingDate}\t\tTrainer: {bookedTrainerID}. {bookedTrainerName}\t\tSession Status: booked";
            
        }
    }
}


    
