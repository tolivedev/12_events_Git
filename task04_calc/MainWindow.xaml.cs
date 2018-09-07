using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
//using System.Windows.Forms;

namespace task04_calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeButtons();
            new Presenter(this);
        }

        int[] btnTag = {7,4,1,0,
                        8,5,2,
                        9,6,3,-2,
                       -1,-3,-4,
                       -7,-6,-5};
        string[] btnContent = {"7","4","1","0",
                               "8","5","2",
                               "9","6","3","=",
                               "C","-","*",
                               "BckSpc","+","/"};

        private RoutedEventHandler _clicksOnButtonsEvent;

        public event RoutedEventHandler ClicksOnButtonsEvent //Реализация на память для примера
// обрати внимание, что при контролируемой подписке, для вызова события, необходимо вызывать непосредственно сам делегат _clicksOnButtonsEvent.Invoke()
// Но подписка обработчиков будет влюбом случае для события, а вот вызов идёт через делегата.
        {
            add
            {
                _clicksOnButtonsEvent += value;
            }
            remove
            {
                _clicksOnButtonsEvent -= value;
            }
        }


        private Button bt;


        private void InitializeButtons() //создание кнопок в контейнере компоновки.
        {
            var gColCount = gridbuttons.ColumnDefinitions.Count;
            var gRowCount = gridbuttons.RowDefinitions.Count;
            var btCount = 0;

            for (int i = 0; i < gColCount; i++)
            {
                if (i == 3)// пропускаем пустой четвертый столбец грида
                {
                    continue;
                }
                else
                    for (int j = 0; j < gRowCount; j++)
                    {
                        if (i == 1 && j == 3 || i == 4 && j == 3 || i == 5 && j == 3) // пропускаем четвертую кнопку второго, пятого и шестого столбцов грида.
                        {
                            continue;
                        }
                        bt = new Button();
                        bt.VerticalAlignment = VerticalAlignment.Stretch;
                        bt.HorizontalAlignment = HorizontalAlignment.Stretch;
                        bt.Margin = new Thickness(5, 5, 5, 5);
                        bt.Padding = new Thickness(10);
                        bt.MinWidth = 48;
                        bt.MinHeight = 48;
                        bt.Content = btnContent[btCount];
                        bt.FontSize = 15;
                        bt.Click += Button_Click;
                        bt.Tag = btnTag[btCount];

                        if (i != 3)
                        {
                            Grid.SetColumn(bt, i);
                            Grid.SetRow(bt, j);
                            if (btCount < btnTag.Length)
                            {
                                btCount++;
                            }
                        }
                        else
                        {
                            Grid.SetColumn(bt, j);
                            Grid.SetRow(bt, i + 1);
                        }

                        if (i == 0 && j == 3)
                        {
                            Grid.SetColumnSpan(bt, 2);

                        }
                        gridbuttons.Children.Add(bt);
                    }
            }

            var textRange = new TextRange(Rbox1.Document.ContentStart, Rbox1.Document.ContentEnd);
            IEnumerable<Button> collection = gridbuttons.Children.OfType<Button>();
            if (!(string.IsNullOrEmpty(textRange.Text)))
            {
                Rbox1.Document.Blocks.Clear();
                foreach (var item in collection)
                {
                    Rbox1.AppendText(item.Content.ToString());
                }
            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        private void Button_Click(object sender, RoutedEventArgs e) //обработчик кнопки с формы, в теле вызывает наш обработчик
        {

            _clicksOnButtonsEvent.Invoke(sender, e); // вызов сообщенных методов обработчиков



            #region
            //var butn = (sender as Button);
            //ноль
            //if (Convert.ToInt32(butn.Tag) == 0)
            //{
            //    if (iSfirstDigit)
            //    {
            //        Lbl1.Content = butn.Content;
            //        iSfirstDigit = false;
            //    }
            //    if (Convert.ToString(Lbl1.Content) != "0") Lbl1.Content = butn.Content;
            //    return;
            //}

            //// С
            //if (Convert.ToInt32(butn.Tag) == -1)
            //{
            //    accumulator = 0;
            //    operationNumber = 0;
            //    Lbl1.Content = 0;
            //    //дефолтные значения и флаг первой цифры, для замены нуля.
            //    iSfirstDigit = true;
            //    return;
            //}

            ////1..9
            //if (Convert.ToInt32(butn.Tag) > 0)
            //{
            //    if (iSfirstDigit)
            //    {
            //        Lbl1.Content = butn.Content;
            //        iSfirstDigit = false; //больше не первое число в ряду. его так же можно считать уже вторым(следующим)
            //    }
            //    else { Lbl1.Content += (string)butn.Content; }

            //    return;
            //}

            ////BckSpc
            //if (Convert.ToInt32(butn.Tag) == -7)
            //{
            //    string tmpStr = null;
            //    string t1 = null;
            //    if (Convert.ToString(Lbl1.Content) != "0" && !string.IsNullOrEmpty(Convert.ToString(Lbl1.Content)))
            //    {
            //        if (Lbl1.Content is string)
            //        {
            //            tmpStr = (string)Lbl1.Content;
            //        }
            //        for (int i = 0; i < tmpStr.Length - 1; i++)
            //        {
            //            t1 += tmpStr[i];
            //            if (string.IsNullOrEmpty(t1))
            //            {

            //            }
            //        }
            //        if (!string.IsNullOrEmpty(tmpStr))
            //        {
            //            Lbl1.Content = Convert.ToString(t1);
            //            Rbox1.AppendText("\n" + Lbl1.Content);
            //        }
            //    }
            //}

            //// + - * / =
            //if (Convert.ToInt32(butn.Tag) < -1)
            //{

            //    double currentContentFromLabel = Convert.ToDouble(Lbl1.Content);

            //    if (iSfirstDigit == false) //проверка следующего ввода на число
            //    {
            //        iSnextOperation = false;
            //        iSfirstDigit = true;
            //    }
            //    else { iSnextOperation = true; }

            //    if (accumulator != 0 && iSnextOperation == false)
            //    {
            //        switch (operationNumber)
            //        {
            //            case -2:
            //                {
            //                    accumulator = currentContentFromLabel;
            //                    break;
            //                }
            //            case -3:
            //                {

            //                    accumulator -= currentContentFromLabel;
            //                    break;
            //                }
            //            case -4:
            //                {

            //                    accumulator *= currentContentFromLabel;
            //                    break;
            //                }
            //            case -5:
            //                {

            //                    accumulator /= currentContentFromLabel;
            //                    break;
            //                }
            //            case -6:
            //                {

            //                    accumulator += currentContentFromLabel;
            //                    break;
            //                }
            //        }
            //        Lbl1.Content = accumulator; //выводим результат в лейбл
            //    }
            //    else
            //    {
            //        accumulator = currentContentFromLabel; //запоминаем первое число из поля

            //    }

            //    operationNumber = Convert.ToInt32(butn.Tag); //запоминаем знак операции, ждём второе число/новый ввод клавиши
            //    iSfirstDigit = true; //флаг на новое число


            //}
            #endregion
        }
    }


}

