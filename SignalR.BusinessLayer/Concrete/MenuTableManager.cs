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
            _menuTableDal.Delete(t);
        }

        public MenuTable TgetById(int id)
        {
            return _menuTableDal.getById(id);
        }

        public List<MenuTable> TGetList()
        {
            return _menuTableDal.GetList();
        }

        public void TInsert(MenuTable t)
        {
            _menuTableDal.Insert(t);
        }

        public int TMenuTableCount()
        {
            return _menuTableDal.MenuTableCount();
        }

        public decimal TTableRateToAll()
        {
            return _menuTableDal.TableRateToAll();
        }

        public void TUpdate(MenuTable t)
        {
            _menuTableDal.Update(t);
        }
    }
}
