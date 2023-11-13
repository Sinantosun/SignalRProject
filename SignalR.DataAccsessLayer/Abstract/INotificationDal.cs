using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccsessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        int NotifactionCountByStatusFalse();

        List<Notification> getAllNotificationActive();

        void NotificationStatusChangeTrue(int id);
        void NotificationStatusChangeFalse(int id);
    }
}
