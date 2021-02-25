using System;
using System.Collections.Generic;

namespace zhao56.study.basic.Generic
{
    /// <summary>
    /// 1 引入泛型:延迟声明
    /// 2 如何声明和使用泛型
    /// 3 泛型的好处和原理
    /// 4 泛型类、泛型方法、泛型接口、泛型委托
    /// 5 泛型约束
    /// 6 协变 逆变
    /// 7 泛型缓存
    /// 8装箱值类型变为引用类型，拆箱：引用类型变为值类型
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    //Console.WriteLine(typeof(List<>));
                    //Console.WriteLine(typeof(Dictionary<,>));
                    //int iValue = 123;
                    //string sValue = "456";
                    //DateTime dtValue = DateTime.Now;
                    //object oValue = "678";

                    //Console.WriteLine("***********************Common***********************");
                    //CommonMethod.ShowInt(iValue);
                    //CommonMethod.ShowString(sValue);
                    //CommonMethod.ShowDateTime(dtValue);

                    //Console.WriteLine("***********************Object***********************");
                    //CommonMethod.ShowObject(oValue);
                    //CommonMethod.ShowObject(iValue);
                    //CommonMethod.ShowObject(sValue);
                    //CommonMethod.ShowObject(dtValue);

                    ////Console.WriteLine("***********************Generic***********************");
                    //CommonMethod.Show<int>(iValue);//调用泛型，需要指定类型参数
                    //CommonMethod.Show(iValue);//如果可以从参数类型推断，可以省略类型参数---语法糖(编译器提供的功能)
                    //CommonMethod.Show<string>(sValue);
                    ////CommonMethod.Show<int>(sValue);//类型错了
                    //CommonMethod.Show<DateTime>(dtValue);
                    //CommonMethod.Show<object>(oValue);
                }
                //{
                //    Console.WriteLine("*******************Monitor********************");
                //Monitor.Show();
                //}
                //{
                //    Console.WriteLine("*******************GenericCache********************");
                //GenericCacheTest.Show();
                CovariantAndContravariant.Show();
                //}

                {
                    //哪里用泛型？ 泛型到底是干嘛的？
                    //泛型方法：为了一个方法满足不同的类型的需求
                    //泛型类：一个类，满足不同类型的需求  List Dictionary
                    //泛型接口：一个接口，满足不同类型的需求
                    //泛型委托：一个委托，满足不同类型的需求
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
