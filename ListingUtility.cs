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

        public void GetToListing(Trainer [] trainers, ListingFunctions[] listings)
        {

            TrainerUtility getTrainers = new TrainerUtility(trainers);
            TrainerReports printTrainers = new TrainerReports(trainers);

            System.Console.WriteLine("Are you sure you would like to Add a trainer to Listing?\n'Y' or 'N' to continue 'Stop' to stop");
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
                    AddToListing(foundIndex, trainers, listings); 
                }

                else
                {
                    System.Console.WriteLine("Trainer not found");
                    getTrainers.PauseIt();
                    Console.Clear();
                    GetToListing(trainers, listings);
                }

                System.Console.WriteLine("Are you sure you would like to Add a trainer to Listing?\n'Y' to continue 'Stop' to stop");
                addToListing = Console.ReadLine();
             
                }
           }

           else if(addToListing.ToUpper() == "N")
           {
                System.Console.WriteLine("You will now be sent back to the Menu");
                ListingFunctions.PauseIt();
           }
           else
           {
                System.Console.WriteLine("invalid");
                GetToListing(trainers, listings);
           }
        }
        //
        //
        //
        //
        //
        //
        //
        //
        // MAYBE ADD ADDITIONAL TRAINING FEES AND DIFFERENT ADD ONS FOR TRAINERS

        public void AddToListing(int foundIndex, Trainer[] trainers, ListingFunctions[] listings)
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

 
            CheckAviavable(makeListing, listings);  
            
            listings[ListingFunctions.GetCount()] = makeListing;
            ListingFunctions.IncCount();
            SaveToListingFile(listings);
        }


        public void EditListing(ListingFunctions[] listings, Trainer[] trainers)
        {
            
            System.Console.WriteLine("Are you sure would like to edit a listing?\t'Y' to continue 'Stop' to stop");
            string eddTrainer = Console.ReadLine();

            while (eddTrainer.ToUpper() != "STOP")
            {
                System.Console.WriteLine("Enter the ID of the listing you would like to edit");
                int searchVal = int.Parse(Console.ReadLine());
            
                int foundIndex = FindListing(searchVal, listings);
                
                if (foundIndex != -1)
                {
                    

                    ListingFunctions editingListings = listings[foundIndex];
                    editingListings.SetListingID(searchVal); // set the ID equal to the search





                    TrainerUtility getTrainers = new TrainerUtility(trainers);
                    TrainerReports printReports = new TrainerReports(trainers);
                    getTrainers.GetTrainersFromFile();
                    printReports.PrintAlltrainers();
                    System.Console.WriteLine("\nSelect ID of trainer you would like to change to");
                    int searchID = int.Parse(Console.ReadLine());

                    int foundID = FindListing(searchID, listings);
                    if (foundID != -1 )
                    {
                        editingListings.SetTrainersName(listings[searchID].GetTrainerName());
                    }
                    System.Console.WriteLine(editingListings.GetTrainerName());

                    if(editingListings.GetTrainerName() == "Antonio Parker" && editingListings.GetListTaken() == false)
                    {
                        editingListings.SetCostOfSession(100.10);
                        System.Console.WriteLine($"The cost is {editingListings.GetCostOfSession()} ");
                    
                    }
                    else
                    {
                        editingListings.SetCostOfSession(75.70);
                        System.Console.WriteLine($"The cost is {editingListings.GetCostOfSession()} "); 
                    }
                    System.Console.WriteLine("Enter in the date...");
                    editingListings.SetDateOfSession(Console.ReadLine());
                    System.Console.WriteLine("Enter in a new time");
                    editingListings.SetTimeOfSession(Console.ReadLine());
                    System.Console.WriteLine("Listing updated!!!");
                    editingListings.SetListTaken(false);

                    SaveToListingFile(listings);
                    System.Console.WriteLine("Listing information updated!");
                   
                }
                else
                {
                    System.Console.WriteLine("Listing not found");
                    ListingFunctions.PauseIt();
                    EditListing(listings, trainers);
                }
        
                System.Console.WriteLine("Are you sure would like to edit a trainer?\n'Y' to continue 'Stop' to stop");
                eddTrainer = Console.ReadLine();

            }
        }

        public void DeleteListing(ListingFunctions[] listings)
        {

            System.Console.WriteLine("Are you sure you would like to Delete a listing?\n'Y' to continue 'Stop' to stop");
            string deleteListing = Console.ReadLine();
            while (deleteListing.ToUpper() != "STOP")
            {
                System.Console.WriteLine("Enter the ID of the listing you would like to remove?\t'-1' to stop");
                int searchListings = int.Parse(Console.ReadLine());
                
                int foundIndex = FindListing(searchListings, listings);
                if(foundIndex != -1)
                {
                    for (int i = foundIndex; i < ListingFunctions.GetCount(); i++)
                    {
                        listings[i].SetListingID(listings[i].GetListingID() - 1 );
                    }

                    ListingFunctions removedListing = listings[foundIndex];
                    for (int i = foundIndex; i < ListingFunctions.GetCount() - 1; i++)
                    {
                        listings[i] = listings[i + 1];
                    }
                    
                    ListingFunctions.DecCount();
                    listings[ListingFunctions.GetCount()] = null;
 
                    SaveToListingFile(listings);
                    System.Console.WriteLine("Listing Deleted!");
                         
                }
                else
                {
                    System.Console.WriteLine("Listing not found");
                    ListingFunctions.PauseIt();
                    DeleteListing(listings);
                }

                System.Console.WriteLine("Are you sure you would like to Delete a listing?\n'Y' to continue 'Stop' to stop");
                deleteListing = Console.ReadLine();
            }            
        }

        public void CheckAviavable(ListingFunctions makeListing, ListingFunctions[] listings)
        {

            for (int i = 0; i <ListingFunctions.GetCount() ; i++)
            {      
                if(listings[i].GetDateOfSession() == makeListing.GetDateOfSession() && listings[i].GetTimeOfSession() == makeListing.GetTimeOfSession())
                {
                    
                    System.Console.WriteLine("session not avialable please select another time");
                    System.Console.WriteLine($"New date: ");
                    makeListing.SetDateOfSession(Console.ReadLine());
                    System.Console.WriteLine($"New time: ");
                    makeListing.SetTimeOfSession(Console.ReadLine());
                    CheckAviavable(makeListing, listings);

                }  
                else if(listings[i].GetDateOfSession() != makeListing.GetDateOfSession() && listings[i].GetTimeOfSession() == makeListing.GetTimeOfSession() )
                {
                    
                    System.Console.WriteLine("Session unavaiable...");
                    System.Console.WriteLine("Please enter a new time:");
                    makeListing.SetTimeOfSession(Console.ReadLine());
                    CheckAviavable(makeListing,listings);
                }   
            }    

            System.Console.WriteLine("all set!!");    
            makeListing.SetListTaken(false);  
        }


        public void GetListingsFromFile(ListingFunctions[] listings)
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


        public int FindListing(int searchListing, ListingFunctions[] listings)
        {
            for (int i = 0; i < ListingFunctions.GetCount(); i++)
            {
                if (listings[i].GetListingID() == searchListing)
                {
                    return i;
                }
            }

            return -1;
        }  

    }
}