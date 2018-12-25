using BLL;
using Model;
//using Forensics.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Forensics.Tools
{
    public class ImportData
    {

        //SQLiteHelper sqlite;

        public ImportData()
        {

        }

        public void DeleteTable(string table)
        {
            //new WA_MFORENSICS_010400BLL().d
            using (var db = new DBEntities())
            {
                //new LogTools().Insert("查询", sql);
                db.Database.ExecuteSqlCommand("delete from " + table);
                //db.Database.ExecuteSqlCommand("VACUUM");
            }

        }

        public DataTable MakeTable(object src)
        {

            DataTable result = new DataTable();
            foreach (System.Reflection.PropertyInfo p in src.GetType().GetProperties())
            {
                //Console.WriteLine("Name:{0} Value:{1}", p.Name, p.GetValue(src,null));
                result.Columns.Add(p.Name, Type.GetType("System.String"));
            }
            result.Columns.Remove("ID");
            result.Columns.Add("SPACE", Type.GetType("System.String"));
            return result;
        }
        public void InsertData(DataTable data, string type)
        {
            switch (type)
            {
                case "WA_MFORENSICS_010100":
                    List<WA_MFORENSICS_010100> result010100 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_010100>(data).ToList();
                    Action<WA_MFORENSICS_010100> action010100 = item => item.ID = Guid.NewGuid().ToString();
                    result010100.ForEach(action010100);
                    new WA_MFORENSICS_010100BLL().BulkAdd(result010100);
                    break;
                case "WA_MFORENSICS_010200":
                    List<WA_MFORENSICS_010200> result010200 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_010200>(data).ToList();
                    Action<WA_MFORENSICS_010200> action010200 = item => item.ID = Guid.NewGuid().ToString();
                    result010200.ForEach(action010200);
                    new WA_MFORENSICS_010200BLL().BulkAdd(result010200);
                    break;
                case "WA_MFORENSICS_010202":
                    List<WA_MFORENSICS_010202> result010202 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_010202>(data).ToList();
                    Action<WA_MFORENSICS_010202> action010202 = item => item.ID = Guid.NewGuid().ToString();
                    result010202.ForEach(action010202);
                    new WA_MFORENSICS_010202BLL().BulkAdd(result010202);
                    break;
                case "WA_MFORENSICS_010300":
                    List<WA_MFORENSICS_010300> result010300 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_010300>(data).ToList();
                    Action<WA_MFORENSICS_010300> action010300 = item => item.ID = Guid.NewGuid().ToString();
                    result010300.ForEach(action010300);
                    new WA_MFORENSICS_010300BLL().BulkAdd(result010300);
                    break;
                case "WA_MFORENSICS_010400":
                    List<WA_MFORENSICS_010400> result010400 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_010400>(data).ToList();
                    Action<WA_MFORENSICS_010400> action010400 = item => item.ID = Guid.NewGuid().ToString();
                    result010400.ForEach(action010400);
                    new WA_MFORENSICS_010400BLL().BulkAdd(result010400);
                    break;
                case "WA_MFORENSICS_010500":
                    List<WA_MFORENSICS_010500> result010500 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_010500>(data).ToList();
                    Action<WA_MFORENSICS_010500> action010500 = item => item.ID = Guid.NewGuid().ToString();
                    result010500.ForEach(action010500);
                    new WA_MFORENSICS_010500BLL().BulkAdd(result010500);
                    break;
                case "WA_MFORENSICS_010700":
                    List<WA_MFORENSICS_010700> result010700 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_010700>(data).ToList();
                    Action<WA_MFORENSICS_010700> action010700 = item => item.ID = Guid.NewGuid().ToString();
                    result010700.ForEach(action010700);
                    new WA_MFORENSICS_010700BLL().BulkAdd(result010700);
                    break;
                case "WA_MFORENSICS_020100":
                    List<WA_MFORENSICS_020100> result020100 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_020100>(data).ToList();
                    Action<WA_MFORENSICS_020100> action020100 = item => item.ID = Guid.NewGuid().ToString();
                    result020100.ForEach(action020100);
                    new WA_MFORENSICS_020100BLL().BulkAdd(result020100);
                    break;
                case "WA_MFORENSICS_020200":
                    List<WA_MFORENSICS_020200> result020200 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_020200>(data).ToList();
                    Action<WA_MFORENSICS_020200> action020200 = item => item.ID = Guid.NewGuid().ToString();
                    result020200.ForEach(action020200);
                    new WA_MFORENSICS_020200BLL().BulkAdd(result020200);
                    break;
                case "WA_MFORENSICS_020300":
                    List<WA_MFORENSICS_020300> result020300 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_020300>(data).ToList();
                    Action<WA_MFORENSICS_020300> action020300 = item => item.ID = Guid.NewGuid().ToString();
                    result020300.ForEach(action020300);
                    new WA_MFORENSICS_020300BLL().BulkAdd(result020300);
                    break;
                case "WA_MFORENSICS_020400":
                    List<WA_MFORENSICS_020400> result020400 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_020400>(data).ToList();
                    Action<WA_MFORENSICS_020400> action020400 = item => item.ID = Guid.NewGuid().ToString();
                    result020400.ForEach(action020400);
                    new WA_MFORENSICS_020400BLL().BulkAdd(result020400);
                    break;
                case "WA_MFORENSICS_020500":
                    List<WA_MFORENSICS_020500> result020500 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_020500>(data).ToList();
                    Action<WA_MFORENSICS_020500> action020500 = item => item.ID = Guid.NewGuid().ToString();
                    result020500.ForEach(action020500);
                    new WA_MFORENSICS_020500BLL().BulkAdd(result020500);
                    break;
                case "WA_MFORENSICS_020600":
                    List<WA_MFORENSICS_020600> result020600 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_020600>(data).ToList();
                    Action<WA_MFORENSICS_020600> action020600 = item => item.ID = Guid.NewGuid().ToString();
                    result020600.ForEach(action020600);
                    new WA_MFORENSICS_020600BLL().BulkAdd(result020600);
                    break;
                case "WA_MFORENSICS_020700":
                    List<WA_MFORENSICS_020700> result020700 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_020700>(data).ToList();
                    Action<WA_MFORENSICS_020700> action020700 = item => item.ID = Guid.NewGuid().ToString();
                    result020700.ForEach(action020700);
                    new WA_MFORENSICS_020700BLL().BulkAdd(result020700);
                    break;
                case "WA_MFORENSICS_090400":
                    List<WA_MFORENSICS_090400> result090400 = ListToDatatableHelper.ConvertTo<WA_MFORENSICS_090400>(data).ToList();
                    Action<WA_MFORENSICS_090400> action090400 = item => item.ID = Guid.NewGuid().ToString();
                    result090400.ForEach(action090400);
                    new WA_MFORENSICS_090400BLL().BulkAdd(result090400);
                    break;
            }
        }

        public static void CopyValue(object origin, object target)
        {
            System.Reflection.PropertyInfo[] properties = (target.GetType()).GetProperties();
            System.Reflection.FieldInfo[] fields = (origin.GetType()).GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {
                    if (fields[i].Name == properties[j].Name && properties[j].CanWrite)
                    {
                        properties[j].SetValue(target, fields[i].GetValue(origin), null);
                    }
                }
            }
        }
    }
}
