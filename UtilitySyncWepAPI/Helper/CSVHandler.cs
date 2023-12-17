using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace UtilitySyncWebAPI.Helper
{
    public class CSVHandler<T> where T:class
    { 
        public static List<T> ImportDataFromCSV(IFormFile file)
        {
            using (var streamReader = new StreamReader(file.OpenReadStream()))
            {
                // Use CsvHelper to read CSV content
                var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture); 
                 
                // Read the records from the CSV file
                var csvRecords = csvReader.GetRecords<T>().ToList();

                return csvRecords;
            }
        }
    }
}
