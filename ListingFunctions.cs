namespace mis_221_pa_5_aparker2024
{
    public class ListingFunctions
    {
        private int listingID;
        private string trainerName;
        private double sessionCost;
        private string sessionDate;
        private string sessionTime;
        private bool listTaken;

        static private int count;

        public ListingFunctions()
        {

        }

        public ListingFunctions(int listingID, string trainerName, double sessionCost, string sessionDate, string sessionTime, bool listTaken )
        {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionCost = sessionCost;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            SetListTaken(false);

        }


        public void SetListingID(int listingID)
        {
            this.listingID = listingID;
        }

        public void SetTrainersName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public void SetCostOfSession(double sessionCost)
        {
            this.sessionCost =sessionCost;
        }
        public void SetDateOfSession(string sessionDate)
        {
            this.sessionDate =sessionDate;
        }
        public void SetTimeOfSession(string sessionTime)
        {
            this.sessionTime =sessionTime;
        }


        public int GetListingID()
        {
            return listingID;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }

        public double GetCostOfSession()
        {
            return sessionCost;
        }


        public string GetDateOfSession()
        {
            return sessionDate;
        }


        public string GetTimeOfSession()
        {
            return sessionTime;
        }


        public bool GetListTaken()
        {
            return listTaken;
        }

        public void SetListTaken(bool listTaken)
        {
            this.listTaken = listTaken;
        }

        static public void SetCount(int listingID)
        {
            ListingFunctions.count = listingID;
        }
        static public int GetCount()
        {
            return ListingFunctions.count;
        }

        static public int IncCount()
        {
            return count++;
        }
        static public int DecCount()
        {
            return count--;
        }

        public string ListingToFile()
        {
            return$"{listingID}#{trainerName}#{sessionCost}#{sessionDate}#{sessionTime}#{listTaken}";
          
        }
        public string ListingToString()
        {
            return$"Listing id: {listingID}\tTrainer Name: {trainerName}\tSession Cost: {sessionCost}\tSession Date: {sessionDate}\tSession Time: {sessionTime}";
        }
    }
}