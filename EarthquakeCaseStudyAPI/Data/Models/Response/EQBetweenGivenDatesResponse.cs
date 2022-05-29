namespace EarthquakeCaseStudyAPI.Data.Models.Response
{
    public class EQBetweenGivenDatesResponse
    {
        public responseStatus status { get; set; }
        public int EQCount { get; set; }

        public enum responseStatus
        {
            error,
            success
        }
    }    
}
