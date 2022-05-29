using EarthquakeCaseStudyAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using static EarthquakeCaseStudyAPI.Repository.EarthQuakesDetails;

namespace EarthquakeCaseStudyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EarthquakeInGeofenceController : Controller
    {
        [HttpGet(Name = "GetEQInGeofence")]
        public List<Location> Get(DateTime fromDate, DateTime toDate, int radius, double latitude, double longitude)
        {
            var EQInRadius = new List<Location>();
            Location inPutlocation = new Location() { Latitude = latitude, Longitude = longitude };
            var listOfEQs = new EarthQuakesDetails().GetEQBetweenDates(fromDate, toDate);
            if (listOfEQs != null && listOfEQs.Count > 0)
                EQInRadius = new EarthQuakesDetails().GetListOfEQLocationsInRadius(radius, inPutlocation, listOfEQs);

            return EQInRadius;
        }
    }
}
