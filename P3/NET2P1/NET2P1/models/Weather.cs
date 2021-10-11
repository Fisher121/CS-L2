using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET2P1
{
    class Weather
    {

        public List<Weather> weatherList = new List<Weather>();
        public List<double> maxTemperature = new List<double>();
        public List<double> minTemperature = new List<double>();

        public int Dy { get; set; }
        public int MxT { get; set; }
        public int MnT { get; set; }
        public int AvT { get; set; }
        public int HdDay { get; set; }
        public double AvDP { get; set; }
        public int HrP { get; set; }
        public double TPcpn { get; set; }
        public double WxType { get; set; }
        public int PDir { get; set; }
        public double AvSp { get; set; }
        public int Dir { get; set; }
        public int MxS { get; set; }
        public double SkyC { get; set; }
        public int MxR { get; set; }
        public int MnR { get; set; }
        public double AvSLP { get; set; }

        public List<Weather> getDataToProperties(parser Parser, data Data)
        {
            
            for (int z = 1; z < Parser.getRowCount(); z++)
            {
               
                Weather weather = new Weather();
                weather.Dy = (int)Data.matrix[z, 0];
                weather.MxT = (int)Data.matrix[z, 1];
                weather.MnT = (int)Data.matrix[z, 2];
                weather.AvT = (int)Data.matrix[z, 3];
                weather.HdDay = (int)Data.matrix[z, 4];
                weather.AvDP = Data.matrix[z, 5];
                weather.HrP = (int)Data.matrix[z, 6];
                weather.TPcpn = Data.matrix[z, 7];
                weather.WxType = Data.matrix[z, 8];
                weather.PDir = (int)Data.matrix[z, 9];
                weather.AvSp = Data.matrix[z, 10];
                weather.Dir = (int)Data.matrix[z, 11];
                weather.MxS = (int)Data.matrix[z, 12];
                weather.SkyC = Data.matrix[z, 13];
                weather.MxR = (int)Data.matrix[z, 14];
                weather.MnR = (int)Data.matrix[z, 15];
                weather.AvSLP = Data.matrix[z, 16];
                weatherList.Add(weather);
            }
            return weatherList;
        }

        public List<double> getMaxTemperature(parser Parser, data Data)
        {
            for(int i = 1; i < Parser.getRowCount(); i++)
            {
               
                maxTemperature.Add(Data.matrix[i, 1]);
            }

            return maxTemperature;
;
        }
        public List<double> getMinimumTemperature(parser Parser, data Data)
        {
            for (int i = 1; i < Parser.getRowCount(); i++)
            {
                minTemperature.Add(Data.matrix[i, 2]);
            }

            return minTemperature;
        }

    }

    
}
