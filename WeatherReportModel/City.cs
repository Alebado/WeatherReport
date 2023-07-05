using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportModel
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string Timezone { get; set; }
        public string Cod { get; set; }
        public List<WeatherReport> WeatherReports { get; set; }
    }
}
