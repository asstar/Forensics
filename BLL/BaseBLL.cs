using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        public void Add(T item)
        {
            using (var db = new DBEntities())
            {

                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }

        public void BulkAdd(List<T> list)
        {
            using (var db = new DBEntities())
            {
                db.BulkInsert(list); 

                //db.Set<T>().Add(item);
                db.BulkSaveChanges();
            }
        }
        public void Update(T item)
        {
            using (var db = new DBEntities())
            {

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(string ID)
        {
            using (var db = new DBEntities())
            {

                T item = Find(ID);
                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(T item)
        {
            using (var db = new DBEntities())
            {
                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public IEnumerable<T> SqlQuery(string sql)
        {
            using (var db = new DBEntities())
            {
                //new LogTools().Insert("查询", sql);
                var result = db.Database.SqlQuery<T>(sql).ToList();
                return db.Database.SqlQuery<T>(sql)==null?null:db.Database.SqlQuery<T>(sql).ToList();
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var db = new DBEntities())
            {
                //new LogTools().Insert("查询", sql);
                string type=typeof(T).ToString();
                if(type.LastIndexOf('.')>=0){
                    type=type.Substring(type.LastIndexOf('.')+1);
                }
                string sql = ("Select * From " + type);
                var result = db.Database.SqlQuery<T>(sql).ToList();
                return db.Database.SqlQuery<T>(sql) == null ? null : db.Database.SqlQuery<T>(sql).ToList();
            }
        }
        public void SqlCommand(string sql)
        {
            using (var db = new DBEntities())
            {
                //new LogTools().Insert("查询", sql);
                db.Database.ExecuteSqlCommand(sql);
            }
        }

        public T Find(string ID)
        {
            using (var db = new DBEntities())
            {
                return db.Set<T>().Find(ID);//db.ClueInfo.Find(guid);
            }
        }
    }
}

