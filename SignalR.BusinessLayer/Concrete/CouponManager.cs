using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccsessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class CouponManager : ICouponService
    {
        private readonly ICouponCodeDal couponCodeDal;

        public CouponManager(ICouponCodeDal couponCodeDal)
        {
            this.couponCodeDal = couponCodeDal;
        }

        public void TDelete(CouponCode t)
        {
            couponCodeDal.Delete(t);
        }

        public CouponCode TgetById(int id)
        {
            return couponCodeDal.getById(id);
        }

        public List<CouponCode> TGetList()
        {
            return couponCodeDal.GetList();
        }

        public void TInsert(CouponCode t)
        {
            couponCodeDal.Insert(t);
        }

        public void TUpdate(CouponCode t)
        {
            couponCodeDal.Update(t);
        }
    }
}
