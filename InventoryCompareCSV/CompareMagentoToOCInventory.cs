using InventoryCompareCSV.Models;

namespace InventoryCompareCSV
{
    public class CompareMagentoToOCInventory
    {
        public static List<string> CompareMagentoToOmegaCubeInventory(Dictionary<string, double> magentoInventory, IEnumerable<OmegaCubeInventoryModel> omegaCubeInventory) 
        {
            List<string> inventoryDoesNotMatch= new List<string>();

            foreach (var record in omegaCubeInventory)
            {
                if (magentoInventory.ContainsKey(record.Sku))
                {
                    bool inventoryQtyMatch = record.Quantity == magentoInventory[record.Sku] ? true : false;

                    if (inventoryQtyMatch == false)
                    {
                        inventoryDoesNotMatch.Add($"    sku: {record.Sku}   omega quantity: {record.Quantity}   magento quantity: {magentoInventory[record.Sku]}");
                    }
                }

            }

            return inventoryDoesNotMatch;
        }
    }
}
