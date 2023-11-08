using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TUpdate(T t);
        void TInsert(T t);
        void TDelete(T t);
        List<T> TGetList();
        T TgetById(int id);
    }
}
