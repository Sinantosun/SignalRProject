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

        public decimal TAvgProductPriceByHambuger()
        {
            return _IProductDal.AvgProductPriceByHambuger();
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

        public List<Product> TGetProductsWithCategories()
        {
            return _IProductDal.GetProductsWithCategories();
        }

        public void TInsert(Product t)
        {
            _IProductDal.Insert(t);
        }

        public int TProductCount()
        {
            return _IProductDal.ProductCount();
        }

        public int TProductCountByCategoryNameDrink()
        {
            return _IProductDal.ProductCountByCategoryNameDrink();
        }

        public int TProductCountByCategoryNameHamburger()
        {
            return _IProductDal.ProductCountByCategoryNameHamburger();
        }

        public string TProductNameMinPriceByMax()
        {
            return _IProductDal.ProductNameMinPriceByMax();
        }

        public string TProductNamePriceByMax()
        {
            return _IProductDal.ProductNamePriceByMax();
        }

        public decimal TProductPriceAvg()
        {
            return _IProductDal.ProductPriceAvg();
        }

        public void TUpdate(Product t)
        {
            _IProductDal.Update(t);
        }
    }
}
