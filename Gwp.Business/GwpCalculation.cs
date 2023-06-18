using Gwp.DAL;
using System.Security.Cryptography.X509Certificates;

namespace Gwp.Business
{
    public class GwpCalculation : IGwpCalculation
    {
        private readonly IGwpData _gwpData;

        public GwpCalculation(IGwpData gwpData)
        {
             _gwpData= gwpData;
        }

        public Dictionary<string, decimal> CalculateAverageGwp(string country, string[] lineOfBusinesses)
        {
            var lobAverageGwp = new Dictionary<string, decimal>();
            var countryGwpList = _gwpData.GetGwpByCountry(country);

            foreach (var lineOfBusiness in lineOfBusinesses)
            {
                var averageGwp = 0.0M;

                var countryGwp = countryGwpList.FirstOrDefault(x => x.lineOfBusiness == lineOfBusiness);

                averageGwp = (Convert.ToDecimal(string.IsNullOrEmpty(countryGwp.Y2008)? 0 : countryGwp.Y2008) +
                    Convert.ToDecimal(string.IsNullOrEmpty(countryGwp.Y2009) ? 0 : countryGwp.Y2009) +
                    Convert.ToDecimal(string.IsNullOrEmpty(countryGwp.Y2010) ? 0 : countryGwp.Y2010) +
                    Convert.ToDecimal(string.IsNullOrEmpty(countryGwp.Y2011) ? 0 : countryGwp.Y2011) +
                    Convert.ToDecimal(string.IsNullOrEmpty(countryGwp.Y2012) ? 0 : countryGwp.Y2012) +
                    Convert.ToDecimal(string.IsNullOrEmpty(countryGwp.Y2013) ? 0 : countryGwp.Y2013) +
                    Convert.ToDecimal(string.IsNullOrEmpty(countryGwp.Y2014) ? 0 : countryGwp.Y2014) +
                    Convert.ToDecimal((string.IsNullOrEmpty(countryGwp.Y2015)) ? 0 : countryGwp.Y2015)) / 8; 

                lobAverageGwp.Add(lineOfBusiness, averageGwp);
            }

            return lobAverageGwp;
        }
    }
}