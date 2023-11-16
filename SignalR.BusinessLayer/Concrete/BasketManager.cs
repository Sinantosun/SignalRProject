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

        public decimal TBasketSum()
        {
           return _basketDal.BasketSum();
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
            return _basketDal.GetList();
        }

        public void TInsert(Basket t)
        {
            _basketDal.Insert(t);
        }

        public decimal TSetCouponCode(string couponName)
        {
            return _basketDal.SetCouponCode(couponName);
        }

        public void TUpdate(Basket t)
        {
            throw new NotImplementedException();
        }
    }
}
