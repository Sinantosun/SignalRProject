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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _IProductDal;

        public ProductManager(IProductDal ıProductDal)
        {
            _IProductDal = ıProductDal;
        }

        public void TDelete(Product t)
        {
            _IProductDal.Delete(t);
        }

        public Product TgetById(int id)
        {
            return _IProductDal.getById(id);
        }

        public List<Product> TGetList()
        {
            return _IProductDal.GetList();
        }

        public void TInsert(Product t)
        {
            _IProductDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
            _IProductDal.Update(t);
        }
    }
}
