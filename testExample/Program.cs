using System;
using System.Collections.Generic;

namespace testExample
{
    class ClassCounter  //Это класс - в котором производится счет.
    {
        public delegate void MethodContainer();

        //Событие OnCount c типом делегата MethodContainer.
        public event MethodContainer onCount;

        public void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 71)
                {
                    onCount();
                }
            }
        }
    }

    class Handler_I //Это класс, реагирующий на событие (счет равен 71) записью строки в консоли.
    {
        public void Message(object sender, EventArgs e)
        {
            //Не забудьте using System 
            //для вывода в консольном приложении
            Console.WriteLine("Пора действовать, ведь уже 71!");
        }
    }

    class Handler_II
    {
        public void Message()
        {
            Console.WriteLine("Точно, уже 71!");
        }
    }


    class User
    {
        public int UserSumm { get { return 1; } }

    }

    public class MainViewVM
    {
        public MainViewVM()
        {
            _user = new User();
        }
        public int thisUserSumm => _user.UserSumm;
        //...
        private User _user;
    }



    class Program
    {
        static void Main(string[] args)
        {
            /* ClassCounter Counter = new ClassCounter();
             Handler_I Handler1 = new Handler_I();
             Handler_II Handler2 = new Handler_II();


             //Подписались на событие
            // Counter.onCount += Handler1.Message;
             Counter.onCount += Handler2.Message;

             //Запустили счетчик, а внутри него будет событие по условию.
             Counter.Count();
             */

            var mw = new MainViewVM();
            Console.WriteLine("{0}", mw.thisUserSumm);



            //Type ht1 = (new ShadowFiend().GetType());
            //Radiant newRadiant = new Radiant(new ShadowFiend(), new Pudge(), new Luna());

            //(newRadiant.H1).

            Console.ReadKey();
        }
    }

}
