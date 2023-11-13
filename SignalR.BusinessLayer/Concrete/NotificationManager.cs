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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TDelete(Notification t)
        {
            _notificationDal.Delete(t);
        }

		public List<Notification> TgetAllNotificationActive()
		{
            return _notificationDal.getAllNotificationActive();
		}

		public Notification TgetById(int id)
        {
         return   _notificationDal.getById(id);
        }

        public List<Notification> TGetList()
        {
            return _notificationDal.GetList();
        }

        public void TInsert(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public int TNotifactionCountByStatusFalse()
        {
            return _notificationDal.NotifactionCountByStatusFalse();
        }

        public void TNotificationStatusChangeFalse(int id)
        {
            _notificationDal.NotificationStatusChangeFalse(id);
        }

        public void TNotificationStatusChangeTrue(int id)
        {
            _notificationDal.NotificationStatusChangeTrue(id);
        }

        public void TUpdate(Notification t)
        {
            _notificationDal.Update(t);
        }
    }
}
