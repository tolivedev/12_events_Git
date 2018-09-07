using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task04_calc
{

    //подписываем обработчики из модели на события из вьюхи
    class Presenter
    {
        //class MyEventArg : EventArgs
        //{
        //    object content;
        //}

        private readonly Model model;
        private readonly MainWindow view;

        public object Content
        {
            get; set;
        }

        public Presenter(MainWindow mainWindows)
        {
            this.view = mainWindows;
            this.model = new Model();

            view.ClicksOnButtonsEvent += ClicksOnButtons;
        }


        public MainWindow MainWindow
        {
            get => default;
            set { }
        }

        internal Model Model
        {
            get => default;
            set { }
        }

        private void ClicksOnButtons(object sender, EventArgs e) //метод сообщённый с обработчиком
        {
            view.Lbl1.Content = model.ParseOfbuttons(sender, e);
            //= model.Content;
        }
    }
}
