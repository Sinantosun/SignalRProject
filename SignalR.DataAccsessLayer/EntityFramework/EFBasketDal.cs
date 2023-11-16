using Microsoft.EntityFrameworkCore;
using SignalR.DataAccsessLayer.Abstract;
using SignalR.DataAccsessLayer.Concrete;
using SignalR.DataAccsessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccsessLayer.EntityFramework
{
    public class EFBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EFBasketDal(SignalRContext context) : base(context)
        {
        }

        public decimal BasketSum()
        {
            using var context = new SignalRContext();
            return context.Baskets.Sum(x => x.TotalPrice);
        }

        public List<Basket> getBasketByMenuTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.MenuTableID == id).Include(y => y.Product).ToList();
            return values;
        }

        public decimal SetCouponCode(string couponName)
        {
            using var context = new SignalRContext();
            return context.couponCodes.Where(x => x.Title == couponName).Select(y => y.Amout).FirstOrDefault();

        }
    }
}
