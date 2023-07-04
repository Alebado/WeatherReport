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
        public int WebId { get; set; }
        public int Timezone { get; set; }
        public string Cod { get; set; } //internal openapi param
        //public int Population { get; set; }
        //public double Area { get; set; }
        //public Coordinates Coordinates { get; set; }
        public List<WeatherReport> WeatherReports { get; set; }
    }
}
