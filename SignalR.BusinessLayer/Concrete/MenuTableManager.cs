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
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public void TDelete(MenuTable t)
        {
            throw new NotImplementedException();
        }

        public MenuTable TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MenuTable> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(MenuTable t)
        {
            throw new NotImplementedException();
        }

        public int TMenuTableCount()
        {
            return _menuTableDal.MenuTableCount();
        }

        public void TUpdate(MenuTable t)
        {
            throw new NotImplementedException();
        }
    }
}
