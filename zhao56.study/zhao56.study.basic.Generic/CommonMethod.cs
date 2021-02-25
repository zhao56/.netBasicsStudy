using System;
using System.Collections.Generic;
using System.Text;

namespace zhao56.study.basic.Generic
{
    public class CommonMethod
    {
        /// <summary>
        /// 打印个int值
        /// 
        /// 声明方法时，指定了参数类型，确定了只能传递某个类型
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0},type={1},parameter={2}",
                typeof(CommonMethod).Name, iParameter.GetType().Name, iParameter);
        }
        /// <summary>
        /// 打印个string值
        /// </summary>
        /// <param name="sParameter"></param>
        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0},type={1},parameter={2}",
                typeof(CommonMethod).Name, sParameter.GetType().Name, sParameter);

            //typeof(string)
            //typeof(Type)
        }
        /// <summary>
        /// 打印个DateTime值
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is {0},type={1},parameter={2}",
                typeof(CommonMethod).Name, dtParameter.GetType().Name, dtParameter);
        }

        /// <summary>
        /// 打印个object值
        /// 1 任何父类出现的地方，都可以用子类来代替
        /// 2 object是一切类型的父类
        /// 2个问题：
        /// 1 装箱拆箱
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},type={1},parameter={2}",
                typeof(CommonMethod), oParameter.GetType().Name, oParameter);
        }
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},type={1},parameter={2}",
               typeof(CommonMethod), tParameter.GetType().Name, tParameter);
        }
    }
}
