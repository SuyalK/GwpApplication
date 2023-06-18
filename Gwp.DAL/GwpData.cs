using CsvHelper;
using Gwp.Model;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;

namespace Gwp.DAL
{
    public class GwpData : IGwpData
    {
        string fileName = "gwpByCountry (3).csv";

        public List<CountryGwp> GetGwpByCountry(string country)
        {
            var countryGwpList = new List<CountryGwp>();

            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                countryGwpList = csv.GetRecords<CountryGwp>().ToList();
            }

            return countryGwpList.Where(x => x.country == country).ToList();
        }
    }
}