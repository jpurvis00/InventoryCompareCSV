# InventoryCompareCSV
Compares two different inventory CSV files to see if the inventory quantity matches.

At the moment we are manually updating our inventory from our ERP system to our website. This is done with a CSV file exported from our ERP system. I then export another CSV file from our website and compare the two in excel using vlookup. This is a manual process, so I've created this app to grab the two CSV files and compare them.  This is done by reading in one CSV file and converting those values to a Dictionary. I then read in the other file and store those in a list. The Dictionary is then searched and the quantities are compared.  Non matching quantities are stored in a list.
