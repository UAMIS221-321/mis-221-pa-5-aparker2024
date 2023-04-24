namespace mis_221_pa_5_aparker2024
{
    public class ListingReports
    {
        ListingFunctions[] listings;

        public ListingReports(ListingFunctions[] listings)
        {
            
            this.listings = listings;
        }

        public void PrintAllListings()
        {
           
             for (int i = 0; i < ListingFunctions.GetCount(); i++)
             {
                 System.Console.WriteLine(listings[i].ListingToString());
             }
           
        }


       
    }
}