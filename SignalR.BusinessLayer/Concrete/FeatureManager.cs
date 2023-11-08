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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _IFeatureDal;

        public FeatureManager(IFeatureDal ıFeatureDal)
        {
            _IFeatureDal = ıFeatureDal;
        }

        public void TDelete(Feature t)
        {
            _IFeatureDal.Delete(t);
        }

        public Feature TgetById(int id)
        {
            return _IFeatureDal.getById(id);
        }

        public List<Feature> TGetList()
        {
            return _IFeatureDal.GetList();
        }

        public void TInsert(Feature t)
        {
            _IFeatureDal.Insert(t);
        }

        public void TUpdate(Feature t)
        {
            _IFeatureDal.Update(t);
        }
    }
}
