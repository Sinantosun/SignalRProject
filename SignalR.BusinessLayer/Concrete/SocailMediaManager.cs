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
    public class SocailMediaManager : ISocialMedaiService
    {
        private readonly ISocialMediaDal _ISocailMediaDal;

        public SocailMediaManager(ISocialMediaDal ıSocailMediaDal)
        {
            _ISocailMediaDal = ıSocailMediaDal;
        }

        public void TDelete(SocailMedia t)
        {
            _ISocailMediaDal.Delete(t);
        }

        public SocailMedia TgetById(int id)
        {
            return _ISocailMediaDal.getById(id);
        }

        public List<SocailMedia> TGetList()
        {
            return _ISocailMediaDal.GetList();
        }

        public void TInsert(SocailMedia t)
        {
            _ISocailMediaDal.Insert(t);
        }

        public void TUpdate(SocailMedia t)
        {
            _ISocailMediaDal.Update(t);
        }
    }
}
