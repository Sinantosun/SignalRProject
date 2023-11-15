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
    public class EFMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EFMenuTableDal(SignalRContext context) : base(context)
        {
        }

        public int MenuTableCount()
        {
            using var context = new SignalRContext();
            return context.menuTables.Count();
        }

        public decimal TableRateToAll()
        {
            using var context = new SignalRContext();
            float FalseTableCount = context.menuTables.Where(x => x.Status == true).Count();
            float allTableCount = MenuTableCount();
            decimal rate = Convert.ToDecimal((FalseTableCount / allTableCount) * 100);
            return rate;
        }
    }
}
