using EarthquakeCaseStudyAPI.Data.Models;
using EarthquakeCaseStudyAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EarthquakeCaseStudyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EearthQuakesMoreThan4MagController : Controller
    {
        [HttpGet(Name = "GetEQMoreThan4Mag")]
        public List<LocationDetails> Get()
        {
            var locations = new List<LocationDetails>();
             locations = new EarthQuakesDetails().GetEQMoreThan4Mag();
            return locations;
        }
    }
}
