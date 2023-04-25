namespace mis_221_pa_5_aparker2024
{
    public class TrainerMenu
    {
        private Trainer[] trainers;
        private ListingFunctions[] listings;


        public TrainerMenu()
        {
            
        }
        public TrainerMenu(Trainer[] trainers)
        {
            this.trainers = trainers;
        }

        public void TrainersMenu(Trainer[] trainers)
        {       
            Console.Clear();
            TrainerUtility trainerFunctions = new TrainerUtility(trainers);
            TrainerReports trainerReports = new TrainerReports(trainers);
            System.Console.WriteLine("Which function would you like to perform????");
            System.Console.WriteLine("1. Add Trainer\n2. Edit Trainer info\n3. Delete Trainer\n4. Exit to Menu");
            int trainerMenu = int.Parse(Console.ReadLine());
            if (trainerMenu == 1)
            {
                Console.Clear();
                trainerFunctions.GetTrainersFromFile();
                trainerReports.PrintAlltrainers();
                trainerFunctions.AddTrainer();
            }
            else if (trainerMenu == 2)
            {
                Console.Clear();
                trainerFunctions.GetTrainersFromFile();
                trainerReports.PrintAlltrainers();
                trainerFunctions.EditTrainer();
            }
            else if (trainerMenu == 3)
            {
                trainerFunctions.GetTrainersFromFile();
                trainerReports.PrintAlltrainers();
                trainerFunctions.DeleteTrainer();
            }
            else if (trainerMenu == 4)
            {
                Console.Clear();
                Menu menuOption = new Menu();
                menuOption.MenuToString();
                menuOption.SetMenuOption(int.Parse(Console.ReadLine()));
                menuOption.RouteEm(trainers, listings);
            }
            else
            {
                System.Console.WriteLine("Invalid!");
                trainerFunctions.PauseIt();
                TrainersMenu(trainers);
            }
        }
    }
}