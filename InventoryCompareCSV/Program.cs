
using InventoryCompareCSV.Models;
using InventoryCompareCSV;

DirectoryInfo dirInfo = new DirectoryInfo(@"D:\MyProjects\InventoryCompareCSVApp");
var fileNameOmegaCube = dirInfo.GetFiles("Magento Stock default*").OrderByDescending(f => f.CreationTime).First().ToString();
var fileNameMagento = dirInfo.GetFiles("export_catalog_product*").OrderByDescending(f => f.CreationTime).First().ToString();

Console.WriteLine(fileNameOmegaCube);
Console.WriteLine(fileNameMagento);

var magentoRecords = DataAccess.ReadCsvRecords<MagentoInventoryModel>(fileNameMagento);
var omegaCubeRecords = DataAccess.ReadCsvRecords<OmegaCubeInventoryModel>(fileNameOmegaCube);

var magentoInventory = Dictionary.CreateDictionary(magentoRecords, MagentoInventoryModel => MagentoInventoryModel.Sku, MagentoInventoryModel => MagentoInventoryModel.Qty);

var inventoryDoesNotMatch = CompareMagentoToOCInventory.CompareMagentoToOmegaCubeInventory(magentoInventory, omegaCubeRecords);

DisplayInventoryItemsThatDoNotMatch.DisplayOutput(inventoryDoesNotMatch);
