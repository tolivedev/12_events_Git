using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace task03
{
    public class Model
    {
        public int Sec { get; set; }
        public string TimefromField { get; set; }
        //private DateTime d2;
        //private int s;

        public Model()
        {
            //s = 0;
            TimefromField = "00:00:00";
            //TimefromField = dateTime;
            //ParseToTime();
        }

        public void ParseToTime()
        {
            Sec++;
            var d1 = new DateTime(0001, 01, 01, (Sec / 3600)%24, (Sec / 60) % 60, Sec % 60);
            TimefromField = d1.ToString("HH:mm:ss");
            
         
        }
    }
}