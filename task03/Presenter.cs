using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task03
{
    public class Presenter
    {
        private readonly MainWindow view;
        private readonly Model model;

        public Presenter(MainWindow view)
        {
            model = new Model();
            this.view = view;

            //подписка методов-обработчиков на событие
            // события возникают на вьюхе, следовательно прикрепляем к событию метод-обработчик:
            view.Start += View_Start;
            view.Reset += View_Reset;
            view.timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            view.Lb1.Content = model.TimefromField;
            model.ParseToTime();
            
        }

        private void View_Reset(object sender, EventArgs e)
        {
            
            model.Sec = string.IsNullOrEmpty(view.TB1.Text)?-1:Convert.ToInt32(view.TB1.Text)-1;
            model.ParseToTime();


        }

        private void View_Start(object sender, EventArgs e)
        {
            view.timer1.Enabled = !view.timer1.Enabled;
            //model.ParseToTime();
        }
    }
}