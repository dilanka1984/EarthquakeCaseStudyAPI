using EarthquakeCaseStudyAPI.Data.Models.Response;
using EarthquakeCaseStudyAPI.Helper;
using EarthquakeCaseStudyAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using static EarthquakeCaseStudyAPI.Data.Models.Response.EQBetweenGivenDatesResponse;

namespace EarthquakeCaseStudyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EearthQuakesBetweenDatesController : Controller
    {
        [HttpGet(Name = "GetEQBetweenGivenDates")]
        public EQBetweenGivenDatesResponse Get(DateTime fromDate, DateTime toDate)
        {
            var response = new EQBetweenGivenDatesResponse()
            {
                status = responseStatus.error
            };

            var listOfEQs = new EarthQuakesDetails().GetEQBetweenDates(fromDate, toDate);
            if (listOfEQs != null && listOfEQs.Count > 0)
                response.EQCount = listOfEQs.Count;

            return response;
        }
    }
}
