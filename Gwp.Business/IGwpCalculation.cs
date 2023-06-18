using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwp.Business
{
    public interface IGwpCalculation
    {
        public Dictionary<string, decimal> CalculateAverageGwp(string country, string[] lineOfBusinesses);
    }
}
