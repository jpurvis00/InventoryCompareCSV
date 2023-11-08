
namespace InventoryCompareCSV
{
    public class Dictionary
    {
        /* Made the following method as generic.  The Func lets me specify what propery I want to be the key/value.
         * ex call: CreateDictionary(magentoRecords, MagentoInventoryModel => MagentoInventoryModel.Sku, MagentoInventoryModel => MagentoInventoryModel.Qty);
         */
        public static Dictionary<string, double> CreateDictionary<T>(IEnumerable<T> records, Func<T, string> keySelector, Func<T, double> valueSelector)
        {
            var dictionary = new Dictionary<string, double>();

            foreach (var record in records)
            {
                try
                {
                    dictionary.Add(keySelector(record), valueSelector(record));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"An element with key {keySelector(record)} already exists.");
                }
            }

            return dictionary;
        }
    }
}
