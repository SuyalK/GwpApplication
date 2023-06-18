using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwp.Model
{
    public class CalculateAverageGwpRequest
    {
        public string Country { get; set; }

        public string[] LineOfBusinesses { get; set; }
    }
}
