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
    public class MessagesManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessagesManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(Messages t)
        {
            _messageDal.Delete(t);
        }

        public Messages TgetById(int id)
        {
          return  _messageDal.getById(id);
        }

        public List<Messages> TGetList()
        {
            return _messageDal.GetList();
        }

        public void TInsert(Messages t)
        {
            _messageDal.Insert(t);
        }

        public void TUpdate(Messages t)
        {
            _messageDal.Update(t);
        }
    }
}
