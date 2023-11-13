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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TDelete(Basket t)
        {
            _basketDal.Delete(t);
        }

        public List<Basket> TgetBasketByMenuTableNumber(int id)
        {
            return _basketDal.getBasketByMenuTableNumber(id);
        }

        public Basket TgetById(int id)
        {
            return _basketDal.getById(id);
        }

        public List<Basket> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Basket t)
        {
            _basketDal.Insert(t);
        }

        public void TUpdate(Basket t)
        {
            throw new NotImplementedException();
        }
    }
}
