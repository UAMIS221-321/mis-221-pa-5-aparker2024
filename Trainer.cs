namespace mis_221_pa_5_aparker2024
{
    public class Trainer
    {
        private int trainerID;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmail;

        static private int count;

        public Trainer()
        {

        }

        public Trainer(int trainerID, string trainerName, string mailingAddress, string trainerEmail)
        {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.trainerEmail = trainerEmail;
        }

        public int GetTrainerID()
        {
            return trainerID;
        }
        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
      

        public string GetMailingAddress()
        {
            return mailingAddress;
        }

        public void SetMailingAddress(string mailingAddress)
        {
            this.mailingAddress = mailingAddress;
        }
        
        public string GetTrainerEmail()
        {
            return trainerEmail;
        }

        public void SetTrainerEmail(string trainerEmail)
        {
            this.trainerEmail = trainerEmail;
        }


        static public void SetCount(int trainerID)
        {
            Trainer.count = trainerID;
        }
        static public int GetCount()
        {
            return Trainer.count;
        }

        static public int IncCount()
        {
            return count++;
        }
        static public int DecCount()
        {
            return count--;
        }

        public string TrainerToFile()
        {
            return $"{trainerID}#{trainerName}#{mailingAddress}#{trainerEmail}";
        }
        
        public string TrainerToString()
        {
            return$"Trainer ID: {trainerID}\t\tTrainer Name: {trainerName}\t\tMailing address: {mailingAddress}\t\tTrainer E-mail: {trainerEmail}";
        }


        
    }
}