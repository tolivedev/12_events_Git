using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace task03
{
    public class Model
    {

        public string TimefromField { get; set; }
        public int Sec { get; set; }
        public Model(string dateTime)
        {
            TimefromField = dateTime;
            ParseToTime();

        }

        public void ParseToTime()
        {
            var d1 = DateTime.Parse(TimefromField);
            Sec++; //Инкрементируем поле s
            d1 =  new DateTime(0001, 01, 01, (Sec / 3600), (Sec / 60), Sec%60);
            TimefromField = d1.ToString("hh:mm:ss");
        }
        //IFormatProvider




    }
}