using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherBroadcast
{
    class WeatherResponse
    {
        public List<MainForm> list { get; set; }
        public List<Weather> weather { get; set; }
    }
}
