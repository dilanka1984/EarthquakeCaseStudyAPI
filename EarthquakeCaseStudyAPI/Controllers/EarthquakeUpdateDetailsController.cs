using EarthquakeCaseStudyAPI.Data.Models;
using EarthquakeCaseStudyAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EarthquakeCaseStudyAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EarthquakeUpdateDetailsController : Controller
    {
        [HttpPut(Name = "UpdateEQDetails")]
        public string Put([FromBody] EQDetailsUpdate EQDetails)
        {
            var response = "Error";

            if (new EarthQuakesDetails().UpdateEQDetails(EQDetails))
                response = "Updated";

            return response;
        }
    }
}
