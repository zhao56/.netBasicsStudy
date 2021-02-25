using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using zhao56.study.basic.Reflection.Interface;

namespace zhao56.study.basic.Reflection
{
    public class OracleHelper : IDBHelper
    {
       
        public void Query()
        {
            Console.WriteLine("{0}.Query", this.GetType().Name);
        }
        #region Identity
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public OracleHelper()
        {
            Console.WriteLine("这里是{0}无参数构造函数", this.GetType());
        }

        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="name"></param>
        public OracleHelper(string name)
        {
            Console.WriteLine("这里是{0} 有参数构造函数", this.GetType());
        }

        public OracleHelper(int id)
        {
            Console.WriteLine("这里是{0} 有参数构造函数", this.GetType());
        }
        #endregion

        #region Method
        /// <summary>
        /// 无参方法
        /// </summary>
        public void Show1()
        {
            Console.WriteLine("这里是{0}的Show1", this.GetType());
        }
        /// <summary>
        /// 有参数方法
        /// </summary>
        /// <param name="id"></param>
        public void Show2(int id)
        {

            Console.WriteLine("这里是{0}的Show2", this.GetType());
        }
        /// <summary>
        /// 重载方法之一
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Show3(int id, string name)
        {
            Console.WriteLine("这里是{0}的Show3", this.GetType());
        }
        /// <summary>
        /// 重载方法之二
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public void Show3(string name, int id)
        {
            Console.WriteLine("这里是{0}的Show3_2", this.GetType());
        }
        /// <summary>
        /// 重载方法之三
        /// </summary>
        /// <param name="id"></param>
        public void Show3(int id)
        {

            Console.WriteLine("这里是{0}的Show3_3", this.GetType());
        }
        /// <summary>
        /// 重载方法之四
        /// </summary>
        /// <param name="name"></param>
        public void Show3(string name)
        {

            Console.WriteLine("这里是{0}的Show3_4", this.GetType());
        }
        /// <summary>
        /// 重载方法之五
        /// </summary>
        public void Show3()
        {

            Console.WriteLine("这里是{0}的Show3_1", this.GetType());
        }
        /// <summary>
        /// 私有方法
        /// </summary>
        /// <param name="name"></param>
        private void Show4(string name)
        {
            Console.WriteLine("这里是{0}的Show4", this.GetType());
        }
        /// <summary>
        /// 静态方法
        /// </summary>
        /// <param name="name"></param>
        public static void Show5(string name)
        {
            Console.WriteLine("这里是{0}的Show5", typeof(OracleHelper));
        }
        #endregion

        //private static string ConnectionStringCustomers = ConfigurationManager.ConnectionStrings["Customers"].ConnectionString;
        private static string ConnectionStringCustomers = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build().GetSection("connectionStrings")["connectionString"];
        //private static string IDBHelperConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build().GetSection("connectionStrings")["connectionString"];


        /// <summary>
        /// Find Company  Find User 还有N多个表。。。。
        /// 如果希望一个方法  能返回不同的类型，那就是泛型方法
        /// 
        /// 如果还有一个人是钟于阿森纳，那就是我
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id)
        {
            Type type = typeof(T);
            string sql = $"SELECT {string.Join(",", type.GetProperties().Select(p => $"{p.Name}"))} FROM {type.Name} WHERE su_ID={id}";
            object oObject = Activator.CreateInstance(type);

            using (OracleConnection conn = new OracleConnection(ConnectionStringCustomers))
            {
                conn.Open();
                OracleCommand command = new OracleCommand(sql, conn);
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (var prop in type.GetProperties()) 
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (prop.Name.ToUpper().Equals(column.ColumnName.ToUpper()))
                            {
                                prop.SetValue(oObject, row[column.ColumnName]);
                            }
                        }
                    }  
                }   
            }
            return (T)oObject;
        }
    }
}
