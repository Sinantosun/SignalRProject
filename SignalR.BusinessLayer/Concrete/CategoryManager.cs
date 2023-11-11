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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _ICategoryDal;

        public CategoryManager(ICategoryDal ıCategoryDal)
        {
            _ICategoryDal = ıCategoryDal;
        }

        public int TActiveCategoryCount()
        {
            return _ICategoryDal.ActiveCategoryCount();
        }

        public int TCategoryCount()
        {
          return _ICategoryDal.CategoryCount();
        }

        public void TDelete(Category t)
        {
            _ICategoryDal.Delete(t);
        }

        public Category TgetById(int id)
        {
            return _ICategoryDal.getById(id);
        }

        public List<Category> TGetList()
        {
            return _ICategoryDal.GetList();
        }

        public void TInsert(Category t)
        {
            _ICategoryDal.Insert(t);
        }

        public int TPassiveCategoryCount()
        {
            return _ICategoryDal.PassiveCategoryCount();
        }

        public void TUpdate(Category t)
        {
            _ICategoryDal.Update(t);
        }
    }
}
