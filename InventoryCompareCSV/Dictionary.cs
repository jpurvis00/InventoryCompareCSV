using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCompareCSV
{
    public class Dictionary
    {
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
