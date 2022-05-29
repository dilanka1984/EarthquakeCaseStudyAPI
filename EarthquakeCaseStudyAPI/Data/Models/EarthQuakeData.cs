namespace EarthquakeCaseStudyAPI.Data.Models
{
    public class EarthQuakeData
    {
        public string time { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string depth { get; set; }
        public string mag { get; set; }
        public string magType { get; set; }
        public string nst{ get; set; }
        public string gap { get; set; }
        public string dmin { get; set; }
        public string rms { get; set; }
        public string net { get; set; }
        public string id { get; set; }
        public string updated { get; set; }
        public string place { get; set; }
        public string type { get; set; }
        public string horizontalError { get; set; }
        public string depthError { get; set; }
        public string magError { get; set; }
        public string magNst { get; set; }
        public string status { get; set; }
        public string locationSource { get; set; }
        public string magSource { get; set; }
    }
}
