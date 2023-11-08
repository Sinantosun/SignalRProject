using Microsoft.EntityFrameworkCore;
using SignalR.DataAccsessLayer.Abstract;
using SignalR.DataAccsessLayer.Concrete;
using SignalR.DataAccsessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccsessLayer.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;


        }
    }
}
