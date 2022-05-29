using EarthquakeCaseStudyAPI.Data.Models;
using EarthquakeCaseStudyAPI.Data.Models.Response;
using static EarthquakeCaseStudyAPI.Repository.EarthQuakesDetails;

namespace EarthquakeCaseStudyAPI.Repository
{
    public interface IEarthQuakesDetails
    {
        List<EarthQuakeData> GetEQBetweenDates(DateTime fromDate, DateTime toDate);
        List<Location> GetListOfEQLocationsInRadius(int radius, Location inPutlocation, List<EarthQuakeData> listOfEQs);
        List<EarthQuakeData> GetEQInRadius(int radius, Location inPutlocation, List<EarthQuakeData> listOfEQs);
        double CalculateDistance(Location point1, Location point2);
        List<LocationDetails> GetEQMoreThan4Mag();
        bool UpdateEQDetails(EQDetailsUpdate EQDeatils);
    }
}
