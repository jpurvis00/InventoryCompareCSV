
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace InventoryCompareCSV
{
    public static class DataAccess
    {
        private static readonly CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
        };

        public static IEnumerable<T> ReadCsvRecords<T>(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
