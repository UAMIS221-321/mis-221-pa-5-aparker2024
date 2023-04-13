namespace mis_221_pa_5_aparker2024
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }


        public void AddTrainer()
        {
            System.Console.WriteLine("Are you sure you would like to add a trainer?\n'Y' to continue 'Stop' to stop");
            string addNewTrainer = Console.ReadLine();
            while(addNewTrainer.ToUpper() != "STOP")
            {
                
                System.Console.WriteLine("Updating ID...");
               
                Trainer addTrainer = new Trainer();
                addTrainer.SetTrainerID(Trainer.GetCount() + 1);
                System.Console.WriteLine("\nEnter New Trainers Name");
                addTrainer.SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("\nEnter Their Mail Address");
                addTrainer.SetMailingAddress(Console.ReadLine());
                System.Console.WriteLine("\nFinally, Enter Their Email Addresss");
                addTrainer.SetTrainerEmail(Console.ReadLine());

                trainers[Trainer.GetCount()] = addTrainer;
                Trainer.IncCount();
                SaveToFile();

            System.Console.WriteLine("Are you sure you would like to add a trainer?\n'Y' to continue 'Stop' to stop");
            addNewTrainer = Console.ReadLine();

            }
            

        }


        public void EditTrainer()
        {
            System.Console.WriteLine("Are you sure would like to edit a trainer?\n'Y' to continue 'Stop' to stop");
            string eddTrainer = Console.ReadLine();

            while (eddTrainer.ToUpper() != "STOP")
            {
                System.Console.WriteLine("Enter the ID of the trainer you would like to edit");
                int searchVal = int.Parse(Console.ReadLine());
            
                int foundIndex = FindTrainer(searchVal);
                if (foundIndex != -1)
                {
                    Trainer editingTrainers = trainers[foundIndex];
                    editingTrainers.SetTrainerID(searchVal);
                    System.Console.WriteLine("\nEnter New Trainers Name");
                    editingTrainers.SetTrainerName(Console.ReadLine());
                    System.Console.WriteLine("\nEnter Their Mail Address");
                    editingTrainers.SetMailingAddress(Console.ReadLine());
                    System.Console.WriteLine("\nFinally, Enter Their Email Addresss");
                    editingTrainers.SetTrainerEmail(Console.ReadLine());
                    SaveToFile();
                    System.Console.WriteLine("Trainer information updated!");
                    PauseIt();
                }
                else
                {
                    System.Console.WriteLine("Trainer not found");
                    PauseIt();
                    EditTrainer();

                }

                
            System.Console.WriteLine("Are you sure would like to edit a trainer?\n'Y' to continue 'Stop' to stop");
            eddTrainer = Console.ReadLine();
            }
        }

        public void DeleteTrainer()
        {

            System.Console.WriteLine("Are you sure you would like to Delete a trainer?\n'Y' to continue 'Stop' to stop");
            string deleteTrainer = Console.ReadLine();
            while (deleteTrainer.ToUpper() != "STOP")
            {
            System.Console.WriteLine("Enter the ID of the trainer you would like to remove?\t'-1' to stop");
            int searchTrainer = int.Parse(Console.ReadLine());
            
            int foundIndex = FindTrainer(searchTrainer);
            if(foundIndex != -1)
            {
                for (int i = foundIndex; i < Trainer.GetCount() - 1; i++)
                {
                    trainers[i] = trainers[i + 1];
                }
                    trainers[Trainer.GetCount() - 1] = null;
                    Trainer.DecCount();
                    SaveToFile();
                    System.Console.WriteLine("Trainer Deleted!");
                    PauseIt();
                
            }
            else
            {
                System.Console.WriteLine("Trainer not found");
                PauseIt();
                DeleteTrainer();
            }

            System.Console.WriteLine("Are you sure you would like to Delete a trainer?\n'Y' to continue 'Stop' to stop");
            deleteTrainer = Console.ReadLine();
            }
            
        }

        public void GetTrainersFromFile()
        {
            Trainer.SetCount(0);
            StreamReader inFile = new StreamReader("trainers.txt");
          
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
               line = inFile.ReadLine();
            }

            inFile.Close();
        }

        private int FindTrainer(int searchVal)
        {
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                if (trainers[i].GetTrainerID()== searchVal)
                {
                    return i;
                }
            }
            return -1;
        }
        private void SaveToFile()
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                outFile.WriteLine(trainers[i].TrainerToFile());
            }
            outFile.Close();
        }

        public void PauseIt()
        {
            System.Console.WriteLine("Enter any key to continue");
            Console.ReadKey();
        }
    }
}