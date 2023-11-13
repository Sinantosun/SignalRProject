﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface INotificationService:IGenericService<Notification>
    {
        int TNotifactionCountByStatusFalse();
        List<Notification> TgetAllNotificationActive();
        void TNotificationStatusChangeTrue(int id);
        void TNotificationStatusChangeFalse(int id);

    }
}
