using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace zhao56.study.basic.Common
{
    public class OracleHelper : IdbHelper
    {
        public bool Add<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public bool Del(decimal id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(decimal id) where T : class
        {
            Type type = typeof(T);
            string sql = $"SELECT {string.Join(",", type.GetProperties().Select(p => $"{p.Name}"))} FROM {type.Name} WHERE su_ID={id}";
            object oObject = Activator.CreateInstance(type);
            using (OracleConnection conn = new OracleConnection(ConfigHelper.GetConnectionString()))
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
                return (T)oObject;
            }
        }

        public List<T> Query<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
