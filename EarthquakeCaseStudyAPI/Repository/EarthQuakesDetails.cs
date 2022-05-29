using CsvHelper;
using CsvHelper.Configuration;
using EarthquakeCaseStudyAPI.Data.Models;
using EarthquakeCaseStudyAPI.Helper;
using System.Globalization;

namespace EarthquakeCaseStudyAPI.Repository
{
    public class EarthQuakesDetails:IEarthQuakesDetails
    {
        public List<EarthQuakeData> GetEQBetweenDates(DateTime fromDate, DateTime toDate)
        {
            var EQBetweenDates= new List<EarthQuakeData>();
            try
            {
                var extractData = new ExtractData().GetFilecontents();
                if (extractData != null)
                {
                    EQBetweenDates = extractData.Where(x => DateTime.Parse(x.time) >= fromDate).ToList().Where(y=> DateTime.Parse(y.time) < toDate).ToList();
                }
            }
            catch { }
            return EQBetweenDates;
        }

        public List<LocationDetails> GetEQMoreThan4Mag()
        {
            var EQMorethan4Mag = new List<LocationDetails>();

                var extractData = new ExtractData().GetFilecontents();
            if (extractData != null)
            {
                try {
                    foreach (var extract in extractData)
                    {
                        try
                        {
                            if (double.Parse(extract.mag) >= 4)
                            {
                                var locationDetails = new LocationDetails();
                                var splitCom = extract.place.Split(',');
                                if (splitCom.Length == 2)
                                {
                                    locationDetails.country = splitCom[1].Trim();

                                    var splitOf = splitCom[0].Replace("of","|").Split('|');
                                    if (splitOf.Length == 2)
                                    {
                                        locationDetails.sourceLocality = splitOf[1].Trim();

                                        var splitSpace = splitOf[0].Split(' ');
                                        if (splitOf.Length == 2)
                                        {
                                            locationDetails.distanceInKm = splitSpace[0].ToLower().Replace("km", "").Trim();
                                            locationDetails.orientation = splitSpace[1].Trim();

                                            EQMorethan4Mag.Add(locationDetails);
                                        }                                       
                                    }
                                }                               

                            }
                        }
                        catch { }
                    }
                }
                catch { }
            }

            return EQMorethan4Mag;
        }

        public List<Location> GetListOfEQLocationsInRadius(int radius, Location inPutlocation, List<EarthQuakeData> listOfEQs)
        {
            List<Location> locations = new List<Location>();
            try
            {
                var listOfLocations = GetEQInRadius(radius, inPutlocation, listOfEQs);
                if (listOfLocations != null && listOfLocations.Count > 0)
                    foreach (var loc in listOfLocations)
                    {
                        var location = new Location()
                        {
                            Latitude = double.Parse(loc.latitude),
                            Longitude = double.Parse(loc.longitude)
                        };

                        locations.Add(location);
                    }
            }
            catch { }
            return locations;
        }

        public List<EarthQuakeData> GetEQInRadius(int radius, Location inPutlocation, List<EarthQuakeData> listOfEQs)
        {
            var EQInRadius = new List<EarthQuakeData>();

            foreach (var eq in listOfEQs)
            {
                try
                {
                    var EQlocation = new Location() { Latitude = double.Parse(eq.latitude), Longitude = double.Parse(eq.longitude) };
                    var distance = CalculateDistance(inPutlocation, EQlocation);
                    if (distance < 0)
                        distance = -1 * distance;
                    if (distance <= radius)
                    {
                        EQInRadius.Add(eq);
                    }
                }
                catch { }
            }

            return EQInRadius;
        }

        public bool UpdateEQDetails(EQDetailsUpdate EQDeatils)
        {
            var updated = false;

            var extractData = new ExtractData().GetFilecontents();
            if (extractData != null)
            {
                try
                {
                    extractData.Where(x => x.id == EQDeatils.id).ToList().ForEach(y => y.horizontalError = EQDeatils.horizontalError);
                    extractData.Where(x => x.id == EQDeatils.id).ToList().ForEach(y => y.depthError = EQDeatils.depthError);
                    extractData.Where(x => x.id == EQDeatils.id).ToList().ForEach(y => y.magError = EQDeatils.magError);
                    extractData.Where(x => x.id == EQDeatils.id).ToList().ForEach(y => y.magNst = EQDeatils.magNst);
                    extractData.Where(x => x.id == EQDeatils.id).ToList().ForEach(y => y.status = "Updated");
                            
                    using (var writer = new StreamWriter(filePath))
                    using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        csv.WriteRecords(extractData);
                        writer.Flush();
                    }

                    updated = true;
                }
                catch { }
            }

            return updated;
        }

        public double CalculateDistance(Location point1, Location point2)
        {
            var d1 = point1.Latitude * (Math.PI / 180.0);
            var num1 = point1.Longitude * (Math.PI / 180.0);
            var d2 = point2.Latitude * (Math.PI / 180.0);
            var num2 = point2.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }

        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        const string filePath = "C:\\Temp\\EarthquakeDataSet.csv";
    }
}
