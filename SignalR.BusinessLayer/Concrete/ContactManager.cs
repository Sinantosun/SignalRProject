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
    public class ContactManager : IContacService
    {
        private readonly IContactDal _IContactDal;

        public ContactManager(IContactDal ıContactDal)
        {
            _IContactDal = ıContactDal;
        }

        public void TDelete(Contact t)
        {
            _IContactDal.Delete(t);
        }

        public Contact TgetById(int id)
        {
            return _IContactDal.getById(id);
        }

        public List<Contact> TGetList()
        {
           return _IContactDal.GetList();
        }

        public void TInsert(Contact t)
        {
            _IContactDal.Insert(t);
        }

        public void TUpdate(Contact t)
        {
            _IContactDal.Update(t);
        }
    }
}
