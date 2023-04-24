namespace mis_221_pa_5_aparker2024
{
    public class ListingUtility
    {
        private Trainer[] trainers;
        private ListingFunctions[] listings;

        public ListingUtility()
        {

        }

        public ListingUtility(Trainer[] trainers, ListingFunctions[] listings)
        {
            this.trainers = trainers;
            this.listings = listings;
        }

        public void AddToListing(Trainer [] trainers, ListingFunctions[] listings)
        {

            TrainerUtility getTrainers = new TrainerUtility(trainers);
            TrainerReports printTrainers = new TrainerReports(trainers);

            System.Console.WriteLine("Are you sure you would like to Add a trainer to Listing?\n'Y'\'N' to continue 'Stop' to stop");
            string addToListing = Console.ReadLine();

           if (addToListing.ToUpper() == "Y")
           {
             while (addToListing.ToUpper() != "STOP")
             {
                 
                 getTrainers.GetTrainersFromFile();
                 printTrainers.PrintAlltrainers();
 
 
                 System.Console.WriteLine("Which trainer would you like to add to listing?");
                 int searchTrainer = int.Parse(Console.ReadLine());
 
             
                 int foundIndex = getTrainers.FindTrainer(searchTrainer);
                     
                     if (foundIndex != -1)
                     {
 
                         Trainer foundTrainer = trainers[foundIndex];
                         string trainerNames = foundTrainer.GetTrainerName();
 
                         ListingFunctions makeListing = new ListingFunctions();
                         makeListing.SetListingID(ListingFunctions.GetCount() + 1);
                         makeListing.SetTrainersName(trainerNames);
 
                         System.Console.WriteLine($"listing id: {makeListing.GetListingID()}");
                         System.Console.WriteLine($"You selected:\t{trainerNames}");
 
                         if(foundTrainer.GetTrainerName() == "Antonio Parker" && makeListing.GetListTaken() == false)
                         {
                         makeListing.SetCostOfSession(100.10);
                         System.Console.WriteLine($"The cost is {makeListing.GetCostOfSession()} ");
                         
                         }
                         else
                         {
                         makeListing.SetCostOfSession(75.70);
                         System.Console.WriteLine($"The cost is {makeListing.GetCostOfSession()} "); 
                         }
 
                         System.Console.WriteLine("Please select the day you would like to train\t\tformat ex: 'April 13'");
                         makeListing.SetDateOfSession(Console.ReadLine());
 
                         System.Console.WriteLine("Please select a time?\t\tformat ex: '11:30'");
                         makeListing.SetTimeOfSession(Console.ReadLine());
                         
                         if(makeListing.GetListTaken() == true)
                         {
                             System.Console.WriteLine("time not avialable please select another time");
                             makeListing.SetListTaken(bool.Parse(Console.ReadLine()));
                             while (makeListing.GetListTaken() != false )
                             {
                                 System.Console.WriteLine("time not avialable please select another time");
                                 makeListing.SetListTaken(bool.Parse(Console.ReadLine()));
                                 
                             }
                         }   
                         else{
                             System.Console.WriteLine("All set!!!");
                             makeListing.SetListTaken(true);
                         }                
                         
                         listings[ListingFunctions.GetCount()] = makeListing;
                         ListingFunctions.IncCount();
                         SaveToListingFile(listings);
                     }
 
                     else
                     {
                         System.Console.WriteLine("Trainer not found");
                         getTrainers.PauseIt();
                         Console.Clear();
                         AddToListing(trainers, listings);
 
                     }
 
                     System.Console.WriteLine("Are you sure you would like to Add a trainer to Listing?\n'Y' to continue 'Stop' to stop");
                     addToListing = Console.ReadLine();
             
             }
           }
           else if(addToListing.ToUpper() == "N")
           {
            System.Console.WriteLine("bye bye");
           }
           else
           {
            System.Console.WriteLine("invalid");
           }
        }

        public void GetListingsFromFile()
        {
            ListingFunctions.SetCount(0);
            StreamReader inFile = new StreamReader("listings.txt");

            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                listings[ListingFunctions.GetCount()] = new ListingFunctions(int.Parse(temp[0]), temp[1], double.Parse(temp[2]), temp[3], temp[4], bool.Parse(temp[5]));
                ListingFunctions.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }


        public void SaveToListingFile(ListingFunctions[] listings)
        {
         
                StreamWriter outToFile = new StreamWriter("listings.txt");
    
                for (int i = 0; i < ListingFunctions.GetCount(); i++)
                {
                    outToFile.WriteLine(listings[i].ListingToFile());
                }
                outToFile.Close();
            
        }
            
        
    }
}