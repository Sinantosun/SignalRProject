using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccsessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _IAboutDal;

        public AboutManager(IAboutDal ıAboutDal)
        {
            _IAboutDal = ıAboutDal;
        }

        public void TDelete(About t)
        {
            _IAboutDal.Delete(t);
        }

        public About TgetById(int id)
        {
            return _IAboutDal.getById(id);
        }

        public List<About> TGetList()
        {
            return _IAboutDal.GetList();
        }

        public void TInsert(About t)
        {
            _IAboutDal.Insert(t);
        }

        public void TUpdate(About t)
        {
            _IAboutDal.Update(t);
        }
    }
}
