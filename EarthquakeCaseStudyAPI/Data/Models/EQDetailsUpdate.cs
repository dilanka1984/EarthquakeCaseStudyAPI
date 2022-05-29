namespace EarthquakeCaseStudyAPI.Data.Models
{
    public class EQDetailsUpdate
    {
        public string id { get; set; }
        public string horizontalError { get; set; }
        public string depthError { get; set; }
        public string magError { get; set; }
        public string magNst { get; set; }  
    }
}
