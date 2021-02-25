using System;
using System.Collections.Generic;
using System.Text;

namespace zhao56.study.basic.Reflection.Model
{
    public class People
    {
        public People()
        {
            Console.WriteLine("{0}被创建", this.GetType().FullName);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description;
    }
}
