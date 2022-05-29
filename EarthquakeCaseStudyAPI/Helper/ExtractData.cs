using CsvHelper;
using CsvHelper.Configuration;
using EarthquakeCaseStudyAPI.Data.Models;
using System.Globalization;

namespace EarthquakeCaseStudyAPI.Helper
{
    public class ExtractData: IExtractData
    {
        public List<EarthQuakeData> GetFilecontents()
        {
            var records = new List<EarthQuakeData>();
            try
            {
                CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    HeaderValidated = null,
                    MissingFieldFound = null,
                    BadDataFound = null,
                    Delimiter = ","
                };

                using (var reader = new StreamReader(@filePath))
                using (var csv = new CsvReader(reader, csvConfig))
                {
                    records = csv.GetRecords<EarthQuakeData>().ToList();
                    return records;
                }
            }
            catch
            {
                return records;
            }
        }

        const string  filePath = "C:\\Temp\\EarthquakeDataSet.csv";
    }
}
