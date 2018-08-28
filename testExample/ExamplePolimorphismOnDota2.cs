using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace testExample
{
    abstract class Heroes
    {
       public string skill1 = "skill1";
       public string skill2 = "skill2";
       public string skill3 = "skill3";
       public string skill4 = "skill4";

        static public Heroes Current { get; private set; }
        public Heroes()
        {
            Current = this;
        }
    }

    class Magnus:Heroes
    {

    }
    class StormSpirit:Heroes
    {
        

    }
    class Pudge:Heroes
    {

    }

    class Luna:Heroes
    {

    }
    class Sven:Heroes
    {

    }
    class Treant:Heroes
    {

    }
    class ShadowFiend : Heroes
    {
        private string skill5 = "skill5";
        private string skill6 = "skill6";
        public string Skill5
        {
            get { return skill5; }
            set { skill5 = value; }
        }
        public string Skill6
        {
            get { return skill6; }
            set { skill6 = value; }
        }
    }

    class Radiant:IEnumerable
    {
        Heroes h1;
        Heroes h2;
        Heroes h3;
        //object h4;
        //object h5;
        public Radiant(Heroes h1, Heroes h2, Heroes h3)
        {
            this.h1 = h1;
            this.h2 = h2;
            this.h3 = h3;
            //this.h4 = h4;
            //this.h5 = h5;
        }
        public Heroes H1
        {
            get { return h1; }
            set { h1 = value; }
        }
        //System.ComponentModel.INotifyPropertyChanged
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class Dire
    {
        public Dire(Heroes h1,Heroes h2, Heroes h3, Heroes  h4, Heroes h5)
        {

        }
    }
}
