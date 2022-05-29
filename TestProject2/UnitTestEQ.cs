using EarthquakeCaseStudyAPI.Controllers;
using EarthquakeCaseStudyAPI.Data.Models;
using EarthquakeCaseStudyAPI.Helper;
using EarthquakeCaseStudyAPI.Repository;
using static EarthquakeCaseStudyAPI.Repository.EarthQuakesDetails;

namespace EarthquakeCaseStudyAPI.Test
{
    [TestClass]
    public class UnitTestEQ
    {
        ExtractData extractData = new ExtractData();
        EarthQuakesDetails earthQuakesDetails = new EarthQuakesDetails();
        List<EarthQuakeData> listOfEarthQuakesBetweenDates = new List<EarthQuakeData>();

        [TestMethod]
        public void Test_ExtractData()
        {
            //Extract data from the file
            var extractedData = extractData.GetFilecontents();

        }

        [TestMethod]
        public void Test_EQBetweenDates()
        {
            //Get count of EQs between given two dates
            var fromDate = DateTime.Parse("2017-06-20T12:02:59.960Z");
            var toDate = DateTime.Parse("2018-06-20T12:02:59.960Z");
            var numOfEarthQuakesBetweenDates = earthQuakesDetails.GetEQBetweenDates(fromDate, toDate).Count();
        }

        [TestMethod]
        public void Test_EQInRadius()
        {
            //Get list of locations for given date range and within a given radius of a location
            var fromDate = DateTime.Parse("2017-06-20T12:02:59.960Z");
            var toDate = DateTime.Parse("2018-12-31T12:02:59.960Z");
            int radius = 800000; //in Meters
            var inPutlocation = new Location()
            {
                Latitude = double.Parse("-8.6011"),
                Longitude = double.Parse("115.2464")
            };
            List<Location> locations = new List<Location>();

            var listOfEQs = new EarthQuakesDetails().GetEQBetweenDates(fromDate, toDate);
            if (listOfEQs != null && listOfEQs.Count > 0)
               locations =   new EarthQuakesDetails().GetListOfEQLocationsInRadius(radius, inPutlocation, listOfEQs);
        }

        [TestMethod]
        public void Test_EQMoreThan4Mag()
        {
            //Get list of locations where EQs are more than 4 meg 
            List<LocationDetails> locations = new List<LocationDetails>();
            locations = earthQuakesDetails.GetEQMoreThan4Mag();
        }

        [TestMethod]
        public void Test_EQUpdate()
        {
            //update EQ details
            EQDetailsUpdate EQDeatils = new EQDetailsUpdate()
            {
                id = "us10008g3n",
                depthError = "11.3",
                horizontalError = "9.9",
                magError = "0.6",
                magNst = "6"
            };

            var status = earthQuakesDetails.UpdateEQDetails(EQDeatils);
         }

    }
}