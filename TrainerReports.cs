namespace mis_221_pa_5_aparker2024
{
    public class TrainerReports
    {
        Trainer[] trainers;

        public TrainerReports(Trainer[] trainers)
        {
            this.trainers = trainers;
        }

        public void PrintAlltrainers()
        {
            for(int i = 0;i < Trainer.GetCount(); i++)
            {
                System.Console.WriteLine(trainers[i].TrainerToString());
            }
        }
    }
}