using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;


namespace task03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    // Вьюха
    public partial class MainWindow : Window
    {
        // сами события на вьюхе
        public event EventHandler Start;

        public event EventHandler Reset;
        // поля
        public Timer timer1;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            new Presenter(this);
            //DateTime zero = new DateTime();
        }

        private void InitializeTimer()
        {
            // бесполезно добавлять в метод InitializeComponent(), автогенератор перезапишет файл и сотрет пользовательский код, поэтому выносим в свой метод инициализации.
            timer1 = new System.Windows.Forms.Timer() { Interval = 1000, Enabled = false };
            
        }

        // методы-инициаторы вызова событий - они же нажатия на кнопки
        private void START_Click(object sender, RoutedEventArgs e)
        {
            Start(sender, e);

        }


        private void RESET_Click(object sender, RoutedEventArgs e)
        {
            Reset(sender, e);

        }
    }
}
