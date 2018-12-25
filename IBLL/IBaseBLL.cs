using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBaseBLL<T> where T : class ,new()
    {
        void Add(T item);
        void Update(T item);
        void Delete(string ID);
        void Delete(T item);
        T Find(string ID);
        IEnumerable<T> SqlQuery(string sql);

        void SqlCommand(string sql);
        //int SqlCommand(string sql);
        //IEnumerable<T> List(ListModel listModel, String TableName);
    }
}
