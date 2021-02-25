using System;
using System.Collections.Generic;
using System.Text;
using zhao56.study.basic.Reflection.Interface;

namespace zhao56.study.basic.Reflection.MySql
{
    public class MySqlHelper : IDBHelper
    {
        public MySqlHelper()
        {
            Console.WriteLine("{0}被构造", this.GetType().Name);
        }


        public void Query()
        {
            Console.WriteLine("{0}.Query", this.GetType().Name);
        }
    }
}
