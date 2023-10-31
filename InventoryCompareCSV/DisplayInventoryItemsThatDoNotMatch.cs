
namespace InventoryCompareCSV
{
    public class DisplayInventoryItemsThatDoNotMatch
    {
        public static void DisplayOutput(List<string> inventoryDoesNotMatch)
        {
            Console.WriteLine("\nThe following inventory does not match.");

            foreach (var record in inventoryDoesNotMatch)
            {
                Console.WriteLine(record);
            }
        }
    }
}
