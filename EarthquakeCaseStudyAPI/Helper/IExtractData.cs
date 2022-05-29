using EarthquakeCaseStudyAPI.Data.Models;

namespace EarthquakeCaseStudyAPI.Helper
{
    public interface IExtractData
    {
        public List<EarthQuakeData> GetFilecontents();
    }
}
