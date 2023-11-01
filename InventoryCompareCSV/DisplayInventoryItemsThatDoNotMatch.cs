
namespace InventoryCompareCSV
{
    public class DisplayInventoryItemsThatDoNotMatch
    {
        public static void DisplayOutput(List<string> inventoryDoesNotMatch)
        {
            if(inventoryDoesNotMatch.Count > 0)
            {
                Console.WriteLine("\nThe following inventory does not match.");

                foreach (var record in inventoryDoesNotMatch)
                {
                    Console.WriteLine(record);
                }
            }
            else
            {
                Console.WriteLine("All inventory quantities match.");
            }
        }
    }
}
