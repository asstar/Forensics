using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Forensics.Tools
{
    public class DBTools
    {
        public static List<T> ConvertToList<T>(DataTable table) where T : new()
        {
            //置为垃圾对象 
            List<T> list = null;
            if (table != null)
            {
                DataColumnCollection columns = table.Columns;
                int columnCount = columns.Count;
                T type = new T();
                Type columnType = type.GetType();
                PropertyInfo[] properties = columnType.GetProperties();
                if (properties.Length == columnCount)
                {
                    list = new List<T>();
                    foreach (DataRow currentRow in table.Rows)
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            for (int j = 0; j < properties.Length; j++)
                            {
                                if (columns[i].ColumnName == properties[j].Name)
                                {
                                    if (currentRow[i] != DBNull.Value)
                                    {
                                        properties[j].SetValue(type, currentRow[i], null);
                                    }
                                }
                            }
                        }
                        list.Add(type); type = new T();
                    }
                }
                else { list = null; }
            }
            else
            {
                throw new ArgumentNullException("参数不能为空");
            }
            return list;
        }
        public static void DeleteTable(string tableName)
        {
            new SQLiteHelper().ExecuteNonQuery("Delete From " + tableName);
        }
        public static void Zip()
        {
            new SQLiteHelper().ExecuteNonQuery("vacuum");
        }
    }
}
