using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderService _orderService;

        public OrderDetailManager(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void TDelete(OrderDetail t)
        {
            throw new NotImplementedException();
        }

        public OrderDetail TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(OrderDetail t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(OrderDetail t)
        {
            throw new NotImplementedException();
        }
    }
}
