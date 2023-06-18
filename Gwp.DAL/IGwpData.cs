using Gwp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwp.DAL
{
    public interface IGwpData
    {
        public List<CountryGwp> GetGwpByCountry(string country);
    }
}
