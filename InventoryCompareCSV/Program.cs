
using InventoryCompareCSV.Models;
using InventoryCompareCSV;
using Microsoft.Extensions.Configuration;


var filePath = Configuration.InitializeConfiguration();

DirectoryInfo dirInfo = new DirectoryInfo(filePath);

/* These particular file name append numbers on the end if one already exists in the dir.
 * If multiple files exist in the same dir, get the file name with the latest date/time.
 */
var fileNameOmegaCube = dirInfo.GetFiles("Magento Stock default*").OrderByDescending(f => f.CreationTime).First().ToString();
var fileNameMagento = dirInfo.GetFiles("export_catalog_product*").OrderByDescending(f => f.CreationTime).First().ToString();

Console.WriteLine(fileNameOmegaCube);
Console.WriteLine(fileNameMagento);

var magentoRecords = DataAccess.ReadCsvRecords<MagentoInventoryModel>(fileNameMagento);
var omegaCubeRecords = DataAccess.ReadCsvRecords<OmegaCubeInventoryModel>(fileNameOmegaCube);

var magentoInventory = Dictionary.CreateDictionary(magentoRecords, MagentoInventoryModel => MagentoInventoryModel.Sku, MagentoInventoryModel => MagentoInventoryModel.Qty);

var inventoryDoesNotMatch = CompareMagentoToOCInventory.CompareMagentoToOmegaCubeInventory(magentoInventory, omegaCubeRecords);

DisplayInventoryItemsThatDoNotMatch.DisplayOutput(inventoryDoesNotMatch);

Console.ReadLine();
