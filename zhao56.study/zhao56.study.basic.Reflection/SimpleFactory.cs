using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using zhao56.study.basic.Reflection.Interface;

namespace zhao56.study.basic.Reflection
{
    public class SimpleFactory
    {
        //读取app.config
        //private static string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelperConfig"];
        //读取appsetting.json
        private static string IDBHelperConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build().GetSection("AppSettings")["IDBHelperConfig"];
        private static string DllName = IDBHelperConfig.Split(',')[1];
        private static string TypeName = IDBHelperConfig.Split(',')[0];
        public static IDBHelper CreateInstance()
        {
            Assembly assembly = Assembly.Load(DllName);
            Type type = assembly.GetType(TypeName);
            object odbHelper = Activator.CreateInstance(type);
            IDBHelper iDBHelper = odbHelper as IDBHelper;
            return iDBHelper;
        }
    }
}
