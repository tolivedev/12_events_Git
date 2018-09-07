using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace task04_calc
{
    class Model
    {
        private int operationNumber = 0;

        public double Accumulator { get; set; } = 0;
        public int OperationNumber { get; set; } = 0;
        public bool IsFirstDigit { get; set; } = true;

        public bool IsNextOperation { get; set; } = false;

        
        public object Content { get; set; } = null;

        public object ParseOfbuttons(object sender, EventArgs e)
        {
            var butn = (sender as Button);

            // ноль
            if (Convert.ToInt32(butn.Tag) == 0)
            {
                if (IsFirstDigit)
                {
                    Content = butn.Content;
                    IsFirstDigit = false;
                }
                if (Convert.ToString(Content) != "0") Content = butn.Content;
                return Content;
            }

            // С
            if (Convert.ToInt32(butn.Tag) == -1)
            {
                Accumulator = 0;
                OperationNumber = 0;
                Content = 0;
                //дефолтные значения и флаг первой цифры, для замены нуля.
                IsFirstDigit = true;
                return Content;
            }

            //1..9
            if (Convert.ToInt32(butn.Tag) > 0)
            {
                if (IsFirstDigit)  // первое число в ряду?
                {
                    Content = butn.Content;
                    IsFirstDigit = false; //больше не первое число в ряду. его так же можно считать уже вторым(следующим)
                }
                else { Content += (string)butn.Content; }

                return Content;
            }

            //BckSpc
            if (Convert.ToInt32(butn.Tag) == -7)
            {
                string tmpStr = null;
                string t1 = null;
                if (Convert.ToString(Content) != "0" && !string.IsNullOrEmpty(Convert.ToString(Content)))
                {
                    if (Content is string)
                    {
                        tmpStr = (string)Content;
                    }
                    for (int i = 0; i < tmpStr.Length - 1; i++)
                    {
                        t1 += tmpStr[i];
                        if (string.IsNullOrEmpty(t1))
                        {

                        }
                    }
                    if (!string.IsNullOrEmpty(tmpStr))
                    {
                        Content = Convert.ToString(t1);
                        //Rbox1.AppendText("\n" + Content);
                    }
                }
            }

            // + - * / =
            if (Convert.ToInt32(butn.Tag) < -1)
            {

                double currentContentFromLabel = Convert.ToDouble(Content);

                if (IsFirstDigit == false) // первое ли число в ряду?
                {
                    IsNextOperation = false;
                    IsFirstDigit = true;
                }
                else { IsNextOperation = true; }

                if (Accumulator != 0 && IsNextOperation == false)
                {
                    switch (OperationNumber)
                    {
                        case -2:
                            {
                                Accumulator = currentContentFromLabel;
                                break;
                            }
                        case -3:
                            {
                                Accumulator -= currentContentFromLabel;
                                break;
                            }
                        case -4:
                            {
                                Accumulator *= currentContentFromLabel;
                                break;
                            }
                        case -5:
                            {
                                Accumulator /= currentContentFromLabel;
                                break;
                            }
                        case -6:
                            {
                                Accumulator += currentContentFromLabel;
                                break;
                            }
                    }
                    Content = Accumulator; //выводим результат в лейбл
                }
                else
                {
                    Accumulator = currentContentFromLabel; //запоминаем первое число из поля
                }

                OperationNumber = Convert.ToInt32(butn.Tag); //запоминаем знак операции, ждём второе число/новый ввод клавиши
                IsFirstDigit = true; //флаг о том, что след введённое число будет новым
            }

            return Content;
        }
    }
}
