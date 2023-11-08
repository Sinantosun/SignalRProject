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
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _IDiscountDal;

        public DiscountManager(IDiscountDal ıDiscountDal)
        {
            _IDiscountDal = ıDiscountDal;
        }

        public void TDelete(Discount t)
        {
            _IDiscountDal.Delete(t);
        }

        public Discount TgetById(int id)
        {
           return _IDiscountDal.getById(id);
        }

        public List<Discount> TGetList()
        {
            return _IDiscountDal.GetList();
        }

        public void TInsert(Discount t)
        {
            _IDiscountDal.Insert(t);
        }

        public void TUpdate(Discount t)
        {
            _IDiscountDal.Update(t);
        }
    }
}
