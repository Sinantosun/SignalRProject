using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccsessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Update(T t);
        void Insert(T t);
        void Delete(T t);
        List<T> GetList();
        T getById(int id);
    }
}
