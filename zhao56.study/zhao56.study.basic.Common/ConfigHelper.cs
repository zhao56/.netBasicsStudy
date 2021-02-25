using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace zhao56.study.basic.Common
{
    public class ConfigHelper
    {
        //读取app.config
        //private static string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelperConfig"];
        //读取appsetting.json
        private static string IDBHelperConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build().GetSection("AppSettings")["IDBHelperConfig"];
        private static string DllName = IDBHelperConfig.Split(',')[1];
        private static string TypeName = IDBHelperConfig.Split(',')[0];
        private static string ConnectionString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build().GetSection("connectionStrings")["connectionString"];
        public static IdbHelper GetIDBHelperConfig()
        {
            Assembly assembly = Assembly.Load(DllName);
            Type type = assembly.GetType(TypeName);
            object odbHelper = Activator.CreateInstance(type);
            IdbHelper iDBHelper = odbHelper as IdbHelper;
            return iDBHelper;
        }
        public static string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}
